using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SandBox
{
    class CellTest
    {
    }

    public class TestCell : ViewCell
    {
        public static readonly BindableProperty NameProperty = 
            BindableProperty.Create("Name", typeof(string), typeof(TestCell), string.Empty);

        public string Name
        {
            get { return (string) GetValue(NameProperty); }
            set { SetValue(NameProperty, value);}
        }

        public static readonly BindableProperty NumberProperty = 
            BindableProperty.Create("Number", typeof(int), typeof(TestCell), "");

        public int Number
        {
            get { return (int) GetValue(NumberProperty); }
            set { SetValue(NumberProperty, value);}
        }
    }

    public class TestVM
    {
        public string Name { get; set; }
        public int Number { get; set; }
    }


    /// <summary>
    /// THIS DOES NOT WORK FOR SOME REASON ? WHY
    /// </summary>
    public class CellPage : ContentPage
    {
        ListView listView;

        public CellPage()
        {
            listView = new ListView
            {
                ItemsSource = new TestVM[] {new TestVM {Name = "test", Number = 3} },
                ItemTemplate = new DataTemplate(() =>
                {
                    var test = new TestCell();
                    test.SetBinding(TestCell.NameProperty, "Name");
                    test.SetBinding(TestCell.NumberProperty, "Number");
                    return test;
                })
            };

            Content = new StackLayout
            {
                Children = {listView }
            };
        }
    }
}
