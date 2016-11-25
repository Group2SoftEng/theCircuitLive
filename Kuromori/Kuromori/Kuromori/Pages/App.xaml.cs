using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kuromori.DataStructure;
using Kuromori.InfoIO;
using Xamarin.Forms;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Kuromori
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Kuromori.MainPage();
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
