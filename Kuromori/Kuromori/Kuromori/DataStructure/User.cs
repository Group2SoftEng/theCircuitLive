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
		public string Id { get; set; }

		public string UserName { get; set; }

		public string Password { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Email { get; set; }

		public string ProfilePicture { get; set; }

		public string State { get; set; }

		public string PhoneNumber { get; set; }

		public string Zip { get; set; }

		public string Address { get; set; }

		public string AboutMe { get; set; }

		public string City { get; set; }

		public Event[] EventsAttending { get; set; }

	}
}
