/*    
    Copyright (C) 2015 Panagiotis Roubatsis

    This program is free software; you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation; either version 2 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License along
    with this program; if not, write to the Free Software Foundation, Inc.,
    51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
*/

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
