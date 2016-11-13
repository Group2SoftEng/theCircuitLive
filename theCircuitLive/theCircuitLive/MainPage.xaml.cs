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
            this.PushAsync(new StartingPage());
              
        }

        
    }

    public class StartingPage : ContentPage
    {
        public StartingPage()
        {
            this.BackgroundColor = Color.Black;
            Button b = new Button();
            b.Clicked += (sender, args) => {
                Device.OpenUri(new Uri("http://thecircuitlive.com/index.php/events/"));


            };
            Content = b;
        }

        
    }




}
