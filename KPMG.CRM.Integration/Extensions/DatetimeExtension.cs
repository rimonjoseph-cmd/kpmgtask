namespace KPMG.CRM.Integration.API.Extensions
{
    public static class DatetimeExtension
    {
        public static DateTime ConvertToUtcDateTime(this string inputDate)
        {
            string[] dateParts = inputDate.Split(' ');
            string[] timeParts = dateParts[4].Split(':');

            int year = int.Parse(dateParts[3]);
            int month = DateTime.ParseExact(dateParts[1], "MMM", System.Globalization.CultureInfo.InvariantCulture).Month;
            int day = int.Parse(dateParts[2]);
            int hour = int.Parse(timeParts[0]);
            int minute = int.Parse(timeParts[1]);
            int second = int.Parse(timeParts[2]);

            DateTime localDateTime = new DateTime(year, month, day, hour, minute, second, DateTimeKind.Unspecified);

            string timeZoneOffset = dateParts[6].Trim('(').Trim(')');
            int offsetHours = int.Parse(timeZoneOffset.Substring(4, 2));
            int offsetMinutes = int.Parse(timeZoneOffset.Substring(7, 2));
            TimeSpan offset = new TimeSpan(offsetHours, offsetMinutes, 0);

            DateTime utcDateTime = TimeZoneInfo.ConvertTimeToUtc(localDateTime, TimeZoneInfo.Local).Add(offset);

            return utcDateTime;
        }
    }
}
