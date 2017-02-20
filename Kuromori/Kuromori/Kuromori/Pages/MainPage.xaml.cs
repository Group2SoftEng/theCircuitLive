using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Kuromori
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();

			this.Detail = new NavigationPage(
				new SignInPage()
			) { 
				BarBackgroundColor = Color.FromHex("#b71a66")
			}; 

			this.Master = new SideNav() { Title = "Cmon" };
        }
    }
}
