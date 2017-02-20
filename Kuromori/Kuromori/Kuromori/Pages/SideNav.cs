using System;

using Xamarin.Forms;

namespace Kuromori
{
	public class SideNav : ContentPage
	{
		public SideNav()
		{
			Content = new StackLayout
			{
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}

