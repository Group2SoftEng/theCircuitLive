using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace theCircuitLive
{
    /// <summary>
    /// Portable app
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Portable app driver
        /// </summary>
        public App()
        {
            InitializeComponent();

            MainPage = new theCircuitLive.MainPage();
        }

        /// <summary>
        /// OnStart Method
        /// </summary>
        protected override void OnStart()
        {
            // Handle when your app starts
            string test = "lol";
        }

        /// <summary>
        /// OnSleep Method
        /// </summary>
        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        /// <summary>
        /// OnResume Method
        /// </summary>
        protected override void OnResume()
        {
           
            // Handle when your app resumes
        }
    }
    
}
