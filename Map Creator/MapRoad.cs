using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Map_Creator
{
    class MapRoad
    {
        public MapNode a, b;
        public int cost = 0;    //Leave it at 0 for auto calculated cost
        public bool invisible = false;

        public MapRoad(MapNode a, MapNode b)
        {
            this.a = a;
            this.b = b;
        }

        public int getCost()
        {
            if (cost > 0) return cost;

            int dx = b.x - a.x;
            int dy = b.y - a.y;

            return (int)Math.Sqrt(dx * dx + dy * dy);
        }
    }
}
