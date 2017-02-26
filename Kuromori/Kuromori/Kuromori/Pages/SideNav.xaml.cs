using System;
using System.Collections.Generic;
using Kuromori.DataStructure;
using Xamarin.Forms;

namespace Kuromori
{
	public partial class SideNav : ContentPage
	{
		public ListView ListView { get { return listView; } }

		public SideNav()
		{
			InitializeComponent();

			var SideNavItems = new List<SideNavItem>();
			SideNavItems.Add(new SideNavItem
			{
				Title = "Profile",
				IconSource = "",
				TargetType = typeof(EventPage)
			});

			listView.ItemsSource = SideNavItems;
		}
	}
}
