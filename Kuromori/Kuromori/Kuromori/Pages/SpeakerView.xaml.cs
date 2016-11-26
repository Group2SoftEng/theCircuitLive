using System;
using System.Collections.Generic;
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

            try
            {
                speakerImage.Source = new Uri(speaker.SpeakerImg);

            }
            catch (FormatException test)
            {
                speakerImage.Source = ImageSource.FromFile(("noimage.png"));
            }

        }
    }
}
