﻿using System;
using System.Collections.Generic;
using System.Linq;
using Kuromori.InfoIO;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kuromori
{
	public partial class RegisterPage : ContentPage
	{

		public RegisterPage()
		{
			InitializeComponent();
		}

		void OnNextClick(object sender, EventArgs e)
		{

			if (IsProperUsername())
			{

				if (PasswordsMatch())
				{
					if (IsProperPassword())
					{
						if (UserExists())
						{
							DisplayAlert("Username already exists",
							            "Please retype username","Continue"
							            );
						}

						else
						{
							Debug.WriteLine("succ");
							PostRequest post = new PostRequest();
							post.PostInfo(new List<KeyValuePair<string, string>> {
								new KeyValuePair<string, string>("username", TryUsername.Text),
								new KeyValuePair<string, string>("password", TryPassword.Text)}, 
							              "http://haydenszymanski.me/softeng05/register_user.php");
							Task.Run(async () =>
							{
								ActiveUser.CurrentUser = await EventConnection.GetUserData(new List<KeyValuePair<string, string>> {
									new KeyValuePair<string, string>("username", TryUsername.Text),
									new KeyValuePair<string, string>("password", TryPassword.Text)
								}, "http://haydenszymanski.me/softeng05/get_user.php");
								Device.BeginInvokeOnMainThread(() =>
								{
									Navigation.InsertPageBefore(new ProfileUpdatePage(), Navigation.NavigationStack.First());
									Navigation.PopToRootAsync();
								});
							});


						}
					}
					else 
					{
						DisplayAlert("Improper Password", "Passwords must contain at least 8 characters with" +
						             "at least 1 special character and 1 capital letter", "Continue");
					}
				}

				else
				{
					DisplayAlert("Passwords Do Not Match",
								 "Please make sure passwords match",
								 "Continue");
					TryPassword.Text = "";
				}

            }

			else 
			{
				DisplayAlert("Improper Username", 
				             "Usernames must be 6 to 15 characters long, with no special characters", 
				             "Continue");
				TryUsername.Text = "";
			}

		}

		Boolean IsProperPassword()
		{
			Regex PasswordPattern = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\\$])(?=.{8,})");
			return PasswordPattern.IsMatch(TryPassword.Text);
		}

		Boolean IsProperUsername()
		{
			Regex UsernamePattern = new Regex("^[A-Za-z0-9]{6,15}$");
			return UsernamePattern.IsMatch(TryUsername.Text);
		}

		Boolean UserExists()
		{
			PostRequest post = new PostRequest();
			Debug.WriteLine("UserExist");
			//return post.UserExists(TryUsername.Text, TryPassword.Text);
			return post.PostInfo(new List<KeyValuePair<string, string>>{
				new KeyValuePair<string, string>("username", TryUsername.Text)
			}, "http://haydenszymanski.me/softeng05/user_exists.php").ResponseInfo.Equals("true");
		}

		Boolean PasswordsMatch()
		{
			return TryPassword.Text.Equals(ReTryPassword.Text);
		}
	}
}
