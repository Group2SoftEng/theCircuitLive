using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Kuromori.InfoIO;

namespace Kuromori
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignInPage : ContentPage
    {
        public SignInPage()
        {
            InitializeComponent();
            
        }

		void OnRegisterClick(object sender, EventArgs args)
		{
			PostRequest post = new PostRequest();
			post.User_Login(Username.Text, Password.Text);
		}
    }
}
