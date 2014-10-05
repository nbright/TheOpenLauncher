using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace TheOpenLauncher {
    class DateTools{
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static long GetUnixTimestampMillis(DateTime date) {
            return (long)(date - UnixEpoch).TotalMilliseconds;
        }

        public static DateTime DateTimeFromUnixTimestampMillis(long millis) {
            return UnixEpoch.AddMilliseconds(millis);
        }

        public static long GetUnixTimestampSeconds(DateTime date) {
            return (long)(date - UnixEpoch).TotalSeconds;
        }

        public static DateTime DateTimeFromUnixTimestampSeconds(long seconds) {
            return UnixEpoch.AddSeconds(seconds);
        }

        public static string GetSimpleDateRepresentation(DateTime date) {
            TimeSpan timeDiff = (DateTime.UtcNow - date);
            if (timeDiff.TotalSeconds < 60) {
                return timeDiff.Seconds + " seconds ago";
            } else if (timeDiff.TotalMinutes < 60) {
                return timeDiff.Minutes + " minutes ago";
            } else if (timeDiff.TotalHours < 24) {
                return timeDiff.Hours + " hours ago";
            } else if (timeDiff.TotalDays < 30) {
                return timeDiff.Days + " days ago";
            } else if (timeDiff.TotalDays < 365) {
                int months = GetApproximateMonthDifference(DateTime.UtcNow, date);
                return months + " months ago";
            } else {
                string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(date.Month);
                return monthName + ", " + date.Year;
            }
        }

        public static int GetApproximateMonthDifference(DateTime date1, DateTime date2) {
            return ((date1.Year - date2.Year) * 12) + date1.Month - date2.Month;
        }
    }
}
