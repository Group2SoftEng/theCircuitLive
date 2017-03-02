using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Kuromori
{
  /// <summary>
  /// This is a testing frame that doesn't have any effect on the solution, so no testing is needed
  /// </summary>
	public partial class CardView : Frame
	{
		public CardView()
		{
			Padding = 0;
			if (Device.OS == TargetPlatform.iOS)
			{
				HasShadow = false;
				OutlineColor = Color.Transparent;
				BackgroundColor = Color.Transparent;
			}
		}
	}
}
