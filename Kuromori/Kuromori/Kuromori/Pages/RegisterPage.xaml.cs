using System;
using System.Collections.Generic;
using System.Linq;
using Kuromori.InfoIO;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Kuromori.DataStructure;
using Kuromori;

namespace Kuromori
{
	public partial class RegisterPage : ContentPage
	{
		public User ActiveUser { get; set; } // Initialized on successfull credentials

		public RegisterPage()
		{
			InitializeComponent();

		}

		/// <summary>
		/// Handles all validation of Credentials for sign up
		/// </summary>
		/// <returns>The credentials.</returns>
		public CredentialInformation ValidateCredentials()
		{
			CredentialInformation CredInfo = new CredentialInformation();
			if (!IsProperUsername())
				CredInfo.Errors.Add("Invalid Username");
			if (!PasswordsMatch())
				CredInfo.Errors.Add("Passwords do not match");
			if (!IsProperPassword())
				CredInfo.Errors.Add("Password must have 1 uppercase and special character and be 8 letters long");
			if (UserExists())
				CredInfo.Errors.Add("Username already exists");
			if (CredInfo.IsValid())
			{
				string _temp = HttpUtils.PostInfo(new List<KeyValuePair<string, string>> {
					new KeyValuePair<string, string>("username", TryUsername.Text),
					new KeyValuePair<string, string>("user_password", TryPassword.Text)
				}, "http://haydenszymanski.me/softeng05/register_participant.php").ResponseInfo;
			}
			return CredInfo;
		}

		/// <summary>
		/// Credential information.
		/// Class that is used 
		/// </summary>
		public class CredentialInformation
		{
			public List<string> Errors { get; set; }

			public CredentialInformation() 
			{
				Errors = new List<string>();
			}

			public bool IsValid()
			{
				return (Errors.Count == 0);
			}

			public string ErrorsAsString()
			{
				string errorString = "";
				foreach (string error in Errors)
				{
					errorString += error + "\n";
				}
				return errorString;

			}
		}

	    /// <summary>
	    ///   When the next button is clicked, we run all the credentials through to see if the meet our ideal criteria for a properly
	    ///   formed set of credentials.
	    ///   Upon success we update the database with the new user and the local current user static fields
	    /// </summary>
		void OnNextClick(object sender, EventArgs e)
		{
			CredentialInformation CredInfo = ValidateCredentials();
			if (!CredInfo.IsValid())
			{
				DisplayAlert("Error",
							 CredInfo.ErrorsAsString(),
							 "Continue");
			}
			else
			{
				Task.Run(async () =>
				{
					ActiveUser = await HttpUtils.GetJsonInfo<User>(
						new List<KeyValuePair<string, string>> {
						new KeyValuePair<string, string>("username", TryUsername.Text),
						new KeyValuePair<string, string>("user_password", TryPassword.Text)
					}, "http://haydenszymanski.me/softeng05/get_user.php");
					Device.BeginInvokeOnMainThread(() =>
					{
						Navigation.InsertPageBefore(new ProfileUpdatePage(ActiveUser),
													Navigation.NavigationStack.First());
						Navigation.PopToRootAsync();
					});

				});
				
			}


		}

		void OnCancelClick(object sender, EventArgs e)
		{
			Navigation.PopAsync();
		}

	    /// <summary>
	    ///   Check to see if the current password is properly formed
	    /// </summary>
		Boolean IsProperPassword()
		{
			Regex PasswordPattern = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\\$])(?=.{8,})");
			return PasswordPattern.IsMatch(TryPassword.Text);
		}

	    /// <summary>
	    ///   Check to see if the current username is properly formed
	    /// </summary>
		Boolean IsProperUsername() 
		{
			Regex UsernamePattern = new Regex("^[A-Za-z0-9]{6,15}$");
			return UsernamePattern.IsMatch(TryUsername.Text);
		}


	    /// <summary>
	    ///   Check to see if the username already exists in the database
	    /// </summary>
		Boolean UserExists()
		{
			Debug.WriteLine("UserExist");
			//return post.UserExists(TryUsername.Text, TryPassword.Text);
			return !(HttpUtils.PostInfo(new List<KeyValuePair<string, string>>{
				new KeyValuePair<string, string>("username", TryUsername.Text)
			}, "http://haydenszymanski.me/softeng05/get_user_type.php").ResponseInfo.Equals("none"));
		}

	    /// <summary>
	    ///   Check to see if the passwords match
	    /// </summary>
		Boolean PasswordsMatch()
		{
			return TryPassword.Text.Equals(ReTryPassword.Text);
		}
	}
}
