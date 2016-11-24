using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            lay.Spacing = 30;
            lay.Padding = 10;
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




            //var t = new EventCell();



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
                BindableProperty.Create("EventId", typeof(int), typeof(EventCell), "");


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
        /// get/set Event Title in the EventCell
        /// </summary>
        public string EventTitle
        {
            get { return (string)GetValue(EventTitleProperty); }
            set { SetValue(EventTitleProperty, value); }

        }


        

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


            
           
        }
        

       /// <summary>
       /// undergoing deprecation 
       /// TODO: Replace this with EventCell
       /// </summary>
        public class EventView : ContentView
        {
            public EventView(string eventName, string eventDesc, string eventDate)
            {
                var grid = new Grid();
                grid.RowDefinitions.Add(new RowDefinition() {Height = new GridLength(2, GridUnitType.Star),});
                grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(2, GridUnitType.Star) });
                grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(2, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition() {Width = new GridLength(1, GridUnitType.Star)});
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

                Frame TitleFrame = new Frame() {Content = new Label() {Text = "Topic: " + eventName, HorizontalTextAlignment = TextAlignment.Center, FontSize = 20}, BackgroundColor = Color.FromHex("#ff80bf")};
                Frame DateFrame = new Frame() { Content = new Label() {Text = eventDate, TextColor = Color.Black, HorizontalTextAlignment  = TextAlignment.Center, FontSize = 20},  BackgroundColor = Color.White};
                Frame DescFrame = new Frame() { Content = new Label() { Text = eventDesc, HorizontalTextAlignment = TextAlignment.Start},  BackgroundColor = Color.Gray};
                
                grid.Children.Add(TitleFrame, 0, 1);
                grid.Children.Add(DateFrame, 0, 0);
                grid.Children.Add(DescFrame, 0, 2);
                Grid.SetColumnSpan(DateFrame, 3);
                Grid.SetColumnSpan(TitleFrame, 3);
                Grid.SetColumnSpan(DescFrame, 3);

                grid.RowSpacing = 0;
                grid.ColumnSpacing = 0;

                
                //grid.Children.Add(new Label() {Text = eventDesc, HorizontalTextAlignment = TextAlignment.Center}, 0, 1);
                
                grid.BackgroundColor= Color.White;
                Content = new Frame() {Content = grid, BackgroundColor = Color.Black, Padding = 2};




            }
        }

        public class EventList : ContentPage
        {
            private ListView eventList;


            public EventList()
            {
                
                Task.Run(() =>
                {
                    Event[] temp = ConnectionManager.GetEventData().Result.EventSet;
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        //Debug.WriteLine(temp[0].EventId);
                        eventList = new ListView
                        {

                            ItemsSource = temp.ToList(),

                            ItemTemplate = new DataTemplate(() =>
                            {

                                var aventCell = new EventCell();
                                //aventCell.SetBinding(EventCell.EventIdProperty, "EventId");
                                aventCell.SetBinding(EventCell.EventTitleProperty, "EventTitle");
                                aventCell.SetBinding(EventCell.EventImageProperty, "EventImg");
                                aventCell.SetBinding(EventCell.EventTopicProperty, "EventTopic");
                                aventCell.SetBinding(EventCell.EventDateProperty, "EventDate");
                                aventCell.SetBinding(EventCell.EventDescriptionProperty, "EventDesceription");
                                aventCell.SetBinding(EventCell.EventSpeakersProperty, "EventSpeakers");



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
                    });
                });
                
               
                
            }



            //  Content = eventList;
        }
        




    
}
