using System;
using System.Collections.Generic;

using Xamarin.Forms;


namespace Kuromori
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            ProfileImage.Source = new Uri("https://x1.xingassets.com/assets/frontend_minified/img/users/nobody_m.original.jpg");
        }
    }
}