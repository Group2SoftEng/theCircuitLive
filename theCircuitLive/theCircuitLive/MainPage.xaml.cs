using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace theCircuitLive
{
    public partial class MainPage : NavigationPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BackgroundColor = Color.Black;
            this.PushAsync(new StartingPage());
           
        }

        
    }

    public class StartingPage : ContentPage
    {
        public StartingPage()
        {
            this.BackgroundColor = Color.Black;
            Content = this.GridLay();
            
        }

        public ContentView WebPage ()
        {
            var web = new WebView
            {
                Source = "https://msdn.microsoft.com/en-us/library/6kxxabwd.aspx"
                
            };
            return new ContentView { Content = web };
        }

        public Grid GridLay()
        {
            Grid grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });

            
            var page1 = WebPage();
            var page2 = WebPage();
            var page3 = WebPage();
            var page4 = WebPage();
            var page5 = WebPage();
            var page6 = WebPage();

            grid.Children.Add(page1, 0, 0);
            grid.Children.Add(page2, 0, 1);
            grid.Children.Add(page3, 1, 0);
            grid.Children.Add(page4, 1, 1);
            grid.Children.Add(page5, 0, 2);
            grid.Children.Add(page6, 2, 0);

            Grid.SetColumnSpan(page5, 3);
            Grid.SetRowSpan(page6, 3);
            
            return grid;
        }
    }




}
