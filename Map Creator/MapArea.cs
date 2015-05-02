﻿/*    
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
