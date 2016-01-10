using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Map_Creator
{
    class MapAdjacency
    {
        public int destIndex;
        public int cost;
        public bool invisible;

        public MapAdjacency(int dest, int cost, bool invisible)
        {
            this.destIndex = dest;
            this.cost = cost;
            this.invisible = invisible;
        }
    }
}
