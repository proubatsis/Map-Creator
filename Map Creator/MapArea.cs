/*
 * Created by Panagiotis Roubatsis
 * 
 * Description: The MapArea class represents a group of MapNodes.
 * The area represents common characteristics about a group of nodes (eg. traffic).
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Map_Creator
{
    class MapArea
    {
        public int index;
        public int trafficCost;

        public MapArea(int index)
        {
            this.trafficCost = 0;
            this.index = index;
        }

        public MapArea(int index, int trafficCost)
        {
            this.trafficCost = trafficCost;
            this.index = index;
        }

    }
}
