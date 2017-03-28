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

namespace Kuromori.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImportEventSelection : ContentPage
    {
        public EBEvent temp { get; set; }

        public ImportEventSelection()
        {
            InitializeComponent();

        }

        public void OnImportClick(object sender, EventArgs args)
        {
            Task.Run(async () => // body runs asynchronously 
            {
                temp = await HttpUtils.GetEBEventData(EventID.Text);
                Device.BeginInvokeOnMainThread(() => // runs body after await operator
                {
                    
                });
            });

            Debug.WriteLine(HttpUtils.PostInfo(new List<KeyValuePair<string, string>> {
                new KeyValuePair<string, string>("event_date", temp.StartLocal),
                new KeyValuePair<string, string>("event_title", temp.NameText),
                new KeyValuePair<string, string>("event_desc", temp.DescriptionText),
                new KeyValuePair<string, string>("event_img", temp.LogoUrl),
                new KeyValuePair<string, string>("event_url", temp.Url),
            }, "http://haydenszymanski.me/softeng05/create_event.php").ResponseSuccess);
        }
    }
}
