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
           // InitializeComponent();

			this.Detail = new EventPage() {Title = "alwkjdalkwjd"};
			this.Master = new SideNav() { Title = "Cmon" };
			//this.
        }
    }
}
