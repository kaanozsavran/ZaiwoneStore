using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zaiwoneproje
{
    public static class ColorModeHelper
    {
        public static ColorMode CurrentColorMode { get; set; } = ColorMode.Default;

        public enum ColorMode
        {
            Default,
            DarkMode,
            BlueMode
        }
    }
}
