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
using System.Diagnostics;

namespace Kuromori.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Chat : ContentPage
    {
        public Chat(User current)
        {
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
                Debug.WriteLine(user.Id);
            }


        }
            
          

        public void ChatPage(object sender, ItemTappedEventArgs e)
        {
            
        }



    }
}
