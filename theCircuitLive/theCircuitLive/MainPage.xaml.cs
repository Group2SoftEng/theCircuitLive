using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Xamarin.Forms;

namespace theCircuitLive
{
    public partial class MainPage : NavigationPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BackgroundColor = Color.Green;
            this.PushAsync(new StartingPage());
              
        }

        
    }

    public class StartingPage : ContentPage
    {
        public StartingPage()
        {
            this.BackgroundColor = Color.Black;
            Button link = new Button();
            link.Clicked += (sender, args) => {
                Device.OpenUri(new Uri("http://thecircuitlive.com/index.php/events/"));


            };
            link.BackgroundColor = Color.Red;
            Content = link;
        }

        
    }




}
