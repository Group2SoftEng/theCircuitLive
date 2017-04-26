using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Kuromori.DataStructure;

namespace Kuromori.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IndividualChat : ContentPage
    {
        public IndividualChat(User currentUser,string chattingUsername)
        {
            InitializeComponent();

            List<ImageCell> n = new List<ImageCell>();

            //foreach(Chat chat in Chat_List)

            ImageCell temp = new ImageCell // for each participant in the list create a new cell.
            {
                //ImageSource = "User IMAGEEEEE";
                Text = "Username : ",               
            };
            n.Add(temp);

            listView.ItemsSource = n;            

        }
    }
}
