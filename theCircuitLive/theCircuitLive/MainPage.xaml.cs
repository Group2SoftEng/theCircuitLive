using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Xamarin.Forms;

namespace theCircuitLive
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            
            string[] menuStrings =
            {
                "1",
                "2",
                "3",
                "4",
                "5",
                "6"
            };
            

            ListView list = new ListView
            {
                ItemsSource = menuStrings,
                /**
                 * 
                 * 
                 **/
                
            };
                
            list.BackgroundColor = Color.Black;
            list.SeparatorColor = Color.Blue;
            
            this.Master = new ContentPage
            {
                Title = "help",
                Content = new StackLayout
                {
                    Children =
                        {
                        
                        list
                       }

                }


            };
            this.Detail = new NavigationPage(new StartingPage());
        }
    }

            
            
        

        
    

    public class StartingPage : ContentPage
    {
        public delegate String bob(int x);
        
        public StartingPage()
        {

            Button link = new Button { WidthRequest = 400 };
            Button req = new Button { WidthRequest = 400 };
            var label = new Label { TextColor = Color.White };
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
            NavigationPage.SetHasNavigationBar(this, true);



            this.BackgroundColor = Color.Black;

            link.Clicked += (sender, args) => {
                Device.OpenUri(new Uri("http://thecircuitlive.com/index.php/events/"));
            };

            req.Clicked += async (sender, args) =>
            { 
                ConnectionManager con = new ConnectionManager();
                label.Text =await con.urlToHtml("https://php.radford.edu/~softeng05/sample.php");
            };
            Content = layout;
        }
        


        
    }

    




}
