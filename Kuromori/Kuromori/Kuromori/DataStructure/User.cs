using System;
using System.Collections;
using Xamarin.Forms;
namespace Kuromori.DataStructure
{
	public class User
	{
		/// <summary>
		/// Gets or sets the name of the user.
		/// </summary>
		/// <value>The name of the user.</value>
		public string UserName { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public Event[] EventsAttending { get; set; }

		/// <summary>
		/// /
		/// </summary>
		public string ProfilePicture { get; set; }

		}
}
