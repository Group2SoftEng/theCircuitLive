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
			//post.User_Login(Username.Text, Password.Text);
			post.PostInfo(new List<KeyValuePair<string, string>> {
				new KeyValuePair<string, string>("username", Username.Text),
				new KeyValuePair<string, string>("password", Password.Text)
			}, "http://haydenszymanski.me/softeng05/validate_user.php");
			/*post.PostReqest(new List<KeyValuePair<string, string>>{
				new KeyValuePair<string, string>("username", TryUsername.Text),
				new KeyValuePair<string, string>("password", TryPassword.Text)
			}, "http://haydenszymanski.me/softeng05/validate_user.php").ResponseSuccess;*/
		}
    }
}
