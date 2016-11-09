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
            this.PushAsync(new StartingPage());
           
        }

        
    }

    public class StartingPage : ContentPage
    {
        public StartingPage()
        {
            var layouts = new Grid();
            
            
            Content = layouts;
            
           
            
            
        }

        public ContentView WebPage ()
        {
            var web = new WebView
            {
                Source = "https://msdn.microsoft.com/en-us/library/6kxxabwd.aspx"

            };
            return new ContentView { Content = web };
        }
    }




}
