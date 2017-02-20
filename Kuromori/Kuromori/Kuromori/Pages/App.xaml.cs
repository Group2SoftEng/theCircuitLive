using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kuromori.DataStructure;
using Kuromori.InfoIO;
using Xamarin.Forms;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms.Xaml;

namespace Kuromori
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
			PostRequest post= new PostRequest();
			post.Send_Post("yippyyy", "dakdjhawd");
            MainPage = new MainPage();
        }

        protected override async void OnStart()
        {
            // Handle when your app starts
        }

    

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
