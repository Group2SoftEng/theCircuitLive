using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;

[assembly:ExportRenderer(typeof(Kuromori.MenuTableView), typeof(Kuromori.MenuTableViewRenderer))]
namespace Kuromori
{
	public class MenuTableViewRenderer : TableViewRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<TableView> e)
		{
			base.OnElementChanged(e);

			if (Control == null)
				return;

			var tableView = Control as UITableView;
			tableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
		}
	}
}
