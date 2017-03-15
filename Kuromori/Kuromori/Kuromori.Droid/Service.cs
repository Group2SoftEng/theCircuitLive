
using System;

using Android.App;
using Android.Content;
using Android.OS;

namespace Kuromori.Droid
{
	[Service(Label = "Service")]
	[IntentFilter(new String[] { "com.yourname.Service" })]
	public class Service : Service
	{
		IBinder binder;

		public override StartCommandResult OnStartCommand(Android.Content.Intent intent, StartCommandFlags flags, int startId)
		{
			// start your service logic here

			// Return the correct StartCommandResult for the type of service you are building
			return StartCommandResult.NotSticky;
		}

		public override IBinder OnBind(Intent intent)
		{
			binder = new ServiceBinder(this);
			return binder;
		}
	}

	public class ServiceBinder : Binder
	{
		readonly Service service;

		public ServiceBinder(Service service)
		{
			this.service = service;
		}

		public Service GetService()
		{
			return service;
		}
	}
}
