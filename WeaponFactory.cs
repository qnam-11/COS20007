﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuroborosAdventure
{
    public class WeaponFactory : IItemFactory
    {
        private MeleeWeaponFactory _meleeWeaponFactory;
        private RangeWeaponFactory _rangeWeaponFactory;
        public WeaponFactory() 
        {
            _meleeWeaponFactory = new MeleeWeaponFactory();
            _rangeWeaponFactory = new RangeWeaponFactory();
        }
        public Item? Create(string name, float x, float y)
        {
            if(name == "Iron Sword" || name == "Light Saber" || name == "Longsword")
            {
                return _meleeWeaponFactory.Create(name, x, y);
            }
            else if (name == "revolver" || name == "sawed-off shotgun" || name == "sniper" || name == "rifle" || name == "Broken Glass" || name == "snipezooka" || name == "fireBeam" || name == "fireWand" || name == "Plutonium")
            {
                return _rangeWeaponFactory.Create(name, x, y);
            }
            return null;
        }
    }
}
