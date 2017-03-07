using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Kuromori
{
	public partial class InputField : ContentView
	{
		public string InputLabel { get; set; }
		public string InputValue { get; set; }

		public InputField()
		{
			InitializeComponent();

		}
	}
}
