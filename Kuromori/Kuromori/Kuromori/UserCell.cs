using System;
using Xamarin.Forms;

namespace Kuromori
{
	public class UserCell : ViewCell
	{
		public static readonly BindableProperty NameProperty =
			BindableProperty.Create("Username", typeof(string), typeof(UserCell), "");


		public string Username
		{
			get { return (string)GetValue(NameProperty); }
			set { SetValue(NameProperty, value); }
		}

			public static readonly BindableProperty IdProperty=
			BindableProperty.Create("UserId", typeof(int), typeof(UserCell),-9999) ;

		public int UserId
		{
			get { return (int)GetValue(IdProperty); }
			set { SetValue(IdProperty, value); }
		}


	}
}
