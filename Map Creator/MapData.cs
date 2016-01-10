using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Map_Creator
{
    class MapData
    {
        public List<MapNode> nodes;
        public List<MapArea> areas;
        public List<List<MapAdjacency>> adjacencies;
    }
}
