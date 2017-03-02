﻿using Kuromori.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Kuromori.InfoIO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;

namespace Kuromori
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventPage : ContentPage
    {
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        public Events temp { get; set; }
=======
        /// <summary>
        ///   This page is a container for the event cards that will be shown on the screen
        /// </summary>
>>>>>>> Stashed changes
=======
        /// <summary>
        ///   This page is a container for the event cards that will be shown on the screen
        /// </summary>
>>>>>>> Stashed changes
        public EventPage()
        {
            StackLayout layout = new StackLayout();
            InitializeComponent();
            ScrollView scroll = this.FindByName<ScrollView>("scroll");
            Debug.WriteLine(scroll.ScrollY);
            this.FindByName<StackLayout>("Layout");

            Task.Run(async() =>
            {
                temp = await EventConnection.GetEventData();
                EventInformation.CurrentEvents = temp.EventSet;
                Device.BeginInvokeOnMainThread(() =>
                {
                    foreach (Event ev in EventInformation.CurrentEvents)
                    {
                       layout.Children.Add(new EventView(ev));
                    }
                });
            });

        }
    }
}
