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
            Button link = new Button();
            Button req = new Button();
            Label res = new Label { Text = "gimmie" };

            Layout layout = new StackLayout
            {
                Children =
                {
                    link,
                    req,
                    res
                }
            };

            this.BackgroundColor = Color.Black;
            
            link.Clicked += (sender, args) => {
                Device.OpenUri(new Uri("http://thecircuitlive.com/index.php/events/"));
            };
            req.Clicked += (sender, args) =>
            {
                res.Text = "no bch";
            };
            link.BackgroundColor = Color.Red;
            Content = layout;
        }

        
    }




}
