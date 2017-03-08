using System;
using Android;
using Xamarin.Forms;
using Xamarin;
using Kuromori;
using Kuromori.Droid;
using Android;
using Android.Content;
using Android.Views;
using Android.App;
using Android.Renderscripts;
using Xamarin.Forms.Platform.Android;
using System.ComponentModel;


[assembly: ExportRenderer(typeof(PasswordCell), typeof(PasswordCellAndroidRenderer))]
namespace Kuromori.Droid
{
	public class PasswordCellAndroidRenderer : EntryRenderer
	{
		PasswordCell cell;

		protected override Android.Views.View GetCellCore(
			Cell item, Android.Views.View convertView,
			ViewGroup parent,
			Context context)
		{
			var passwordCell = (PasswordCell)item;

			cell = convertView as PasswordCell;

		}

	}
}
