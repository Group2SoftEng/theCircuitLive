using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kuromori;
using Kuromori.DataStructure;
using Kuromori.InfoIO;
using Xamarin.Forms;

namespace Kuromori
{
    public partial class ConversationView : ContentView
    {
        public string[] Conversation;
        public ConversationView(string[] conversation)
        {
            InitializeComponent();
            Conversation = conversation;
            foreach (string line in Conversation)
            {
                ViewStack.Children.Add(new Label
                {
                    Text = line
                });
            }
        }
    }
}
