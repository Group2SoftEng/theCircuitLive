using System;
using System.Collections.Generic;

using Kuromori.DataStructure;
using Xamarin.Forms;

namespace Kuromori
{
	public partial class NonOwnedEventPage : ContentPage
	{
		public NonOwnedEventPage(Event ev)
		{
			InitializeComponent();
			Layout.Children.Add(new EventView(ev));

		}
	}
}
