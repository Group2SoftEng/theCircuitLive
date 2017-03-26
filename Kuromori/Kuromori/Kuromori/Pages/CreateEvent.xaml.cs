using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Kuromori.InfoIO;
using System.Diagnostics;
using Kuromori.DataStructure;

namespace Kuromori
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateEvent : ContentPage
    {
        public EBEvent temp { get; set; }

        public CreateEvent()
        {
            InitializeComponent();

            Task.Run(async () =>
            {
                temp = await JsonRequest.GetEBEventData();
                Device.BeginInvokeOnMainThread(() =>
                {

                });

            });
        }
        public void CreateEventClick(object sender, EventArgs args)
        {


        }

    }
}


