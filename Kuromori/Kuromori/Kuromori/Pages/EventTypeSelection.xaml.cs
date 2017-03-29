using System;
using System.Collections.Generic;
using Kuromori.DataStructure;

using Xamarin.Forms;

namespace Kuromori
{
	public partial class EventTypeSelection : ContentPage
	{
		User User;
		public EventTypeSelection(User user)
		{
			InitializeComponent();
			User = user;
		}

		void NonEventBriteHandler(object sender, EventArgs e)
		{
			Navigation.PushAsync(new CreateEvent(User));
		}
	}
}
