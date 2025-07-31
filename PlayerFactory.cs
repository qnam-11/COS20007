﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuroborosAdventure
{
    public class PlayerFactory : ICharacterFactory
    {
        private int _bonusHP;
        private int _bonusEnergy;
        private int _bonusArmor;
        private int _bonusSpeed;
        public PlayerFactory() 
        {
            _bonusHP = 0;
            _bonusEnergy = 0;
            _bonusArmor = 0;
            _bonusSpeed = 0;
        }
        public Character? Create(string name, float x, float y)
        {
            switch (name)
            {
                case "alchemist":
                    return new Player(name, 150 + _bonusHP * 25, 200 + _bonusEnergy * 25, 55 + _bonusArmor * 10, CharacterType.Player, x, y, 10f + _bonusSpeed * 2, "Plutonium", 96, 128);
                case "wizard":
                    return new Player(name, 100 + _bonusHP * 25, 300 + _bonusEnergy * 25, 40 + _bonusArmor * 10, CharacterType.Player, x, y, 10f + _bonusSpeed * 2, "fireWand", 96, 128);
                case "cowboy":
                    return new Player(name, 125 + _bonusHP * 25, 150 + _bonusEnergy * 25, 65 + _bonusArmor * 10, CharacterType.Player, x, y, 12f + _bonusSpeed * 2, "Longsword", 96, 128);
                default:
                    return null;
            }
        }
        public void UpgradeBonusHP()
        {
            _bonusHP++;
        }
        public void UpgradeBonusEnergy()
        {
            _bonusEnergy++;
        }
        public void UpgradeBonusArmor()
        {
            _bonusArmor++;
        }
        public void UpgradeBonusSpeed()
        {
            _bonusSpeed++;
        }
        public int BonusHP
        {
            get { return _bonusHP; }
            set { _bonusHP = value; }
        }
        public int BonusEnergy
        {
            get { return _bonusEnergy; }
            set { _bonusEnergy = value; }
        }
        public int BonusArmor
        {
            get { return _bonusArmor; }
            set { _bonusArmor = value; }
        }
        public int BonusSpeed
        {
            get { return _bonusSpeed; }
            set { _bonusSpeed = value; }
        }
    }
}
