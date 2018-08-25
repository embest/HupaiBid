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
using Patagames.Ocr;
using Patagames.Ocr.Enums;
using System;
using System.IO;

namespace HupaiBid
{
    class Screen
    {
        private static OcrApi mTimeApi = OcrApi.Create();
        private static OcrApi mBidApi = OcrApi.Create();

        public static void Init()
        {
            mTimeApi.Init(Languages.Spanish);
            mBidApi.Init(Languages.English);
        }
        

        public static string GetBid(int x, int y, int w, int h)
        {
            DateTime now = DateTime.Now;
            Bitmap image = new Bitmap(w, h);
            string fileName = "debug/bid" + now.ToString("_yyyy_MMdd_HHmmss") + ".png";

            Graphics imgGraphics = Graphics.FromImage(image);
            imgGraphics.CopyFromScreen(x, y, 0, 0, new Size(w, h));

            if (!File.Exists(fileName))
            {
                image.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
            }
            
            return TextOcrS(image);
        }


        public static string GetTime(int x, int y, int w, int h)
        {
            DateTime now = DateTime.Now;
            Bitmap image = new Bitmap(w, h);
            string fileName = "debug/time" + now.ToString("_yyyy_MMdd_HHmmss") + ".png";

            Graphics imgGraphics = Graphics.FromImage(image);
            imgGraphics.CopyFromScreen(x, y, 0, 0, new Size(w, h));

            if (!File.Exists(fileName))
            {
                image.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
            }

            return TextOcrS(image);
        }

        public static string GetBidNum(int x, int y, int w, int h)
        {
            DateTime now = DateTime.Now;
            Bitmap image = new Bitmap(w, h);
            string fileName = "debug/num" + now.ToString("_yyyy_MMdd_HHmmss") + ".png"; ;
            Graphics imgGraphics = Graphics.FromImage(image);
            imgGraphics.CopyFromScreen(x, y, 0, 0, new Size(w, h));
            if (!File.Exists(fileName))
            {
                image.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
            }
            return TextOcrE(image);
        }

        public static void SaveScreen(int x, int y, int w, int h)
        {
            DateTime now = DateTime.Now;
            Bitmap image = new Bitmap(w, h);
            string fileName = "debug/img" + now.ToString("_yyyy_MMdd_HHmmss.f") + ".png"; ;
            Graphics imgGraphics = Graphics.FromImage(image);
            imgGraphics.CopyFromScreen(x, y, 0, 0, new Size(w, h));
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            image.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
        }

        private static string TextOcrS(Bitmap image)
        {
            string plainText = "";

            using (var bmp = image)
            {
                plainText = mTimeApi.GetTextFromImage(bmp);
            }

            return plainText.Trim();
        }

        private static string TextOcrE(Bitmap image)
        {
            string plainText = "";

            using (var bmp = image)
            {
                plainText = mBidApi.GetTextFromImage(bmp);
            }

            return plainText.Trim();
        }
    }
}
