using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kuromori.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageView : ContentView
    {
      
        public ImageView(Uri uri)
        {
            InitializeComponent();
            Image eventImage = this.FindByName<Image>("Image");
            eventImage.Source = uri;
        }
    }
}
