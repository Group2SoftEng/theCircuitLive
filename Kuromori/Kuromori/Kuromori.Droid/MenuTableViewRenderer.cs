using System;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Kuromori;
using Kuromori.Droid;
using Android.Views;
using Android.Graphics;

[assembly: ExportRenderer(typeof(Kuromori.MenuTableView), typeof(Kuromori.Droid.MenuTableViewRenderer))]
namespace Kuromori.Droid
{
	public class MenuTableViewRenderer : TableViewRenderer
	{
		private bool _firstElementAdded = false;

		protected override void OnElementChanged(ElementChangedEventArgs<TableView> e)
		{
			base.OnElementChanged(e);

			if (Control == null)
				return;

			var listView = Control as global::Android.Widget.ListView;
			listView.DividerHeight = 0;


			listView.SetFooterDividersEnabled(false);
			listView.SetHeaderDividersEnabled(false);
			listView.Alpha = 1;
			listView.Divider = new NoDivider();
			if (Control == null)
				return;

			listView.ChildViewAdded += (sender, args) =>
			{
				if (!_firstElementAdded)
				{
					args.Child.Visibility = ViewStates.Gone;
					_firstElementAdded = true;
				}

			};


		}

	}
	public class NoDivider : Android.Graphics.Drawables.Drawable
	{
		public override int Opacity
		{
			get
			{
				return 0;
			}
		}

		public override void Draw(Canvas canvas)
		{
			string n;
		}

		public override void SetAlpha(int alpha)
		{
			string n;
		}

		public override void SetColorFilter(ColorFilter colorFilter)
		{
			string n;
		}
	}
}
