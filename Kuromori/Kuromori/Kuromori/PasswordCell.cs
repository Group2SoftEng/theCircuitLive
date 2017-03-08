using System;
using System.Collections;
using System.Reflection;
using System.Runtime;
using System.Linq.Expressions;
using Xamarin.Forms;
using System.Linq;
namespace Kuromori
{
	public class PasswordCell : EntryCell
	{
		public static readonly BindableProperty IsPasswordProperty =
			BindableProperty.Create(
				"IsPassword",
				typeof(bool),
				typeof(PasswordCell),
				"");

		public bool IsPassword
		{
			get { return (bool)GetValue(IsPasswordProperty); }
			set { SetValue(IsPasswordProperty, value); }
		}
	}
}
