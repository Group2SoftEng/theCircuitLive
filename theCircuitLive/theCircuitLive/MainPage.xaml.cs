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
            
            int[] nums =
            {
                1,
                2,
                3,
                4,
                5,
                6
            };
            TextCell[] k =
            {
                new TextCell {TextColor = Color.Blue, DetailColor = Color.Green
                , Text = "hi", Detail ="by"}
            };

            ListView list = new ListView
            {
                ItemsSource = nums,
                
                
            };
            
            ListView list2 = new ListView
            {
                ItemsSource = nums
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
                blah l = new blah();
                label.Text =await l.Download();
            };
            Content = layout;
        }
        


        
    }

    public class CustomCell : ViewCell
    {
        public CustomCell()
        {
            //instantiate each of our views
            var image = new Image();
            StackLayout cellWrapper = new StackLayout();
            StackLayout horizontalLayout = new StackLayout();
            Label left = new Label();
            Label right = new Label();

            //set bindings
            left.SetBinding(Label.TextProperty, "title");
            right.SetBinding(Label.TextProperty, "subtitle");
            image.SetBinding(Image.SourceProperty, "image");

            //Set properties for desired design
            cellWrapper.BackgroundColor = Color.FromHex("#eee");
            horizontalLayout.Orientation = StackOrientation.Horizontal;
            right.HorizontalOptions = LayoutOptions.EndAndExpand;
            left.TextColor = Color.FromHex("#f35e20");
            right.TextColor = Color.FromHex("503026");

            //add views to the view hierarchy
            horizontalLayout.Children.Add(image);
            horizontalLayout.Children.Add(left);
            horizontalLayout.Children.Add(right);
            cellWrapper.Children.Add(horizontalLayout);
            View = cellWrapper;
        }
    }




}
