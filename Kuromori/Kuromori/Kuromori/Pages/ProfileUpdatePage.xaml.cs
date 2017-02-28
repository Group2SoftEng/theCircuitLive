using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Kuromori.InfoIO;
using System.Diagnostics;
namespace Kuromori
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileUpdatePage : ContentPage
    {
        public ProfileUpdatePage()
        {
            InitializeComponent();
			Debug.WriteLine(ActiveUser.CurrentUser.Id);
        }

        void OnProfileEditClick(object sender, EventArgs args)
        {
			
        }
    }
}

