using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net;
using Xamarin.Forms;

namespace theCircuitLive
{
    public partial class MainPage : NavigationPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BarBackgroundColor = Color.Green;
            
            this.PushAsync(new StartingPage());
              
        }
        
        
    }

    public class StartingPage : ContentPage
    {
        Button link = new Button {Text = "Link to Event Pay" };
        Button request = new Button {Text = "ask Webpage", TextColor = Color.White };
        Label res = new Label { };
        
        public StartingPage()
        {
            Layout layout = new StackLayout
            {
                Children =
                {
                    link,
                    request,
                    res
                }

                
            };
            

            //Button link = new Button();
            link.Clicked += (sender, args) => {
                Device.OpenUri(new Uri("http://thecircuitlive.com/index.php/events/"));
            };
            link.BackgroundColor = Color.Red;
            request.BackgroundColor = Color.Black;
            Content = layout;

            request.Clicked += (sender, args) =>
            {
                res.Text = "sheet";
            };
        }

        public void webConn()
        {
            
        }

        
    }




}
