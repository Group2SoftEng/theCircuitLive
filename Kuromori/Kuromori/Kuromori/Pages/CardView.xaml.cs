using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Kuromori
{
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
