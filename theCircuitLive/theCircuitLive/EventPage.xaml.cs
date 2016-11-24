using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Xamarin.Forms;
using Xamarin;

namespace theCircuitLive
{
    public partial class EventPage : ContentPage
    {
        public EventPage()
        {
            InitializeComponent();
            var lay = new StackLayout();
            ListView x = new ListView();

            Event[] test;
            Task.Run(() =>
            {
                test = EventInfo.LoadEvents().Result;
                Device.BeginInvokeOnMainThread(() =>
                {
                    foreach (EventView v in EventInfo.GetCards(test))
                    {
                        lay.Children.Add(v);
                    }

                });
            });




            EventCell t = new EventCell();



            ScrollView scroll = new ScrollView();
            scroll.Content = lay;
            this.Content = scroll;
            //LoadEvents();
        }
    }

    /// <summary>
        /// This cell contains all the info for a single event to be displayed on the event page
        /// TODO: Implement EventCell
        /// </summary>
        public class EventCell : ViewCell
        {
            public static readonly BindableProperty EventIdProperty = 
                BindableProperty.Create("EventId", typeof(EventCell), typeof(int), "");


            public int EventId
            {
                get { return (int)GetValue (EventIdProperty); }
                set { SetValue(EventIdProperty, value); }
            }


        /// <summary>
        /// Event Title Property
        /// </summary>
        public static readonly BindableProperty EventTitleProperty =
                BindableProperty.Create("EventTitle", typeof(string), typeof(EventCell), "");

            /// <summary>
            /// Event Topic Property
            /// </summary>
            public static readonly BindableProperty EventTopicProperty = 
                BindableProperty.Create("EventTopic", typeof(string), typeof(EventCell), "");

            /// <summary>
            /// Event Image Property TODO: IF image type doesnt work find another type to use
            /// </summary>
            public static readonly BindableProperty EventImageProperty = 
                BindableProperty.Create("EventImage", typeof(string), typeof(EventCell),  "" );

            /// <summary>
            /// Event Description Property
            /// </summary>
            public static readonly BindableProperty EventDescriptionProperty =
                BindableProperty.Create("EventImage", typeof(string), typeof(EventCell), "");

            /// <summary>
            /// Event Date Property
            /// </summary>
            public static readonly BindableProperty EventDateProperty = 
                BindableProperty.Create("EventDate", typeof(string), typeof(EventCell), "");

            /// <summary>
            /// Event Speakers Property
            /// </summary>
            public static readonly BindableProperty EventSpeakersProperty =
                BindableProperty.Create("EventSpeakers", typeof(Speaker[]), typeof(EventCell), "");



            /// <summary>
            /// get/set Event Title in the EventCell
            /// </summary>
            public string EventTitle 
            {
                get { return (string) GetValue(EventTitleProperty); }
                set { SetValue(EventTitleProperty, value);}
                
            }

            /// <summary>
            /// get/set Event Topic in the EventCell
            /// </summary>
            public string EventTopic
            {
                get { return (string) GetValue(EventTopicProperty); }
                set { SetValue(EventTopicProperty, value);}
            }

            /// <summary>
            /// get/set event image in the EventCell
            /// </summary>
            public string EventImage
            {
                get { return (string) GetValue(EventImageProperty); }
                set { SetValue(EventImageProperty, value);}
            }

            /// <summary>
            /// get/set Event Description for event in the EventCell
            /// </summary>
            public string EventDescription
            {
                get { return (string) GetValue(EventDescriptionProperty); }
                set { SetValue(EventDescriptionProperty, value);}
            }

            /// <summary>
            /// get/set Event Date for event in the EventCell
            /// </summary>
            public string EventDate
            {
                get { return (string) GetValue(EventDateProperty); }
                set { SetValue(EventDateProperty, value);}
            }

            /// <summary>
            /// get/set Event Speakers for event int the EventCell
            /// </summary>
            public Speaker[] EventSpeakers
            {
                get { return (Speaker[]) GetValue(EventSpeakersProperty); }
                set { SetValue(EventSpeakersProperty, value);}
            }


            /// <summary>
            /// Constructor for EventCell
            /// </summary>
           
        }
        

       /// <summary>
       /// undergoing deprecation 
       /// TODO: Replace this with EventCell
       /// </summary>
        public class EventView : ContentView
        {
            public EventView(string eventName, string eventDesc)
            {
                var grid = new Grid();
                grid.RowDefinitions.Add(new RowDefinition() {Height = new GridLength(2, GridUnitType.Star),});
                grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(2, GridUnitType.Star) });
                grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(2, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition() {Width = new GridLength(1, GridUnitType.Star)});
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

                grid.Children.Add(new BoxView() {BackgroundColor = Color.Fuchsia}, 0, 0);
                grid.Children.Add(new BoxView() {BackgroundColor = Xamarin.Forms.Color.Fuchsia}, 2, 0);
                
                grid.Children.Add(new Label() {Text = eventName, HorizontalTextAlignment = TextAlignment.Center, FontSize = 20}, 1, 0);
                grid.Children.Add(new Label() {Text = eventDesc, HorizontalTextAlignment = TextAlignment.Center}, 1, 1);
                Content = grid;




            }
        }

        public class EventList : ContentPage
        {
            private ListView eventList;


            public EventList()
            {

                eventList = new ListView
                {
                    //ItemsSource = ConnectionManager.GetEventData().Result.getList(),
                    ItemsSource = new Events() {EventSet = new Event[] {new Event(2) }}.getList(),
                    ItemTemplate = new DataTemplate(() =>
                    {

                        var aventCell = new EventCell();
                        aventCell.SetBinding(EventCell.EventIdProperty, "EventId");
                        



                        return aventCell;
                    })
                };
                Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);
                Content = new StackLayout
                {
                    Children = {

                    new Label { Text = "Xamarin.Forms native cell", HorizontalTextAlignment = TextAlignment.Center },
                    eventList
                    }
                };

                
            }



            //  Content = eventList;
        }
        




    
}
