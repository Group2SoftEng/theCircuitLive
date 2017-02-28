using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kuromori
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserRegisteredEvents : ContentPage
    {
        public UserRegisteredEvents()
        {
            InitializeComponent();
            RegEventSpkr.Source = new Uri("http://thecircuitlive.com/wp-content/uploads/2016/10/theCiruit-IG-March_web.jpg");
        }
    }
}
