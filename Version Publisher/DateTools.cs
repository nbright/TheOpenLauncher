using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private static string AppendCount(int count, string unit) {
            string result = count + " " +unit;
            if (count > 1) {
                result = result + "s";
            }
            return result;
        }

        public static string GetSimpleDateRepresentation(DateTime date) {
            TimeSpan timeDiff = (DateTime.UtcNow - date);
            if (timeDiff.TotalSeconds < 60) {
                return AppendCount(timeDiff.Seconds, "second") + " ago";
            } else if (timeDiff.TotalMinutes < 60) {
                return AppendCount(timeDiff.Minutes, "minute") + " ago";
            } else if (timeDiff.TotalHours < 24) {
                return AppendCount(timeDiff.Hours, "hour") + " ago";
            } else if (timeDiff.TotalDays < 30) {
                return AppendCount(timeDiff.Days, "day") + " ago";
            } else if (timeDiff.TotalDays < 365) {
                int months = GetApproximateMonthDifference(DateTime.UtcNow, date);
                return AppendCount(months, "month") + " ago";
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
