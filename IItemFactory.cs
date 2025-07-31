using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuroborosAdventure
{
    public interface IItemFactory
    {
        public Item? Create(string name, float x, float y);
    }
}
