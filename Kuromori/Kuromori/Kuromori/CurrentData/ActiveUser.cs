using System;
using Kuromori.DataStructure;

namespace Kuromori
{
	public class ActiveUser
	{
		public ActiveUser()
		{
		}

		public static User CurrentUser { get; set; }

	}
}
