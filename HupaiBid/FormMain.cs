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
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.IO.Compression;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace HupaiBid
{
    public partial class FormMain : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        private Point mInitPosition = Point.Empty;
        private Color mLastColor = Color.Empty;

        private bool mCalScreen = false;
        private bool mCalX = false;
        private bool mCalY = false;

        private IntPtr mHandle;

        private int mBidPrice1 = 0;
        private int mBidPrice2 = 0;

        private long mTimeStamp = 0;
        private string mBidNumber = "";
        private string mScreenBidNumber = "";

        private int mScreenPrice = 0;
        private int mScreenTime = 0;
        private int mCheckCapTimes = 0;
        
        private int mSettingBidTime1 = 0;
        private int mSettingBidTime2 = 0;
        private Dictionary<int, int> mPriceTable;
        private int mSettingEarlyBid = 0;
        private double mSettingBidEnd = 0;
        private int mPriceOffsetX = 0;
        private int mPriceOffsetY = 0;
        private int mTimeOffsetX = 0;
        private int mTimeOffsetY = 0;
        private bool mCapInputed = false;
        private bool mVOL = false;

        private int mPriceTime1 = 0;
        private int mPriceTime2 = 0;

        enum BidStatus 
        {
            IDLE1,
            PRICE1,
            BID1,
            IDLE2,
            PRICE2,
            BID2,
            BIDC1,
            WAIT1,
            BIDC2,
            WAIT2,
            END,
        }

        private BidStatus mBidStatus = BidStatus.END;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            buttonCal.Image = new Bitmap(buttonCal.Image, buttonCal.Height - 5, buttonCal.Height - 5);
            buttonBid.Image = new Bitmap(buttonBid.Image, buttonBid.Height - 5, buttonBid.Height - 5);
            buttonSet.Image = new Bitmap(buttonSet.Image, buttonSet.Height - 5, buttonSet.Height - 5);
            buttonCap.Image = new Bitmap(buttonCap.Image, buttonCap.Height - 5, buttonCap.Height - 5);
            this.AcceptButton = buttonCap;
            textBoxCap.Focus();

            mHandle = this.Handle;
            Screen.Init();


            if (Settings.IsFirstRun)
            {
                FirstInit();
            }


            InitFromSettings();
            Directory.CreateDirectory("debug");
        }

        private void buttonCal_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("请移动鼠标到“公开信息”左侧信号强度符号上，\r\n不要点击。按下回车键。", "屏幕校准", MessageBoxButtons.OK) == DialogResult.OK)
            {
                textBoxLog.Text += "开始屏幕校准... \r\n";
                mCalX = false;
                mCalY = false;
                Point p = new Point(0, 0);
                p = Mouse.MousePos;
                p.X -= 20;
                Mouse.MousePos = p;
                mLastColor = ColorUtil.GetColor(MousePosition); ;
                timerCal.Enabled = true;
                
            }
            else
            {
                textBoxLog.Text += "屏幕未校准\r\n";
            }
        }

        private void buttonBid_Click(object sender, EventArgs e)
        {
            if (mCalScreen)
            {
                mBidStatus = BidStatus.IDLE1;
                timerBid.Enabled = true;
                textBoxLog.Text += "开始拍牌... \r\n";
                
                mPriceTime1 = 0;
                mPriceTime2 = 0;
                Point p = new Point(mInitPosition.X + 494, mInitPosition.Y + 249);
                Mouse.MouseClick(p);
                Directory.CreateDirectory("debug");
                Screen.SaveScreen(mInitPosition.X-20, mInitPosition.Y-170, 895, 700);
            }
            else
            {
                MessageBox.Show("请先校准屏幕！", "屏幕未校准", MessageBoxButtons.OK);
            }
        }

        private void buttonSet_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormSet formSet = new FormSet();
            DialogResult dialogResult = formSet.ShowDialog();
            InitFromSettings();
            this.Show();
        }

        private void timerCal_Tick(object sender, EventArgs e)
        {
            Point p = new Point(0,0);
            p = Mouse.MousePos;

            if (!mCalX)
            {
                p.X -= 1;
                Mouse.MousePos = p;
                var color = ColorUtil.GetColor(MousePosition);

                if ((Math.Abs(mLastColor.R - color.R) > 15) || (Math.Abs(mLastColor.G - color.G) > 15) || (Math.Abs(mLastColor.B - color.B) > 15))
                {
                    mCalX = true;
                    p.X += 2;
                    Mouse.MousePos = p;
                    color = ColorUtil.GetColor(MousePosition);
                }
                mLastColor = color;
            }
            else if (!mCalY)
            {
                p.Y -= 1;
                Mouse.MousePos = p;
                var color = ColorUtil.GetColor(MousePosition);

                if ((Math.Abs(mLastColor.R - color.R) > 15) || (Math.Abs(mLastColor.G - color.G) > 15) || (Math.Abs(mLastColor.B - color.B) > 15))
                {
                    mCalY = true;
                    p.Y += 2;
                    Mouse.MousePos = p;
                    color = ColorUtil.GetColor(MousePosition);
                }
                mLastColor = color;
            }
            else
            {
                timerCal.Enabled = false;
                mCalScreen = true;
                mInitPosition = MousePosition;
                textBoxLog.Text += "屏幕已校准！ \r\n";

                if (mHandle != GetForegroundWindow())
                {
                    SetForegroundWindow(mHandle);
                }
                textBoxCap.Focus();

                timerCheck.Interval = 1000;
                timerCheck.Enabled = true;
            }
        }

        private void timerBid_Tick(object sender, EventArgs e)
        {
            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            int price = 0;
            int time = 0;

            var stime = Screen.GetTime(mInitPosition.X + mTimeOffsetX, mInitPosition.Y + mTimeOffsetY, 85, 17);
            var bid = Screen.GetBid(mInitPosition.X + mPriceOffsetX, mInitPosition.Y + mPriceOffsetY, 55, 17);

            //Console.WriteLine("BID：" + bid + " TIME:" + stime);

            Int32.TryParse(bid, out price);
            Int32.TryParse(stime.Replace(":", ""), out time);

            if (mScreenPrice != price)
            {
                mScreenPrice = price;
            }

            if (mScreenTime != time)
            {
                mScreenTime = time;
                if (mScreenTime >= 112948 && mPriceTime1 == 0)
                {
                    mPriceTime1 = mScreenPrice;
                    textBoxLog.Text += "采样1：" + stime + " 价格：" + mScreenPrice + "\r\n";
                }

                if (mScreenTime >= 112951 && mPriceTime2 == 0)
                {
                    mPriceTime2 = mScreenPrice;
                    textBoxLog.Text += "采样2：" + stime + " 价格：" + mScreenPrice + "\r\n";
                    if (mPriceTime2 - mPriceTime1 > 100)
                    {
                        textBoxLog.Text += "服务器响应慢\r\n";
                    }
                    else {
                        textBoxLog.Text += "服务器响应快\r\n";
                    }
                }

                if (mScreenTime < 113001)
                {
                    textBoxLog.Text += "时间：" + stime + " 价格：" + bid + "\r\n";
                }
                else {
                    mBidStatus = BidStatus.END;
                }          
            }

            switch (mBidStatus) {
                case BidStatus.IDLE1:
                    if (mScreenTime >= mSettingBidTime1)
                    {
                        mBidStatus = BidStatus.PRICE1;
                    }
                    break;
                case BidStatus.IDLE2:
                    if (mScreenTime > mSettingBidEnd)
                    {
                        Console.WriteLine("END");
                        mBidStatus = BidStatus.END;
                    }
                    else if (mScreenTime >= mSettingBidTime2)
                    {
                        Console.WriteLine("PRICE2");
                        mBidStatus = BidStatus.PRICE2;
                    }
                    break;
                case BidStatus.PRICE1:
                    mBidPrice1 = price + mPriceTable[mScreenTime];
                    InputPrice(mBidPrice1);
                    mBidStatus = BidStatus.BID1;
                    mCapInputed = false;
                    break;
                case BidStatus.BID1:
                    if (mBidPrice1 <= mScreenPrice + 300 + mSettingEarlyBid)
                    {
                        textBoxLog.Text += "到达出价区间\r\n";
                        mBidStatus = BidStatus.BIDC1;
                    }
                    else if (Settings.ScreenTime)
                    {
                        if (mScreenTime >= mSettingBidEnd)
                        {
                            textBoxLog.Text += "强制出价:屏幕时间\r\n";
                            mBidStatus = BidStatus.BIDC1;
                        }
                    }
                    else {
                        double localTime = double.Parse(DateTime.Now.ToString("HHmmss.f"));
                        Console.WriteLine("Local Time： {0}", localTime);
                        if (localTime >= mSettingBidEnd)
                        {
                            textBoxLog.Text += "强制出价:本地时间\r\n";
                            mBidStatus = BidStatus.BIDC1;
                        }
                    }
                    break;
                case BidStatus.PRICE2:
                    mBidPrice2 = price + mPriceTable[mScreenTime];
                    InputPrice(mBidPrice2);
                    mBidStatus = BidStatus.BID2;
                    mCapInputed = false;
                    break;
                case BidStatus.BID2:
                    if (mBidPrice2 <= mScreenPrice + 300 + mSettingEarlyBid)
                    {
                        textBoxLog.Text += "到达出价区间\r\n";
                        mBidStatus = BidStatus.BIDC2;
                    }
                    else if (Settings.ScreenTime)
                    {
                        if (mScreenTime >= mSettingBidEnd)
                        {
                            textBoxLog.Text += "强制出价:屏幕时间\r\n";
                            mBidStatus = BidStatus.BIDC2;
                        }
                    }
                    else
                    {
                        double localTime = double.Parse(DateTime.Now.ToString("HHmmss.f"));
                        Console.WriteLine("Local Time： {0}", localTime);
                        if (localTime >= mSettingBidEnd)
                        {
                            textBoxLog.Text += "强制出价:本地时间\r\n";
                            mBidStatus = BidStatus.BIDC2;
                        }
                    }
                    break;
                case BidStatus.BIDC1:
                    Point p = new Point(mInitPosition.X + 528, mInitPosition.Y + 327);
                    if (mCapInputed)
                    {
                        Console.WriteLine("WAIT1");
                        Mouse.MouseClick(p);
                        mCapInputed = false;
                        mBidStatus = BidStatus.WAIT1;
                    }
                    break;
                case BidStatus.BIDC2:
                    p = new Point(mInitPosition.X + 528, mInitPosition.Y + 327);
                    if (mCapInputed)
                    {
                        Console.WriteLine("WAIT2");
                        Mouse.MouseClick(p);
                        mCapInputed = false;
                        mBidStatus = BidStatus.WAIT2;
                    }
                    break;
                case BidStatus.WAIT1:
                    Point p1 = new Point(mInitPosition.X + 515, mInitPosition.Y + 315);
                    Point p2 = new Point(mInitPosition.X + 585, mInitPosition.Y + 320);
                    Point p3 = new Point(mInitPosition.X + 680, mInitPosition.Y + 315);
                    Point p4 = new Point(mInitPosition.X + 630, mInitPosition.Y + 315);
                    if (ClickButton(p1, p2, p3, p4))
                    {
                        Console.WriteLine("IDLE2");
                        mBidStatus = BidStatus.IDLE2;
                    }
                    break;
                case BidStatus.WAIT2:
                    p1 = new Point(mInitPosition.X + 515, mInitPosition.Y + 315);
                    p2 = new Point(mInitPosition.X + 585, mInitPosition.Y + 320);
                    p3 = new Point(mInitPosition.X + 680, mInitPosition.Y + 315);
                    p4 = new Point(mInitPosition.X + 630, mInitPosition.Y + 315);
                    if (ClickButton(p1, p2, p3, p4))
                    {
                        Console.WriteLine("END");
                        mBidStatus = BidStatus.END;
                    }
                    break;
                case BidStatus.END:
                    Console.WriteLine("END");
                    timerBid.Enabled = false;
                    timerCheck.Enabled = false;
                    textBoxLog.Text += "拍牌结束\r\n";
                    Screen.SaveScreen(mInitPosition.X, mInitPosition.Y, 850, 600);
                    string startPath = "debug";

                    FileStream fs = new FileStream("debug\\log.txt", FileMode.Create);
                    byte[] data = System.Text.Encoding.Default.GetBytes(textBoxLog.Text);
                    fs.Write(data, 0, data.Length);
                    fs.Flush();
                    fs.Close();

                    DateTime now = DateTime.Now;
                    string zipPath = "bid" + now.ToString("_yyyy_MMdd_HHmmss") + ".zip";
                    ZipFile.CreateFromDirectory(startPath, zipPath);
                    Directory.Delete(startPath, true);
                    break;
            }

            if (mHandle != GetForegroundWindow())
            {
                SetForegroundWindow(mHandle);
            }
            textBoxCap.Focus();
            //sw.Stop();
            //Console.WriteLine("Run (ms)：" + +sw.ElapsedMilliseconds);

        }

        private bool InputPrice (int price) {
            Point p = new Point(0, 0);

            textBoxLog.Text += "伏击出价：" + price + "\r\n";

            //价格输入
            p.X = mInitPosition.X + 654;
            p.Y = mInitPosition.Y + 248;
            Mouse.MouseDoubleClick(p);
            Thread.Sleep(100);
            Keyboard.SendKey("" + price);

            //出价button
            p.X = mInitPosition.X + 774;
            p.Y = mInitPosition.Y + 248;
            Mouse.MouseClick(p);
            textBoxLog.Text += "价格已输入，等待验证码\r\n";
            timerCap.Enabled = true;
            mCheckCapTimes = 0;
            return true;
        }

        private void buttonCap_Click(object sender, EventArgs e)
        {
            if (textBoxCap.Text.Length > 1)
            {
                Point p = new Point(mInitPosition.X + 713, mInitPosition.Y + 248);
              
                Mouse.MouseDoubleClick(p);
                Keyboard.SendKey(textBoxCap.Text);

                textBoxLog.Text += "验证码输入：" + textBoxCap.Text + "\r\n";
                textBoxCap.Text = "";

                timerCap.Enabled = false;
                mCapInputed = true;
                Screen.SaveScreen(mInitPosition.X, mInitPosition.Y, 850, 600);
            }
        }

        private void textBoxLog_TextChanged(object sender, EventArgs e)
        {
            textBoxLog.Select(textBoxLog.TextLength, 0);
            textBoxLog.ScrollToCaret();
        }

        private void timerCap_Tick(object sender, EventArgs e)
        {
            mCheckCapTimes++;
            Point p1 = new Point(mInitPosition.X + 531, mInitPosition.Y + 285);
            Point p2 = new Point(mInitPosition.X + 563, mInitPosition.Y + 247);
            Point p3 = new Point(mInitPosition.X + 494, mInitPosition.Y + 249);
            Point p4 = new Point(mInitPosition.X + 485, mInitPosition.Y + 248);
            if(ClickButton(p1, p2, p3, p4))
            {
                textBoxLog.Text += "验证码已刷新\r\n";
            }
            if (mCheckCapTimes >= 6) {
                timerCap.Enabled = false;
                textBoxLog.Text += "不检测验证码\r\n";
            }
        }

        private bool ClickButton(Point p1, Point p2, Point p3, Point p4)
        {
            var color1 = ColorUtil.GetColor(p1);
            var color2 = ColorUtil.GetColor(p2);
            var color3 = ColorUtil.GetColor(p3);

            
            if ((Math.Abs(color3.R - color2.R) < 30) && (Math.Abs(color3.G - color2.G) < 30) && (Math.Abs(color3.B - color2.B) < 30))
            {
                if ((Math.Abs(color1.R - color3.R) > 30) || (Math.Abs(color1.G - color3.G) > 30) || (Math.Abs(color1.B - color3.B) > 30))
                {
                    Screen.SaveScreen(mInitPosition.X, mInitPosition.Y, 850, 600);
                    Mouse.MouseClick(p4);

                    if (mHandle != GetForegroundWindow())
                    {
                        SetForegroundWindow(mHandle);
                    }
                    textBoxCap.Focus();
                    return true;
                }
            }
            return false;
        }

        private void FirstInit()
        {
            Settings.IsFirstRun = false;
            Settings.Uuid = Guid.NewGuid().ToString("N");
            Settings.BidNum = "0";
            Settings.BidTime1 = "112941";
            Settings.BidTime2 = "113031";
            Settings.EarlyBid = "0";
            Settings.BidEnd= "112957.0";
            Settings.ServerMode = false;
            Settings.ScreenTime = true;
            Settings.PriceX = "128";
            Settings.PriceY = "240";
            Settings.TimeX = "101";
            Settings.TimeY = "225";
            Settings.BidPrice31 = "300";
            Settings.BidPrice32 = "300";
            Settings.BidPrice33 = "300";
            Settings.BidPrice34 = "300";
            Settings.BidPrice35 = "300";
            Settings.BidPrice36 = "300";
            Settings.BidPrice37 = "300";
            Settings.BidPrice38 = "300";
            Settings.BidPrice39 = "300";
            Settings.BidPrice40 = "300";
            Settings.BidPrice41 = "1200";
            Settings.BidPrice42 = "1200";
            Settings.BidPrice43 = "1100";
            Settings.BidPrice44 = "1100";
            Settings.BidPrice45 = "1000";
            Settings.BidPrice46 = "900";
            Settings.BidPrice47 = "900";
            Settings.BidPrice48 = "800";
            Settings.BidPrice49 = "700";
            Settings.BidPrice50 = "600";
            Settings.BidPrice51 = "500";
            Settings.BidPrice52 = "400";
            Settings.BidPrice53 = "300";
            Settings.BidPrice54 = "300";
            Settings.BidPrice55 = "300";
        }

        private void timerCheck_Tick(object sender, EventArgs e)
        {
            if (false)
            {
                timerCheck.Interval = 1000;
                Point mouse = MousePosition;
                Console.WriteLine("Offset X: {0}, Y: {1}", mouse.X - mInitPosition.X, mouse.Y - mInitPosition.Y);
            }
            else
            {
                timerCheck.Enabled = false;
            }
        }

        public DateTime GetNowTime()
        {
            return DateTime.Now;
        }

        private void InitFromSettings() {
            mSettingBidTime1   = int.Parse(Settings.BidTime1);
            mSettingBidTime2   = int.Parse(Settings.BidTime2);
            mPriceTable = new Dictionary<int, int>();
            mPriceTable.Add(112931, int.Parse(Settings.BidPrice31));
            mPriceTable.Add(112932, int.Parse(Settings.BidPrice32));
            mPriceTable.Add(112933, int.Parse(Settings.BidPrice33));
            mPriceTable.Add(112934, int.Parse(Settings.BidPrice34));
            mPriceTable.Add(112935, int.Parse(Settings.BidPrice35));
            mPriceTable.Add(112936, int.Parse(Settings.BidPrice36));
            mPriceTable.Add(112937, int.Parse(Settings.BidPrice37));
            mPriceTable.Add(112938, int.Parse(Settings.BidPrice38));
            mPriceTable.Add(112939, int.Parse(Settings.BidPrice39));
            mPriceTable.Add(112940, int.Parse(Settings.BidPrice40));
            mPriceTable.Add(112941, int.Parse(Settings.BidPrice41));
            mPriceTable.Add(112942, int.Parse(Settings.BidPrice42));
            mPriceTable.Add(112943, int.Parse(Settings.BidPrice43));
            mPriceTable.Add(112944, int.Parse(Settings.BidPrice44));
            mPriceTable.Add(112945, int.Parse(Settings.BidPrice45));
            mPriceTable.Add(112946, int.Parse(Settings.BidPrice46));
            mPriceTable.Add(112947, int.Parse(Settings.BidPrice47));
            mPriceTable.Add(112948, int.Parse(Settings.BidPrice48));
            mPriceTable.Add(112949, int.Parse(Settings.BidPrice49));
            mPriceTable.Add(112950, int.Parse(Settings.BidPrice50));
            mPriceTable.Add(112951, int.Parse(Settings.BidPrice51));
            mPriceTable.Add(112952, int.Parse(Settings.BidPrice52));
            mPriceTable.Add(112953, int.Parse(Settings.BidPrice53));
            mPriceTable.Add(112954, int.Parse(Settings.BidPrice54));
            mPriceTable.Add(112955, int.Parse(Settings.BidPrice55));
            mSettingEarlyBid   = int.Parse(Settings.EarlyBid);
            mSettingBidEnd     = double.Parse(Settings.BidEnd);
            mPriceOffsetX      = int.Parse(Settings.PriceX);
            mPriceOffsetY      = int.Parse(Settings.PriceY);
            mTimeOffsetX       = int.Parse(Settings.TimeX);
            mTimeOffsetY       = int.Parse(Settings.TimeY);
        }

        private void timerTime_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString("HH:mm:ss.f");
        }
    }
}
