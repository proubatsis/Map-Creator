/*
 * Created by Panagiotis Roubatsis
 * 
 * Description: The MapRoad class represents each adjacency
 * between nodes.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Map_Creator
{

    class MapRoad
    {
        public MapNode a, b;            //The endpoint nodes for this road, since it is undirected the road can be a->b or b->a
        public int cost = 0;            //Leave it at 0 for auto calculated cost
        public bool invisible = false;  //Makes the road invisible, it is used for nodes that are not directly connected on an image (eg. Stairs).

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

            //Euclidean distance is used as the cost metric
            return (int)Math.Sqrt(dx * dx + dy * dy);
        }

    }
}
