using System;
using System.Collections.Generic;
using Kuromori.DataStructure;
using Xamarin.Forms;

namespace Kuromori
{
  /// <summary>
  ///   currently not being test, this is an example of how we're going to structure the sidebar's links in the future
  /// </summary>
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
