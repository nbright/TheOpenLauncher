using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace TheOpenLauncher {
    class VersionFormatter {
        public static string ToString(double version) {
            NumberFormatInfo info = new NumberFormatInfo();
            info.NumberDecimalSeparator = ".";
            return version.ToString(".################", info);
        }

        public static double FromString(string version) {
            NumberFormatInfo info = new NumberFormatInfo();
            info.NumberDecimalSeparator = ".";
            return Double.Parse(version, info);
        }
    }
}
