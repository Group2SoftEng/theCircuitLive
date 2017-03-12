using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Kuromori
{
	public partial class AdminPage : ContentPage
	{
		public AdminPage()
		{
			InitializeComponent();
			Participant.ItemsSource = new TextCell[] {
				new TextCell{Text = "Name : Bill", Detail = "Id : 9"},
				new TextCell{Text = "Name : Bill", Detail = "Id : 9"},
				new TextCell{Text = "Name : Bill", Detail = "Id : 9"},
				new TextCell{Text = "Name : Bill", Detail = "Id : 9"},
				new TextCell{Text = "Name : Bill", Detail = "Id : 9"},
				new TextCell{Text = "Name : Bill", Detail = "Id : 9"},
				new TextCell{Text = "Name : Bill", Detail = "Id : 9"},
				new TextCell{Text = "Name : Bill", Detail = "Id : 9"},
				new TextCell{Text = "Name : Bill", Detail = "Id : 9"},
				new TextCell{Text = "Name : Bill", Detail = "Id : 9"},
				new TextCell{Text = "Name : Bill", Detail = "Id : 9"},
				new TextCell{Text = "Name : Bill", Detail = "Id : 9"},
			};

			Organizer.ItemsSource = new TextCell[] {
				new TextCell{Text = "Name : Bill", Detail = "Id : 9"},
				new TextCell{Text = "Name : Bill", Detail = "Id : 9"},
				new TextCell{Text = "Name : Bill", Detail = "Id : 9"},
				new TextCell{Text = "Name : Bill", Detail = "Id : 9"},
				new TextCell{Text = "Name : Bill", Detail = "Id : 9"},
				new TextCell{Text = "Name : Bill", Detail = "Id : 9"},
				new TextCell{Text = "Name : Bill", Detail = "Id : 9"},
				new TextCell{Text = "Name : Bill", Detail = "Id : 9"},
			};


		}
	}

}
