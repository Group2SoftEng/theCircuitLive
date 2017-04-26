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

namespace Kuromori.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Chat : ContentPage
    {
        public Chat(User current)
        {
            InitializeComponent();
            List<ImageCell> ChatParticipants = new List<ImageCell>();

            List<User> UserList;
                Debug.WriteLine("Test");

                UserList = HttpUtils.GetJsonInfo<List<User>>(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", current.UserName),
                new KeyValuePair<string, string>("password", current.Password)
            }, "http://haydenszymanski.me/softeng05/get_chatted.php"
           ).Result;
                Debug.WriteLine("AHHHHHHHHHHHHHHHHHHHHHHH");
                

                foreach (User user in UserList)
                {
                    Debug.WriteLine(user.UserName);
                    ImageCell temp = new ImageCell // for each participant in the list create a new cell.
                    {
                        ImageSource = user.ProfilePicture,
                        Detail = user.UserName,
                        
                    };
                    ChatParticipants.Add(temp);
                }
                listView.ItemsSource = ChatParticipants;
                listView.ItemTapped += ChatPage;

            Debug.WriteLine("end");

           
        }
            
          

        public void ChatPage(object sender, ItemTappedEventArgs e)
        {
            
        }



    }
}
