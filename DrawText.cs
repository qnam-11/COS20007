﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace OuroborosAdventure
{
    public class DrawText
    {
        private Font _myFont;
        private Font _montserrat;
        public DrawText() 
        {
            _myFont = SplashKit.LoadFont("ThaleahFat", "Resource\\Fonts\\" + "ThaleahFat.ttf");
            _montserrat = SplashKit.LoadFont("Montserrat", "Resource\\Fonts\\static\\Montserrat-ExtraBold.ttf");
        }
        public void DrawH1(string text, float x, float y)
        {
            SplashKit.DrawText(text, Color.White, _myFont, 32,
                x - text.Length * 6.2f, y - 76);
        }
        public void DrawH2(string text, float x, float y)
        {
            SplashKit.DrawText(text, Color.White, _myFont, 28, x, y);
        }
        public void DrawSuperH1(string text, float x, float y)
        {
            SplashKit.DrawText(text, Color.White, _myFont, 64,
               x - text.Length * 12.4f, y - 76);
        }
        public void DrawMontserratH1Custom(string text, float x, float y, Color color)
        {
            SplashKit.DrawText(text, color, _montserrat, 96,
               x - text.Length * 24f, y);
        }
        public void DrawMontserratH2Custom(string text, float x, float y, Color color)
        {
            SplashKit.DrawText(text, color, _montserrat, 64,
               x - text.Length * 18, y);
        }
        public void DrawMontserratH3Custom(string text, float x, float y, Color color)
        {
            SplashKit.DrawText(text, color, _montserrat, 48,
               x - text.Length * 12f, y);
        }
        public void DrawMontserratH4Custom(string text, float x, float y, Color color)
        {
            SplashKit.DrawText(text, color, _montserrat, 32,
               x - text.Length * 8f, y);
        }
        public void DrawMontserratH4LeftAlign(string text, float x, float y, Color color)
        {
            SplashKit.DrawText(text, color, _montserrat, 32,
               x, y);
        }
    }
}
