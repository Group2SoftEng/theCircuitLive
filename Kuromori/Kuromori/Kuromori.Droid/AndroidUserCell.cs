using Kuromori.Droid;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Kuromori;

namespace Kuromori.Droid
{
	internal class AndroidUserCell : LinearLayout, INativeElementView
	{
		public TextView HeadingTextView { get; set; }
		public TextView SubheadingTextView { get; set; }

		public UserCell UserCell { get; private set; }
		public Element Element => UserCell;

		public AndroidUserCell(Context context, UserCell cell) : base(context)
		{
			UserCell = cell;

			var view = (context as Activity).LayoutInflater.Inflate(Resource.Layout.AndroidUserCell, null);
			HeadingTextView = view.FindViewById<TextView>(Resource.Id.Username);
			SubheadingTextView = view.FindViewById<TextView>(Resource.Id.UserId);
			AddView(view);
		}

	}
}