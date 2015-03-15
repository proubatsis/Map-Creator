using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Map_Creator
{
    class MapNode
    {
        public String name;
        public int x, y;   //Co-Ordinates
        public int index;
        public bool invisible = false;

        public List<int> areas = new List<int>();

        public MapNode(String name, int x, int y, int index)
        {
            this.name = name;
            this.x = x;
            this.y = y;
            this.index = index;
        }
    }
}
