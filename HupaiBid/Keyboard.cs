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

 using System.Threading;
using System.Runtime.InteropServices;
using System;

namespace HupaiBid
{
    class Keyboard
    {
        #region Keyboard
        [DllImport("USER32.DLL")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        [DllImport("user32.dll")]
        static extern byte MapVirtualKey(byte wCode, int wMap);
        #endregion

        public static void SendKey(byte key)
        {
            keybd_event(key, MapVirtualKey(key, 0), 0, 0);
            Thread.Sleep(70);
        }

        public static void SendKey(string str)
        {
            char[] keys = str.ToCharArray();
            foreach (byte key in keys) {
                SendKey(key);
                Console.WriteLine("Send Key: {0}", key);
            }
        }
    }
}
