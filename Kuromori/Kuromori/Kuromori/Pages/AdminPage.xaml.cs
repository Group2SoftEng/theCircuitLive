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
	/// <summary>
	/// Admin page.
	/// Represents an admin page that provides promotion and demotion functionality.
	/// </summary>
	public partial class AdminPage : ContentPage
	{
        Admin Admin;
		public AdminPage(Admin admin)
		{
			InitializeComponent();
            Admin = admin;

			// On initialize run then update list methods.
            Task.Run(async () => await UpdateParticipants());
            Task.Run(async () => await UpdateOrganizers()); 

			Participant.ItemTapped += OnParticipantClick;
            Organizer.ItemTapped += OnOrganizerClick;
		}

		/// <summary>
		/// On the participant click.
		/// Executes when a participant item in the participant list has been clicked
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
        async void OnParticipantClick(object sender, ItemTappedEventArgs e)
        {
			// cell : get the tapped cell in the list
            var cell = e.Item as TextCell;
            if (await YesNoDialog("promote")) // If user clicks yes on the alert popup
            {
                ValidateAdmin(); // Double-check admin credentials for each operation

				// Post to admin_promote page with admin credentials and user_id from tapped item
				// This will promote that participant to an organizer.
				Debug.WriteLine(HttpUtils.PostInfo(new List<KeyValuePair<string, string>> {
                    new KeyValuePair<string, string>("admin_username", Admin.AdminUsername),
                    new KeyValuePair<string, string>("admin_password", Admin.AdminPassword),
                    new KeyValuePair<string, string>("user_id", cell.Detail.Substring(5))},
                      "http://haydenszymanski.me/softeng05/admin_promote.php").ResponseInfo);

                await UpdateParticipants(); // Update the participant list to reflect any changes
                await UpdateOrganizers(); // Update the organizer list to reflect any changes
            }
        }

        async void OnOrganizerClick(object sender, ItemTappedEventArgs e)
        {

			// cell : get the tapped cell in the list
            var cell = e.Item as TextCell;
            if (await YesNoDialog("demote")) // If user clicks yes on the alert popup
            {
                ValidateAdmin(); // Double-check admin credentials for each operation

				// Post to admin_promote page with admin credentials and user_id from tapped item
				// This will demote that organizer to a participant
				Debug.WriteLine(HttpUtils.PostInfo(new List<KeyValuePair<string, string>> {
                    new KeyValuePair<string, string>("admin_username", Admin.AdminUsername),
                    new KeyValuePair<string, string>("admin_password", Admin.AdminPassword),
                    new KeyValuePair<string, string>("user_id", cell.Detail.Substring(5))},
                      "http://haydenszymanski.me/softeng05/admin_demote.php").ResponseInfo);

                
                await UpdateParticipants(); // Update the participant list to reflect any changes.
                await UpdateOrganizers();   // Update the organizer list to reflect any changes.

            }
        }

		/// <summary>
		/// Async wrapper for a yesnodialog that returns a boolean task.
		/// </summary>
		/// <returns>The no dialog.</returns>
		/// <param name="actionType">Action type : String that will represent a demotion or a promotion</param>
        async Task<bool> YesNoDialog(string actionType)
        {
            var response = await DisplayAlert(actionType, actionType + " User?", "Yes", "No");
            return response;
        }

		/// <summary>
		/// Validates the admin.
		/// Determine if the current admin logged in has valid credentials. If not pop this page off the navigation stack
		/// </summary>
        void ValidateAdmin()
        {
			if (!HttpUtils.PostInfo(new List<KeyValuePair<string, string>> {
                    new KeyValuePair<string, string>("admin_username", Admin.AdminUsername),
                    new KeyValuePair<string, string>("admin_password", Admin.AdminPassword)},
                      "http://haydenszymanski.me/softeng05/login_admin.php").ResponseInfo.Equals("Success"))
            {
                // NOTE: if body on failure
                Navigation.PopAsync();
            }
        }

        /// <summary>
        /// Async method that updates the participant list and all of the containing cells.
        /// </summary>
        /// <returns></returns>
        async Task UpdateParticipants()
        {
			User[] participants = await HttpUtils.GetJsonInfo<User[]>(
                new List<KeyValuePair<string, string>>
                {
                }, "http://haydenszymanski.me/softeng05/get_participants.php"); // get all current participant

            List<TextCell> participantCells = new List<TextCell>(); // create an empty list of textcells


            Device.BeginInvokeOnMainThread(() =>  // Containing body executes after any await call
            {
                foreach (User participant in participants)
                {
                    TextCell temp = new TextCell // for each participant in the list create a new cell.
                    {
                        Text = "Username : " + participant.UserName,
                        Detail = "Id : " + participant.Id
                    };
                    participantCells.Add(temp); // add that cell to the temporary list
                }
                Participant.ItemsSource = participantCells; // set the list in gui to the temp list.
            });
        }

        /// <summary>
        /// Async method that updates the organizer list and all of the containing cells.
        /// </summary>
        /// <returns></returns>
        async Task UpdateOrganizers()
        {
			User[] participants = await HttpUtils.GetJsonInfo<User[]>(
                new List<KeyValuePair<string, string>>
                {
                }, "http://haydenszymanski.me/softeng05/get_organizers.php"); // get all current organizers
            List<TextCell> organizerCells = new List<TextCell>();
            Device.BeginInvokeOnMainThread(() => // create an empty list of textcells
            {
                foreach (User participant in participants)
                {
					TextCell temp = new TextCell // for each participant in the list create a new cell.
                    {
                        Text = "Username : " + participant.UserName,
                        Detail = "Id : " + participant.Id
                    };
                    organizerCells.Add(temp); // add that cell to the temporary list
                }
                Organizer.ItemsSource = organizerCells; // set the list in gui to the temp list
            });
        }
	}

}
