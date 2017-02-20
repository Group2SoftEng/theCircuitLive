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
			post.Send_Post(Username.Text, Password.Text);
		}
    }
}
