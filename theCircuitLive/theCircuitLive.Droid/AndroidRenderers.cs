using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using theCircuitLive;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using CustomRenderer.Droid;

[assembly: ExportRenderer(typeof(TestCell), typeof(NativeAndroidCellRenderer))]
namespace CustomRenderer.Droid
{
    public class NativeAndroidCellRenderer : ViewCellRenderer
    {
        protected override Android.Views.View GetCellCore(Xamarin.Forms.Cell item, Android.Views.View convertView, ViewGroup parent, Context context)
        {
            var x = (TestCell)item;
            
            var view = convertView;

            if (view == null)
            {
                // no view to re-use, create new
                view = (context as Activity).LayoutInflater.Inflate(CustomRenderer.Droid.Resource.Layout.NativeAndroidCell, null);
            }

            view.FindViewById<TextView>(Resource.Id.Text1).Text = x.Name;   


            return view;
        }
    }
}