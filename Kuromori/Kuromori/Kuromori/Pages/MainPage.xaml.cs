using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Kuromori.DataStructure;

namespace Kuromori
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
			SideNav.ListView.ItemSelected += OnItemSelected;
        }

		void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var item = e.SelectedItem as SideNavItem;
			if (item != null)
			{
				Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
				SideNav.ListView.SelectedItem = null;
				IsPresented = false;
			}
		}
    }
}
