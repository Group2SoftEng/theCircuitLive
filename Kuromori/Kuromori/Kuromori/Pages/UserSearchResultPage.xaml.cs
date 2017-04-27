using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kuromori.DataStructure;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Kuromori.InfoIO;
using System.Diagnostics;
using Newtonsoft.Json;

namespace Kuromori.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserSearchResultPage : ContentPage
    {
        User CurrentUser;
        string SearchStr;
        public UserSearchResultPage(User currentUser, string search)
        {
            InitializeComponent();
            CurrentUser = currentUser;
            SearchStr = search;
            Task.Run(async () => await UpdateMatches());
        }

        async Task UpdateMatches()
        {

            User[] MatchedUsers = await HttpUtils.GetJsonInfo<User[]>(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", CurrentUser.UserName),
                new KeyValuePair<string, string>("password", CurrentUser.Password),
                new KeyValuePair<string, string>("search", SearchStr)
            }, "http://haydenszymanski.me/softeng05/search_users.php");

            List<ImageCell> UserResults = new List<ImageCell>();


            Device.BeginInvokeOnMainThread(() =>
            {
                foreach(User user in MatchedUsers)
                {
                    UserResults.Add(new ImageCell
                    {
                        ImageSource = user.ProfilePicture,
                        Text = user.UserName
                    });
                }
                listView.ItemsSource = UserResults;
            });
        }

        async void OnSearchPressed()
        {
            Navigation.InsertPageBefore(new UserSearchResultPage(CurrentUser, Search.Text), this);
            await Navigation.PopAsync();
        }

        async void OnUserClick(object sender, ItemTappedEventArgs e)
        {
            var cell = e.Item as ImageCell;
            await Navigation.PushAsync(new IndividualChat(CurrentUser, cell.Text));
        }

    }
}
