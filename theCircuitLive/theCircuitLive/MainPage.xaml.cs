using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Xamarin.Forms;

namespace theCircuitLive
{
    /// <summary>
    /// Main Page for the app, which is currentl a masterdetail page
    /// </summary>
    public partial class MainPage : MasterDetailPage
    {
        /// <summary>
        /// Constructor for mainpage
        /// </summary>
        public MainPage()
        {
            InitializeComponent();

            string[] menuStrings =
            {
                "-leave blank-",
                "a page",
                "another page",
                "and another",
                "",
                "",
                "",
                ""
                
            };
            ListView nav = new ListView { ItemsSource = menuStrings, SeparatorColor = Color.FromHex("#FF69B4") };
            this.Master = new ContentPage
            {
                //BackgroundColor = Color.White,
                Title = "help",
                Content = new StackLayout
                {
                    Children =
                       {
                            new BoxView {BackgroundColor = Color.FromHex ("#FF69B4") },
                            nav 
                       }

                }
            };
            //this.Detail = new NavigationPage(new StartingPage()) {BarBackgroundColor = Color.FromHex("#FF69B4") }; //might not be efficient when changing pages
            NavigationPage navpage =  new NavigationPage(new EventPage() {BackgroundColor = Color.FromHex("#ffffff")}) {BarTextColor = Color.White, BarBackgroundColor = Color.FromHex("#ff80bf")};
            navpage.Title = "WOOOOOOORK";
            navpage.BarTextColor = Color.Black;
            
            this.Detail = navpage;
            

            nav.ItemTapped +=  (sender, args) =>
            {
                // call controller classes here
               
            };
            
            
        }
    }

            
            
        

        
    
   /// <summary>
   /// Page you will see when you open the app
   /// </summary>
    public class StartingPage : ContentPage
    {
        /// <summary>
        /// Constructor for starting page
        /// </summary>
        public StartingPage()
        {

            Button link = new Button { WidthRequest = 400 };
            Button req = new Button { WidthRequest = 400 };
            var label = new Label { TextColor = Color.Black };
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



            //this.BackgroundColor = Color.White;

            link.Clicked += (sender, args) => {
                Device.OpenUri(new Uri("http://thecircuitlive.com/index.php/events/"));
            };

            req.Clicked +=  async (sender, args) =>
            {
                
                Events n = await ConnectionManager.GetEventData();
                label.Text = n.EventSet[1].EventSpeakers[0].SpeakerName;
            };
            Content = layout;
        }
        


        
    }

    




}
