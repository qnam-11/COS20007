﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuroborosAdventure
{
    public class EffectFactory
    {
        public EffectFactory() { }
        public Effect? Create(string name, float x, float y, bool faceLeft)
        {
            switch (name)
            {
                case "bulletCollision":
                    return new Effect(name, x, y, 20, faceLeft, 4);
                case "scratch":
                    return new Effect(name, x, y, 15, faceLeft, 4);
                case "cut":
                    return new Effect(name, x, y, 12, faceLeft, 4);
                case "slash":
                    return new Effect(name, x, y, 16, faceLeft, 8);
                case "paleslash":
                    return new Effect(name, x, y, 32, faceLeft, 8);
                case "bigslash":
                    return new Effect(name, x, y, 32, faceLeft, 8);
                case "fireExplosion":
                    return new Effect(name, x, y, 24, faceLeft, 4);
                case "radiation":
                    return new Effect(name, x, y, 24, faceLeft, 4);
                default:
                    return null;
            }
            
        }
    }
}
