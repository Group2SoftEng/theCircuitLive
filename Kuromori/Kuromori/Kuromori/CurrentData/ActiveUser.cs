using System;
using Kuromori.DataStructure;

namespace Kuromori
{
	public class ActiveUser<T>
	{
		public AccountType CurrentAccountType { get; set; }
		public static T CurrentUser;




	}
}