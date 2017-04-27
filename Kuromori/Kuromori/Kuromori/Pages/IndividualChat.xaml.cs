using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Kuromori.DataStructure;
using Kuromori.InfoIO;
using System.Diagnostics;
using Kuromori.Views;
using Newtonsoft.Json;

namespace Kuromori.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IndividualChat : ContentPage
    {
        public bool ChatExists;
        public User CurrentUser;
        public string ChattingUsername;

        public IndividualChat(User currentUser,string chattingUsername)
        {
            InitializeComponent();
            CurrentUser = currentUser;
            ChattingUsername = chattingUsername;
            ChatExists = HttpUtils.PostInfo(
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("username1", currentUser.UserName),
                    new KeyValuePair<string, string>("username2", chattingUsername)
                },
                "http://haydenszymanski.me/softeng05/chat_exists.php").ResponseInfo.Equals("ok") 
                ? true 
                : false;

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                Device.BeginInvokeOnMainThread(() => UpdateChat());
                return true;
            });

            StackLay.Children.Add(new ConversationView(new string[] { "" }));
        }

        void UpdateChat()
        {
            StackLay.Children.RemoveAt(0);
            string[] messages = JsonConvert.DeserializeObject<string[]>(HttpUtils.PostInfo(
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("username", CurrentUser.UserName),
                    new KeyValuePair<string, string>("password", CurrentUser.Password),
                    new KeyValuePair<string, string>("user_two", ChattingUsername),
                }, "http://haydenszymanski.me/softeng05/get_messages.php").ResponseInfo);
            StackLay.Children.Add(new ConversationView(messages));

        }

        private void EntryCompleted(object sender, EventArgs e)
        {
            if (ChatExists)
            {
                Debug.WriteLine(HttpUtils.PostInfo(
                    new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("username", CurrentUser.UserName),
                        new KeyValuePair<string, string>("password", CurrentUser.Password),
                        new KeyValuePair<string, string>("recipient", ChattingUsername),
                        new KeyValuePair<string, string>("message", ChatBox.Text)
                    },
                    "http://haydenszymanski.me/softeng05/send_message.php").ResponseInfo);
            }
            else
            {
                HttpUtils.PostInfo(
                    new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("user_one", CurrentUser.UserName),
                        new KeyValuePair<string, string>("user_two", ChattingUsername)
                    },
                    "http://haydenszymanski.me/softeng05/make_chat.php");
                HttpUtils.PostInfo(
                    new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("username", CurrentUser.UserName),
                        new KeyValuePair<string, string>("password", CurrentUser.Password),
                        new KeyValuePair<string, string>("recipient", ChattingUsername),
                        new KeyValuePair<string, string>("message", ChatBox.Text)
                    },
                    "http://haydenszymanski.me/softeng05/send_message.php");
            }
            ChatBox.Text = "";
        }
    }
}
