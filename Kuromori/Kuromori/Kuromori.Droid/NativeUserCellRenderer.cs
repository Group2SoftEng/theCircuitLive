using System;
using System.ComponentModel;
using Android.Content;
using Kuromori;
using Xamarin.Forms.Platform.Android;
using Kuromori.Droid;
using Xamarin.Forms;
using Android.Views;
using Android.Graphics;

[assembly: ExportRenderer(typeof(UserCell), typeof(NativeUserCellRenderer))]
namespace Kuromori.Droid
{
	public class NativeUserCellRenderer : ViewCellRenderer
	{
		
		public NativeUserCellRenderer()
		{
		}
	}
}
