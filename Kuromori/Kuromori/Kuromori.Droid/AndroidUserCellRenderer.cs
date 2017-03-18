using System;
using System.ComponentModel;
using Android.Content;
using Android.Views;
using Kuromori;
using Kuromori.Droid;
using Xamarin;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(UserCell), typeof(AndroidUserCellRenderer))]
namespace Kuromori.Droid
{
	public class AndroidUserCellRenderer : ViewCellRenderer
	{
		AndroidUserCell cell;
		public AndroidUserCellRenderer()
		{
		}

		protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, ViewGroup parent, Context context)
		{
			var userCell = (UserCell)item;

			cell = convertView as AndroidUserCell;
			if (cell == null)
			{
				cell = new AndroidUserCell(context, userCell);
			}
			else
			{
				cell.UserCell.PropertyChanged -= OnAndroidUserCellPropertyChanged;
			}

			userCell.PropertyChanged += OnAndroidUserCellPropertyChanged;

			return cell;

		}

		void OnAndroidUserCellPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			var usercell = (UserCell)sender;
			if (e.PropertyName == UserCell.NameProperty.PropertyName)
			{
				cell.HeadingTextView.Text = usercell.Username;
			}
			else if (e.PropertyName == UserCell.IdProperty.PropertyName)
			{
				cell.SubheadingTextView.Text = usercell.UserId.ToString();
			}

		}
	}
}
