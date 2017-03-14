using System;
using System.Text;
using System.Collections.Generic;
using Xamarin;
using Kuromori;
using Kuromori.Pages;
using Kuromori.InfoIO;
using Kuromori.DataStructure;
using System.Threading.Tasks;
using System.Diagnostics;
using Xamarin.Forms;

namespace Kuromori
{
	public partial class AdminPage : ContentPage
	{
        Admin Admin;
		public AdminPage(Admin admin)
		{
			InitializeComponent();
            Admin = admin;

            Task.Run(async () => await UpdateParticipants());
            Task.Run(async () => await UpdateOrganizers());
            Participant.ItemTapped += OnParticipantClick;
            Organizer.ItemTapped += OnOrganizerClick;
		}

        async void OnParticipantClick(object sender, ItemTappedEventArgs e)
        {
            var cell = e.Item as TextCell;
            if (await YesNoDialog("promote"))
            {
                ValidateAdmin();
                PostRequest post = new PostRequest();
                Debug.WriteLine(post.PostInfo(new List<KeyValuePair<string, string>> {
                    new KeyValuePair<string, string>("admin_username", Admin.AdminUsername),
                    new KeyValuePair<string, string>("admin_password", Admin.AdminPassword),
                    new KeyValuePair<string, string>("user_id", cell.Detail.Substring(5))},
                      "http://haydenszymanski.me/softeng05/admin_promote.php").ResponseInfo);

                
                await UpdateParticipants();
                await UpdateOrganizers();

            }
        }

        async void OnOrganizerClick(object sender, ItemTappedEventArgs e)
        {
            var cell = e.Item as TextCell;
            if (await YesNoDialog("demote"))
            {
                ValidateAdmin();
                PostRequest post = new PostRequest();
                Debug.WriteLine(post.PostInfo(new List<KeyValuePair<string, string>> {
                    new KeyValuePair<string, string>("admin_username", Admin.AdminUsername),
                    new KeyValuePair<string, string>("admin_password", Admin.AdminPassword),
                    new KeyValuePair<string, string>("user_id", cell.Detail.Substring(5))},
                      "http://haydenszymanski.me/softeng05/admin_demote.php").ResponseInfo);

                
                await UpdateParticipants();
                await UpdateOrganizers();

            }
        }

        async Task<bool> YesNoDialog(string actionType)
        {
            var response = await DisplayAlert(actionType, actionType + " User?", "Yes", "No");
            return response;
        }

        void ValidateAdmin()
        {
            PostRequest post = new PostRequest();
            if (!post.PostInfo(new List<KeyValuePair<string, string>> {
                    new KeyValuePair<string, string>("admin_username", Admin.AdminUsername),
                    new KeyValuePair<string, string>("admin_password", Admin.AdminPassword)},
                      "http://haydenszymanski.me/softeng05/login_admin.php").ResponseInfo.Equals("Success"))
            {
                // NOTE: if body on failure
                Navigation.PopAsync();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        async Task UpdateParticipants()
        {
            User[] participants = await JsonRequest.GetUserData<User[]>(
                new List<KeyValuePair<string, string>>
                {
                }, "http://haydenszymanski.me/softeng05/get_participants.php");
            List<TextCell> participantCells = new List<TextCell>();
            Device.BeginInvokeOnMainThread(() =>
            {
                foreach (User participant in participants)
                {
                    TextCell temp = new TextCell
                    {
                        Text = "Username : " + participant.UserName,
                        Detail = "Id : " + participant.Id
                    };
                    var tapAction = new MenuItem { Text = "Promote", IsDestructive = true };
                    tapAction.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));
                    participantCells.Add(temp);
                }
                Participant.ItemsSource = participantCells;
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        async Task UpdateOrganizers()
        {
            User[] participants = await JsonRequest.GetUserData<User[]>(
                new List<KeyValuePair<string, string>>
                {
                }, "http://haydenszymanski.me/softeng05/get_organizers.php");
            List<TextCell> organizerCells = new List<TextCell>();
            Device.BeginInvokeOnMainThread(() =>
            {
                foreach (User participant in participants)
                {
                    TextCell temp = new TextCell
                    {
                        Text = "Username : " + participant.UserName,
                        Detail = "Id : " + participant.Id
                    };
                    organizerCells.Add(temp);
                }
                Organizer.ItemsSource = organizerCells;
            });
        }

	}

}
