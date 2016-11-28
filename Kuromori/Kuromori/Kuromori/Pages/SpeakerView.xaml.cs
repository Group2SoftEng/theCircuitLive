using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kuromori.DataStructure;
using Xamarin.Forms;

namespace Kuromori.Pages
{
    public partial class SpeakerView : Frame
    {
        public SpeakerView(Speaker speaker)
        {
            InitializeComponent();
            Label speakerName = this.FindByName<Label>("Name");
            Image speakerImage = this.FindByName<Image>("Image");
            Label speakerDesc = this.FindByName<Label>("Description");
            speakerName.Text = speaker.SpeakerName;
            speakerDesc.Text = speaker.SpeakerDescription;

            speakerImage.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    try
                    {
                        Device.OpenUri(new Uri(speaker.SpeakerUrl));
                    }
                    catch (FormatException res)
                    {
                        
                    }
                })
            });

            Device.OnPlatform(null, null, () =>
           {
               speakerName.TextColor = Color.Black;
               speakerDesc.TextColor = Color.Black;
           }, null);

            try
            {
                speakerImage.Source = new Uri(speaker.SpeakerImg);

            }
            catch (FormatException Excep)
            {
                speakerImage.Source = ImageSource.FromFile(("noimage.png"));
            }

        }
    }
}
