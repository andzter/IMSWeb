namespace System
{
    public static class DateTimeExtension
    {
        #region Public Static Methods

        /// <summary>
        /// Convert DateTime object from UTC to local.
        /// </summary>
        /// 
        /// <param name="timeZoneName">
        /// The time zone name value.
        /// </param>
        /// 
        /// <returns>
        /// The result DateTime object.
        /// </returns>
        public static DateTime ConvertFromUtc(this DateTime source, string timeZoneName)
        {
            var zone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneName);

            return TimeZoneInfo.ConvertTimeFromUtc(source, zone);
        }

        /// <summary>
        /// Convert DateTime object from local to UTC.
        /// </summary>
        /// 
        /// <param name="timeZoneName">
        /// The time zone name value.
        /// </param>
        /// 
        /// <returns>
        /// The result DateTime object.
        /// </returns>
        public static DateTime ConvertToUtc(this DateTime source, string timeZoneName)
        {
            var zone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneName);

            return TimeZoneInfo.ConvertTimeToUtc(source, zone);
        }

        /// <summary>
        /// Get DateTime object with local time zone.
        /// </summary>
        /// 
        /// <param name="timeZoneName">
        /// The time zone name value.
        /// </param>
        /// 
        /// <returns>
        /// The result DateTime object.
        /// </returns>
        public static DateTime Now(string timeZoneName)
        {
            var zone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneName);

            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, zone);
        }

        #endregion  // Public Static Methods
    }
}
