using System;
using Xamarin.Forms;

namespace Kuromori
{
	public class Cells
	{
		public static ViewCell GetUsernameCell()
		{
			StackLayout layout = new StackLayout
			{
				Orientation = StackOrientation.Vertical,
				Spacing = 5

			};

			layout.Children.Add(
				new Label { Text = "Username",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			}
			);

			layout.Children.Add(
				new Entry
				{
					IsPassword = false,
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					VerticalOptions = LayoutOptions.Center



				}
			);

			ViewCell cell = new ViewCell
			{
				View = layout
			};

			return cell;

		}
		

		public static ViewCell GetPasswordCell(string text)
		{
			StackLayout layout = new StackLayout
			{
				Orientation = StackOrientation.Vertical,
				Spacing = 5

			};

			layout.Children.Add(
				new Label
				{
					Text = text,
					VerticalOptions = LayoutOptions.Center,
					HorizontalOptions = LayoutOptions.CenterAndExpand
				}
			);

			layout.Children.Add(
				new Entry
				{
					IsPassword = false,
					HorizontalOptions = LayoutOptions.FillAndExpand,
					StyleId="Entry"
				}
			);

			ViewCell cell = new ViewCell
			{
				View = layout
			};

			return cell;

		}

	}
}
