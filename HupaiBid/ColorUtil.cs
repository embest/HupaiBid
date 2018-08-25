/*
 * Copyright (C) 2018 Embest
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

 using System;
using System.Drawing;
using System.Runtime.InteropServices;


namespace HupaiBid
{
    class ColorUtil
    {
        #region Color
        [DllImport("gdi32.dll")]
        public static extern uint GetPixel(IntPtr hDC, int XPos, int YPos);
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr CreateDC(string driverName, string deviceName, string output, IntPtr lpinitData);
        [DllImport("gdi32.dll")]
        public static extern bool DeleteDC(IntPtr DC);
        #endregion

        public static byte GetRValue(uint color)
        {
            return (byte)color;
        }
        public static byte GetGValue(uint color)
        {
            return (byte)((short)color >> 8);
        }
        public static byte GetBValue(uint color)
        {
            return (byte)(color >> 16);
        }

        public static Color GetColor(Point screenPoint)
        {
            var displayDC = CreateDC("DISPLAY", null, null, IntPtr.Zero);
            var colorref = GetPixel(displayDC, screenPoint.X, screenPoint.Y);
            DeleteDC(displayDC);
            return Color.FromArgb(GetRValue(colorref), GetGValue(colorref), GetBValue(colorref));
        }
    }
}
