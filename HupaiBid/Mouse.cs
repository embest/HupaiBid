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

 using System.Drawing;
using System.Threading;
using System.Runtime.InteropServices;


namespace HupaiBid
{
    class Mouse
    {
        const int MOUSEEVENTF_LEFTDOWN = 0x2;
        const int MOUSEEVENTF_LEFTUP = 0x4;
        const int MOUSEEVENTF_MIDDLEDOWN = 0x20;
        const int MOUSEEVENTF_MIDDLEUP = 0x40;
        const int MOUSEEVENTF_MOVE = 0x1;
        const int MOUSEEVENTF_ABSOLUTE = 0x8000;
        const int MOUSEEVENTF_RIGHTDOWN = 0x8;
        const int MOUSEEVENTF_RIGHTUP = 0x10;

        #region Mouse
        [DllImport("user32.dll")]
        public static extern int GetCursorPos(ref Point p);

        [DllImport("user32.dll")]
        public static extern int SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        public static extern int mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        #endregion

        public static Point MousePos
        {
            get
            {
                Point p = new Point(0, 0);
                GetCursorPos(ref p);
                return p;
            }
            set
            {
                SetCursorPos(value.X, value.Y);
            }
        }

        public static void MouseClick(Point p)
        {
            SetCursorPos(p.X, p.Y);
            Thread.Sleep(10);
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        public static void MouseDoubleClick(Point p)
        {
            SetCursorPos(p.X, p.Y);
            Thread.Sleep(10);
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            Thread.Sleep(10);
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }
    }
}
