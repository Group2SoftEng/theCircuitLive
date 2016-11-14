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
            
            Button link = new Button {WidthRequest = 400};
            Button req = new Button {WidthRequest = 400};
            var label = new Label { TextColor = Color.White };
            link.TextColor = Color.White;
            link.Text = "Link to event page";
            label.FontSize = 15;
            req.Text = "get employers";
           


            label.HorizontalTextAlignment = TextAlignment.Center;


            var layout = new StackLayout();
            link.VerticalOptions = LayoutOptions.Start;
            link.HorizontalOptions = LayoutOptions.CenterAndExpand;
            req.HorizontalOptions = LayoutOptions.CenterAndExpand;
            label.HorizontalOptions = LayoutOptions.CenterAndExpand;
            layout.Children.Add(link);
            layout.Children.Add(req);
            layout.Children.Add(label);
            layout.Spacing = 0;
           
            
            

            this.BackgroundColor = Color.Black;
            
            link.Clicked += (sender, args) => {
                Device.OpenUri(new Uri("http://thecircuitlive.com/index.php/events/"));
            };
            
            req.Clicked += async (sender, args) =>
            {
                
                label.Text = "blah";
                blah l = new blah();

                label.Text =await l.Download();
            };
            Content = layout;
        }

        
    }




}
