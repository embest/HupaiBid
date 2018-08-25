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
using System.Windows.Forms;

namespace HupaiBid
{
    public partial class FormSet : Form
    {
        public FormSet()
        {
            InitializeComponent();
        }

        private void FormSet_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            textBoxPrice31.Text = Settings.BidPrice31;
            textBoxPrice32.Text = Settings.BidPrice32;
            textBoxPrice33.Text = Settings.BidPrice33;
            textBoxPrice34.Text = Settings.BidPrice34;
            textBoxPrice35.Text = Settings.BidPrice35;
            textBoxPrice36.Text = Settings.BidPrice36;
            textBoxPrice37.Text = Settings.BidPrice37;
            textBoxPrice38.Text = Settings.BidPrice38;
            textBoxPrice39.Text = Settings.BidPrice39;

            textBoxPrice40.Text = Settings.BidPrice40;
            textBoxPrice41.Text = Settings.BidPrice41;
            textBoxPrice42.Text = Settings.BidPrice42;
            textBoxPrice43.Text = Settings.BidPrice43;
            textBoxPrice44.Text = Settings.BidPrice44;
            textBoxPrice45.Text = Settings.BidPrice45;
            textBoxPrice46.Text = Settings.BidPrice46;
            textBoxPrice47.Text = Settings.BidPrice47;
            textBoxPrice48.Text = Settings.BidPrice48;
            textBoxPrice49.Text = Settings.BidPrice49;

            textBoxPrice50.Text = Settings.BidPrice50;
            textBoxPrice51.Text = Settings.BidPrice51;
            textBoxPrice52.Text = Settings.BidPrice52;
            textBoxPrice53.Text = Settings.BidPrice53;
            textBoxPrice54.Text = Settings.BidPrice54;
            textBoxPrice55.Text = Settings.BidPrice55;
            
            textBoxBidTime1.Text = Settings.BidTime1;
            textBoxBidTime2.Text = Settings.BidTime2;
            textBoxEarlyBid.Text = Settings.EarlyBid;            
            textBoxBidEnd.Text = Settings.BidEnd;           
            checkBoxScreenTime.Checked = Settings.ScreenTime;
            textBoxPriceX.Text = Settings.PriceX;
            textBoxPriceY.Text = Settings.PriceY;
            textBoxTimeX.Text = Settings.TimeX;
            textBoxTimeY.Text = Settings.TimeY;
        }

        private void buttonSet_Click(object sender, EventArgs e)
        {
            Settings.BidPrice31 = textBoxPrice31.Text;
            Settings.BidPrice32 = textBoxPrice32.Text;
            Settings.BidPrice33 = textBoxPrice33.Text;
            Settings.BidPrice34 = textBoxPrice34.Text;
            Settings.BidPrice35 = textBoxPrice35.Text;
            Settings.BidPrice36 = textBoxPrice36.Text;
            Settings.BidPrice37 = textBoxPrice37.Text;
            Settings.BidPrice38 = textBoxPrice38.Text;
            Settings.BidPrice39 = textBoxPrice39.Text;

            Settings.BidPrice40 = textBoxPrice40.Text;
            Settings.BidPrice41 = textBoxPrice41.Text;
            Settings.BidPrice42 = textBoxPrice42.Text;
            Settings.BidPrice43 = textBoxPrice43.Text;
            Settings.BidPrice44 = textBoxPrice44.Text;
            Settings.BidPrice45 = textBoxPrice45.Text;
            Settings.BidPrice46 = textBoxPrice46.Text;
            Settings.BidPrice47 = textBoxPrice47.Text;
            Settings.BidPrice48 = textBoxPrice48.Text;
            Settings.BidPrice49 = textBoxPrice49.Text;

            Settings.BidPrice50 = textBoxPrice50.Text;
            Settings.BidPrice51 = textBoxPrice51.Text;
            Settings.BidPrice52 = textBoxPrice52.Text;
            Settings.BidPrice53 = textBoxPrice53.Text;
            Settings.BidPrice54 = textBoxPrice54.Text;
            Settings.BidPrice55 = textBoxPrice55.Text;

            Settings.BidTime1 = textBoxBidTime1.Text;
            Settings.BidTime2 = textBoxBidTime2.Text;
            Settings.EarlyBid = textBoxEarlyBid.Text;
            Settings.ScreenTime = checkBoxScreenTime.Checked;
            Settings.BidEnd = textBoxBidEnd.Text;
            Settings.PriceX = textBoxPriceX.Text;
            Settings.PriceY = textBoxPriceY.Text;
            Settings.TimeX = textBoxTimeX.Text;
            Settings.TimeY = textBoxTimeY.Text;
        }
    }
}
