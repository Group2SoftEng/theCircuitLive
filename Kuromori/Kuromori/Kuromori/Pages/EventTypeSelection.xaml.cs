using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Kuromori
{
	public partial class EventTypeSelection : ContentPage
	{
		public EventTypeSelection()
		{
			InitializeComponent();
		}
        void EventBriteHandler(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateEBEvent());
        }
    }
}
