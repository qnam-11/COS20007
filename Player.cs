﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace OuroborosAdventure
{
    public class Player : Character
    {
        private string _personalItem;
        private int _coin;
        private int _armor;
        private int _maxArmor;
        private int _energy;
        private int _maxEnergy;
        private int _armorTick;
        private int _maxArmorTick;
        private Inventory _inventory;
        public bool IsImmortal;
        // Player size: 96 x 128
        public Player(string name, int health, int maxEnergy, int maxArmor, CharacterType type, float x,float y, float velocity, string personalItem, int width, int height) : base(name, health, type, width, height)
        {
            X = x;
            Y = y;
            _maxEnergy = maxEnergy;
            _energy = maxEnergy;
            _armor = maxArmor;
            _maxArmor = maxArmor;
            Velocity = velocity;
            _personalItem = personalItem;
            _inventory = new Inventory(2);
            _armorTick = 80;
            _maxArmorTick = 80;
            _coin = 0;
        }
        public Player() : base("player", 0, CharacterType.Player, 0, 0)
        {
            X = 0;
            Y = 0;
            _inventory = new Inventory(2);
            _armorTick = 80;
            _maxArmorTick = 80;
            _coin = 0;
        }
        public void RegenerateArmor()
        {
            if (_armorTick == _maxArmorTick)
            {
                ArmorChanged(2);
                _armorTick -= 5;
            }
            else if (_armorTick < _maxArmorTick)
            {
                _armorTick++;
            }
        }
        public int Armor
        {
            get { return _armor; }
            set { _armor = value; }
        }
        public int MaxArmor
        {
            get { return _maxArmor; }
            set { _maxArmor = value; }
        }
        public int Coin
        {
            get { return _coin; }
            set { _coin = value; }
        }
        public void ArmorChanged(int value)
        {
            if (IsImmortal)
            {
                return;
            }
            else if (!IsImmortal)
            {
                if (_armor + value > _maxArmor)
                {
                    _armor = _maxArmor;
                }
                else
                {
                    _armor += value;
                }
            }
        }
        public int Energy
        {
            get { return _energy; }
            set { _energy = value; }
        }
        public int MaxEnergy
        {
            get { return _maxEnergy; }
            set { _maxEnergy = value; }
        }
        public Inventory Inventory
        {
            get { return _inventory; }
        }
        public void EnergyChanged(int value)
        {
            if (_energy + value> _maxEnergy)
            {
                _energy = _maxEnergy;
            } else { _energy += value; }
            if(Energy < 0)
            {
                _energy = 0;
            }
        }
        public override void TakeDamage(int value, Point2D dir, Room[] rooms)
        {
            if (IsImmortal)
            {
                return;
            }
            else if (!IsImmortal)
            {
                if (_armor - value > _maxArmor)
                {
                    _armor = _maxArmor;
                }
                else
                {
                    _armor -= value;
                    _armorTick = 0;
                    if (CheckValidMove(X + dir.X * 1.5f, Y, rooms, Width, Height))
                    {
                        X += dir.X * 1.5f;
                    }
                    if (CheckValidMove(X, Y + dir.Y * 1.5f, rooms, Width, Height))
                    {
                        Y += dir.Y * 1.5f;
                    }
                    if (_armor < 0)
                    {
                        HealthChanged(_armor);
                        _armor = 0;
                    }
                }
            }
            
        }
        public string PersonalItem
        {
            get { return _personalItem; }
        }        
    }
}
