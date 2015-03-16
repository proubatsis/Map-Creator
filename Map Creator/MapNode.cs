/*
 * Created by Panagiotis Roubatsis
 * 
 * Description: The MapNode class represents each
 * location on a map.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Map_Creator
{
    class MapNode
    {
        public String name;
        public int x, y;                //Co-Ordinates
        public int index;               //Index in the list/array that it is being stored in

        //Makes the node invisible (it can't be used a location), it is mainly used for routing.
        //For example, a node used to help bend around corners or for stairs.
        public bool invisible = false;

        //A list of indices for each area that the node belongs to.
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
