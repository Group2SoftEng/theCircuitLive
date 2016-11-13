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
            this.PushAsync(new WebViewer());
           
        }
    }

    public class WebViewer : ContentPage
    {
        public WebViewer()
        {
            this.Content = new WebView
            {
                Source = "https://msdn.microsoft.com/en-us/library/6kxxabwd.aspx"
            };
        }
    }





}
