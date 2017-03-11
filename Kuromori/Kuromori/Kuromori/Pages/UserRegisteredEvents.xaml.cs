using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kuromori
{
    /// <summary>
    ///   This page is part of one of our imcomplete user stories. It is not going to be tested this iteration
    ///   Its intention is to show events associated with a user
    ///   NOTE: Before proper implementation we need to integrate eventbrite api
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserRegisteredEvents : ContentPage
    {
        public UserRegisteredEvents()
        {
            InitializeComponent();
            RegEventSpkr.Source = new Uri("http://thecircuitlive.com/wp-content/uploads/2016/09/Candi-Cylar-350x350.jpg");
        }
    }
}
