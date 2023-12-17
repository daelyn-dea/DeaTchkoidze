using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice___1
{
    public static class DateTimeExtension
    {
        public static string DateTimeToString(this DateTime dateTime)
        {
            int year = dateTime.Year;
            int month = dateTime.Month;
            int day = dateTime.Day;
            int hour = dateTime.Hour;
            int minute = dateTime.Minute;
            int second = dateTime.Second;

            string formattedDateTime = $"{year:D4}-{month:D2}-{day:D2} {hour:D2}:{minute:D2}:{second:D2}";

            return formattedDateTime;
        }
        public static bool DateTimeInDiapason(this DateTime dateTime, DateTime startDate, DateTime endDate)
        {
            if (dateTime > startDate && dateTime < endDate)
            {
                return true;
            }
            return false;
        }
        public static int CalculateAge(this DateTime dateTime)
        {
            DateTime currentDate = DateTime.Now;
            int age = currentDate.Year - dateTime.Year;

            // Check if birthday has occurred this year
            if (currentDate.Month < dateTime.Month || (currentDate.Month == dateTime.Month && currentDate.Day < dateTime.Day))
            {
                age--;
            }

            return age;
        }
    }
}
