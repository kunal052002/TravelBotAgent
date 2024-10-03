using System.ComponentModel;
using System.Reflection;

namespace TravelBotAgent.Helper
{
    public class Resources
    {
        public enum InitialMessage
        {
            HI,
            hi,
            Hi,
            Hello
        }

        public enum FirstChoice
        {
            [Description("1.Flight Booking")]
            FlightChoice,

            [Description("2.Hotel Booking")]
            HotelChoice,

            [Description("3.Holiday Package")]
            HolidayChoice
        }

        public enum NormalChoices
        {

        }

        public enum Location
        {

        }

        public static string GetEnumDescription(FirstChoice value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }
    }
}
