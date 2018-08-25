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
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace HupaiBid
{
    internal static partial class Settings
    {
        #region INI
        [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileString", CharSet = CharSet.Unicode)]
        public static extern bool WriteIni(string section, string key, string val, string filePath);

        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileString", CharSet = CharSet.Unicode)]
        public static extern bool ReadIni(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);
        #endregion
       
        public static readonly string DataPath;
        public static readonly string FullName;
        public const string FileName = "option.ini";

        static Settings()
        {
            DataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Application.ProductName);
            FullName = Path.Combine(DataPath, FileName);

            if (Directory.Exists(DataPath))
            {
                return;
            }
            try
            {
                Directory.CreateDirectory(DataPath);
            }
            catch
            {
                return;
            }
        }

        private static void SetValue(string section, string key, string value)
        {
            try
            {
                WriteIni(section, key, value, FullName);
            }
            catch
            {
                return;
            }
        }

        private static string GetValue(string section, string key)
        {
            try
            {
                var buf = new StringBuilder(512);
                ReadIni(section, key, "", buf, 512, FullName);
                return buf.ToString();
            }
            catch
            {
                return "";
            }
        }

        public static bool IsFirstRun
        {
            get
            {
                return GetValue("base", "firstrun") != "0";
            }
            set
            {
                SetValue("base", "firstrun", value ? "1" : "0");
            }
        }

        public static string Uuid
        {
            get
            {
                return GetValue("base", "uuid");
            }
            set
            {
                SetValue("base", "uuid", value);
            }
        }

        public static string BidNum
        {
            get
            {
                return GetValue("base", "bid");
            }
            set
            {
                SetValue("base", "bid", value);
            }
        }

        public static string Phone
        {
            get
            {
                return GetValue("base", "phone");
            }
            set
            {
                SetValue("base", "phone", value);
            }
        }

        public static bool ServerMode
        {
            get
            {
                return GetValue("system", "mode") != "0";
            }
            set
            {
                SetValue("system", "mode", value ? "1" : "0");
            }
        }

        public static string ServerAddr
        {
            get
            {
                return GetValue("system", "addr");
            }
            set
            {
                SetValue("system", "addr", value);
            }
        }

        public static string ServerTimeout
        {
            get
            {
                return GetValue("system", "timeout");
            }
            set
            {
                SetValue("system", "timeout", value);
            }
        }

        public static bool ScreenTime
        {
            get
            {
                return GetValue("system", "screentime") != "0";
            }
            set
            {
                SetValue("system", "screentime", value ? "1" : "0");
            }
        }

        public static string BidTime1
        {
            get
            {
                return GetValue("bid", "time1");
            }
            set
            {
                SetValue("bid", "time1", value);
            }
        }

        public static string BidTime2
        {
            get
            {
                return GetValue("bid", "time2");
            }
            set
            {
                SetValue("bid", "time2", value);
            }
        }

        public static string BidPrice31
        {
            get
            {
                return GetValue("bid", "price31");
            }
            set
            {
                SetValue("bid", "price31", value);
            }
        }

        public static string BidPrice32
        {
            get
            {
                return GetValue("bid", "price32");
            }
            set
            {
                SetValue("bid", "price32", value);
            }
        }

        public static string BidPrice33
        {
            get
            {
                return GetValue("bid", "price33");
            }
            set
            {
                SetValue("bid", "price33", value);
            }
        }

        public static string BidPrice34
        {
            get
            {
                return GetValue("bid", "price34");
            }
            set
            {
                SetValue("bid", "price34", value);
            }
        }

        public static string BidPrice35
        {
            get
            {
                return GetValue("bid", "price35");
            }
            set
            {
                SetValue("bid", "price35", value);
            }
        }

        public static string BidPrice36
        {
            get
            {
                return GetValue("bid", "price36");
            }
            set
            {
                SetValue("bid", "price36", value);
            }
        }

        public static string BidPrice37
        {
            get
            {
                return GetValue("bid", "price37");
            }
            set
            {
                SetValue("bid", "price37", value);
            }
        }

        public static string BidPrice38
        {
            get
            {
                return GetValue("bid", "price38");
            }
            set
            {
                SetValue("bid", "price38", value);
            }
        }

        public static string BidPrice39
        {
            get
            {
                return GetValue("bid", "price39");
            }
            set
            {
                SetValue("bid", "price39", value);
            }
        }

        public static string BidPrice40
        {
            get
            {
                return GetValue("bid", "price40");
            }
            set
            {
                SetValue("bid", "price40", value);
            }
        }

        public static string BidPrice41
        {
            get
            {
                return GetValue("bid", "price41");
            }
            set
            {
                SetValue("bid", "price41", value);
            }
        }

        public static string BidPrice42
        {
            get
            {
                return GetValue("bid", "price42");
            }
            set
            {
                SetValue("bid", "price42", value);
            }
        }

        public static string BidPrice43
        {
            get
            {
                return GetValue("bid", "price43");
            }
            set
            {
                SetValue("bid", "price43", value);
            }
        }

        public static string BidPrice44
        {
            get
            {
                return GetValue("bid", "price44");
            }
            set
            {
                SetValue("bid", "price44", value);
            }
        }

        public static string BidPrice45
        {
            get
            {
                return GetValue("bid", "price45");
            }
            set
            {
                SetValue("bid", "price45", value);
            }
        }

        public static string BidPrice46
        {
            get
            {
                return GetValue("bid", "price46");
            }
            set
            {
                SetValue("bid", "price46", value);
            }
        }

        public static string BidPrice47
        {
            get
            {
                return GetValue("bid", "price47");
            }
            set
            {
                SetValue("bid", "price47", value);
            }
        }

        public static string BidPrice48
        {
            get
            {
                return GetValue("bid", "price48");
            }
            set
            {
                SetValue("bid", "price48", value);
            }
        }

        public static string BidPrice49
        {
            get
            {
                return GetValue("bid", "price49");
            }
            set
            {
                SetValue("bid", "price49", value);
            }
        }

        public static string BidPrice50
        {
            get
            {
                return GetValue("bid", "price50");
            }
            set
            {
                SetValue("bid", "price50", value);
            }
        }

        public static string BidPrice51
        {
            get
            {
                return GetValue("bid", "price51");
            }
            set
            {
                SetValue("bid", "price51", value);
            }
        }

        public static string BidPrice52
        {
            get
            {
                return GetValue("bid", "price52");
            }
            set
            {
                SetValue("bid", "price52", value);
            }
        }

        public static string BidPrice53
        {
            get
            {
                return GetValue("bid", "price53");
            }
            set
            {
                SetValue("bid", "price53", value);
            }
        }

        public static string BidPrice54
        {
            get
            {
                return GetValue("bid", "price54");
            }
            set
            {
                SetValue("bid", "price54", value);
            }
        }

        public static string BidPrice55
        {
            get
            {
                return GetValue("bid", "price55");
            }
            set
            {
                SetValue("bid", "price55", value);
            }
        }


        public static string EarlyBid
        {
            get
            {
                return GetValue("bid", "early");
            }
            set
            {
                SetValue("bid", "early", value);
            }
        }

        public static string BidEnd
        {
            get
            {
                return GetValue("bid", "end");
            }
            set
            {
                SetValue("bid", "end", value);
            }
        }

        public static string PriceX
        {
            get
            {
                return GetValue("screen", "price_x");
            }
            set
            {
                SetValue("screen", "price_x", value);
            }
        }

        public static string PriceY
        {
            get
            {
                return GetValue("screen", "price_y");
            }
            set
            {
                SetValue("screen", "price_y", value);
            }
        }

        public static string TimeX
        {
            get
            {
                return GetValue("screen", "time_x");
            }
            set
            {
                SetValue("screen", "time_x", value);
            }
        }

        public static string TimeY
        {
            get
            {
                return GetValue("screen", "time_y");
            }
            set
            {
                SetValue("screen", "time_y", value);
            }
        }

        public static string Registration
        {
            get
            {
                string sn = "";
                try
                {
                    using (var reg = Registry.CurrentUser.OpenSubKey(@"Software\HupaiBid\", true))
                    {
                        if (reg != null)
                        {
                            sn = reg.GetValue("Registration").ToString();
                            reg.Close();                         
                        }
                    }
                }
                catch { }

                return sn;
            }

            set
            {
                try
                {
                    using (var reg = Registry.CurrentUser.CreateSubKey(@"Software\HupaiBid\"))
                    {
                        if (reg == null) return;
                        reg.SetValue("Registration", value);
                        reg.Close();
                    }
                }
                catch
                {
                }
            }
        }

    }
}
