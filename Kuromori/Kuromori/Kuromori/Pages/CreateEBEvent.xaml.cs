﻿using System;
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
    public partial class CreateEBEvent : ContentPage
    {
       // User User;

        public CreateEBEvent(/*User user*/)
        {
            InitializeComponent();

        }
        public void OnImportClick(object sender, EventArgs args)
        {
            Task.Run(async () =>
            {
                EBEvent ev = await HttpUtils.GetEBEventData(EventID.Text);
                Device.BeginInvokeOnMainThread(() =>
                {
                    Title.Text = ev.NameText;
                   
                });
            });


        }


    }
}
