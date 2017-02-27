using System;
namespace Kuromori
{
	public class PostResponseItem
	{
		public string ResponseInfo { get; set; }
		public Boolean ResponseSuccess { get; set; }

		public PostResponseItem() { }

		public PostResponseItem(string res, Boolean success)
		{
			ResponseInfo = res;
			ResponseSuccess = success;

		}

	}
}
