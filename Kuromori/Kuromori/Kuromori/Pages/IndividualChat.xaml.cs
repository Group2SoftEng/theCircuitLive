using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kuromori.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IndividualChat : ContentPage
    {
        public IndividualChat(object sender, ItemTappedEventArgs e)
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
