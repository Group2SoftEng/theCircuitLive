using System;
using System.Globalization;
using System.Threading.Tasks;
using Kuromori.DataStructure;
using Kuromori.InfoIO;
using Java.Interop;

namespace Kuromori.DataAdapters
{
    /// <summary>
    /// Utility classes for events that help for formatting, or offloading work that would be done in the 
    /// viewmodel
    /// </summary>
    public static class EventAdapter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Export("Task")]
        public static async Task<Event[]> LoadEvents()
        {
            Events events = await EventConnection.GetEventData();
            return events.EventSet;
        }

        [Export("ConvertDate")]
        public static string ConvertDate(string date)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            string monthNum = System.DateTime.ParseExact(date, "yyyy-MM-dd", provider).ToString("MM");
            string month = "";
            switch (monthNum)
            {
                case "01":
                    month += "January";
                    break;
                case "02":
                    month += "February";
                    break;
                case "03":
                    month += "March";
                    break;
                case "04":
                    month += "April";
                    break;
                case "05":
                    month += "May";
                    break;
                case "06":
                    month += "June";
                    break;
                case "07":
                    month += "July";
                    break;
                case "08":
                    month += "August";
                    break;
                case "09":
                    month += "September";
                    break;
                case "10":
                    month += "October";
                    break;
                case "11":
                    month += "November";
                    break;
                case "12":
                    month += "December";
                    break;
            }

            return month + " " + DateTime.ParseExact(date, "yyyy-MM-dd", provider).ToString("dd, yyyy");
            
        }
    }
}
