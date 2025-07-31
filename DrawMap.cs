﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuroborosAdventure
{
    public class DrawMap
    {
        private DrawRoom _drawRoom;
        private string _path;
        public DrawMap(string path, int theme)
        {
            _drawRoom = new DrawRoom(path, theme); // Default theme
            _path = path;
        }
        public DrawMap()
        {
            _drawRoom = new DrawRoom();
            _path = "";
        }
        public void Draw(Map map)
        {
            for (int i = 0; i < map.MapSize; i++)
            {
                _drawRoom.Draw(map.Rooms[i]);
            }
        }
        public void SetPath(string path, int theme)
        {
            _path = path;
            _drawRoom.Path = path;
            Console.WriteLine($"Inside DrawMap, update DrawRoom Path to: {_path}");
            _drawRoom.UpdateTheme(theme);
        }
    }
}
