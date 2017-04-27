using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Kuromori.DataStructure;
using Kuromori;
using Kuromori.InfoIO;
using System.Diagnostics;
using Newtonsoft.Json;

namespace Kuromori.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Chat : ContentPage
    {
        User currentUser;
        public Chat(User current)
        {
            currentUser = current;
            InitializeComponent();
            List<ImageCell> ChatParticipants = new List<ImageCell>();

            String UsersString = "";

            UsersString = HttpUtils.PostInfo(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", current.UserName),
                new KeyValuePair<string, string>("password", current.Password)
            }, "http://haydenszymanski.me/softeng05/get_chatted.php"
           ).ResponseInfo;

            
            User[] UserArray = JsonConvert.DeserializeObject<User[]>(UsersString);
            foreach (User user in UserArray)
            {
                
            }

            foreach (User user in UserArray)
            {
                 ImageCell tempCell = new ImageCell
                {
                     ImageSource = user.ProfilePicture,
                     Text = user.UserName,
                     Detail = HttpUtils.PostInfo(
                     new List<KeyValuePair<string, string>>
                     {
                         new KeyValuePair<string, string>("username", currentUser.UserName),
                         new KeyValuePair<string, string>("password", currentUser.Password),
                         new KeyValuePair<string, string>("recipient", user.UserName),
                     }, "http://haydenszymanski.me/softeng05/get_last_chat.php").ResponseInfo
                };
                ChatParticipants.Add(tempCell);
            }

            listView.ItemsSource = ChatParticipants;


        }

        async void OnConversationClick(object sender, ItemTappedEventArgs e)
        {
            var cell = e.Item as ImageCell;
            await Navigation.PushAsync(new IndividualChat(currentUser, cell.Text));
        }

        async void OnSearchPressed()
        {
            await Navigation.PushAsync(new UserSearchResultPage(currentUser, Search.Text));
        }
            
          

        public void ChatPage(object sender, ItemTappedEventArgs e)
        {
            
        }



    }
}
