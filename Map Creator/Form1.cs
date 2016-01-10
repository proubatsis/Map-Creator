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
 * Description: The main form for this project. It allows
 * the user to create a map that can be used along side the
 * "Map Route Finder" project to calculate the best path
 * to a given location.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace Map_Creator
{
    public partial class mainForm : Form
    {
        const int MAP_NODES_INDEX = 0;
        const int MAP_ROADS_INDEX = 1;
        const int MAP_AREAS_INDEX = 2;

        private List<MapNode> nodes = new List<MapNode>();
        private List<MapRoad> roads = new List<MapRoad>();
        private List<MapArea> areas = new List<MapArea>();

        private TreeNode currentlySelectedTreeNode = null;

        Image mapImage = null;

        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            infoTreeView.Nodes.Add("Nodes");
            infoTreeView.Nodes.Add("Roads");
            infoTreeView.Nodes.Add("Areas");

            //Make all the panels overlap eachother.
            //The locations in the designer are just for convenience.
            roadsPanel.Location = nodesPanel.Location;
            areasPanel.Location = nodesPanel.Location;
        }

        private void infoTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //Hide all the panels
            nodesPanel.Visible = false;
            roadsPanel.Visible = false;
            areasPanel.Visible = false;

            TreeNode node = e.Node.Parent;
            this.currentlySelectedTreeNode = e.Node;

            //Show the appropriate panel
            if (node != null)
            {
                switch (node.Index)
                {
                    case MAP_NODES_INDEX:
                        ShowNodesPanel();
                        break;
                    case MAP_ROADS_INDEX:
                        ShowRoadsPanel();
                        break;
                    case MAP_AREAS_INDEX:
                        ShowAreasPanel();
                        break;
                }
            }
        }

        private void mapPanel_Paint(object sender, PaintEventArgs e)
        {
            //If an image has been opened then draw it
            if (mapImage != null) e.Graphics.DrawImage(mapImage, 0, 0, mapImage.Width, mapImage.Height);

            //Constants used for positioning the on screen items
            const int RADIUS = 10;
            const int HALF_RADIUS = RADIUS / 2;
            const int TEXT_OFFSET = 7;

            //Draw nodes
            foreach (MapNode mapNode in nodes)
            {
                e.Graphics.FillEllipse(Brushes.Blue, mapNode.x - HALF_RADIUS, mapNode.y - HALF_RADIUS, RADIUS, RADIUS);
                e.Graphics.DrawString(mapNode.name, new Font(FontFamily.GenericSansSerif, 8), Brushes.Black, mapNode.x + TEXT_OFFSET, mapNode.y + TEXT_OFFSET);
            }

            //Draw the roads
            Pen roadPen = new Pen(Brushes.Green, 3);
            foreach (MapRoad mapRoad in roads)
                e.Graphics.DrawLine(roadPen, mapRoad.a.x, mapRoad.a.y, mapRoad.b.x, mapRoad.b.y);
        }

        private void mapPanel_MouseClick(object sender, MouseEventArgs e)
        {
            MapNode node = new MapNode(itemNameTextBox.Text, e.X, e.Y, nodes.Count);

            //Make sure the name is valid
            if (node.name.Length == 0)
            {
                MessageBox.Show("Name must contain at least one character.");
                return;
            }

            //Make sure nodes with duplicate names are not added
            bool nameFound = false;
            foreach (MapNode mapNode in nodes)
            {
                if (node.name == mapNode.name)
                {
                    nameFound = true;
                    break;
                }
            }

            if (nameFound)
            {
                MessageBox.Show("Please use a unique name.");
                return;
            }

            //Add the node if the name is valid
            nodes.Add(node);
            infoTreeView.Nodes[MAP_NODES_INDEX].Nodes.Add(node.name);
            sourceNodeList.Items.Add(node.name);
            destNodeList.Items.Add(node.name);

            //Re-draw the map with the new node
            mapPanel.Invalidate();
        }

        private void ResizePanelAndForm(int newPanelWidth, int newPanelHeight)
        {
            int dx = newPanelWidth - mapPanel.Width;
            int dy = newPanelHeight - mapPanel.Height;

            this.Width += dx;
            this.Height += dy;

            mapPanel.Width += dx;
            mapPanel.Height += dy;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nodes = new List<MapNode>();
            roads = new List<MapRoad>();
            areas = new List<MapArea>();

            infoTreeView.Nodes[MAP_NODES_INDEX].Nodes.Clear();
            infoTreeView.Nodes[MAP_ROADS_INDEX].Nodes.Clear();
            infoTreeView.Nodes[MAP_AREAS_INDEX].Nodes.Clear();

            //Re-draw the panel with all the nodes and roads removed
            mapPanel.Invalidate();
        }

        //Load the map data from a json file
        private void mapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "JSON Files (*.json)|*.json";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = new StreamReader(dialog.FileName);

                MapData data = JsonConvert.DeserializeObject<MapData>(reader.ReadToEnd());
                reader.Close();

                this.nodes = data.nodes;
                this.areas = data.areas;
                this.roads = adjacencyListToRoads(data.adjacencies, data.nodes);

                foreach (MapNode node in this.nodes)
                    infoTreeView.Nodes[MAP_NODES_INDEX].Nodes.Add(node.ToString());

                foreach (MapRoad road in this.roads)
                    infoTreeView.Nodes[MAP_ROADS_INDEX].Nodes.Add(road.ToString());

                foreach (MapArea area in this.areas)
                    infoTreeView.Nodes[MAP_AREAS_INDEX].Nodes.Add(area.ToString());

                mapPanel.Invalidate();
            }
        }

        //Allow the user to choose an image file to base the map on.
        private void imageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files (*.png, *.jpg, *.png)|*.png;*.jpg;*.bmp";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                mapImage = Image.FromFile(dialog.FileName);
                ResizePanelAndForm(mapImage.Width, mapImage.Height);
                mapPanel.Invalidate();
            }
        }

        //Export the map data to a json file. It can be opened by "Map Route Finder" or
        //opened again by this application (via File->Open->Map) to edit it.
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "JSON Files (*.json)|*.json";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                MapData data = new MapData();
                data.nodes = nodes;
                data.areas = areas;
                data.adjacencies = buildAdjacencyList();

                StreamWriter writer = new StreamWriter(dialog.FileName);
                writer.Write(JsonConvert.SerializeObject(data));
                writer.Close();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Adds a road between the two selected nodes in the list boxes
        private void addRoadButton_Click(object sender, EventArgs e)
        {
            int a = sourceNodeList.SelectedIndex, b = destNodeList.SelectedIndex;
            if (a < 0 || b < 0) return;

            MapRoad road = new MapRoad(nodes[a], nodes[b]);
            roads.Add(road);

            infoTreeView.Nodes[MAP_ROADS_INDEX].Nodes.Add(road.a.name + " -> " + road.b.name);

            mapPanel.Invalidate();
        }

        //Returns an adjacency list for an undirected graph.
        //The first integer in the tuple is the index to the
        //destination node, the second integer is the cost, the third integer
        //indicates whether it is an invisible road (0 = No, 1 = Yes).
        private List<List<MapAdjacency>> buildAdjacencyList()
        {
            List<List<MapAdjacency>> adj = new List<List<MapAdjacency>>();
            for (int i = 0; i < nodes.Count; i++)
                adj.Add(new List<MapAdjacency>());

            foreach (MapRoad road in roads)
            {
                adj[road.a.index].Add(new MapAdjacency(road.b.index, road.getCost(), road.invisible));
                adj[road.b.index].Add(new MapAdjacency(road.a.index, road.getCost(), road.invisible));
            }

            return adj;
        }

        //Inverse of buildAdjacencyList(). Returns the roads given the adjacencies (and the nodes to re-build it).
        private List<MapRoad> adjacencyListToRoads(List<List<MapAdjacency>> adjacencies, List<MapNode> nodes)
        {
            List<MapRoad> roads = new List<MapRoad>();

            for (int i = 0; i < adjacencies.Count; i++)
            {
                for(int j = 0; j < adjacencies[i].Count; j++)
                {
                    if (adjacencies[i][j].destIndex < i) continue; //Don't duplicate roads

                    MapRoad road = new MapRoad(nodes[i], nodes[adjacencies[i][j].destIndex]);
                    road.cost = adjacencies[i][j].cost;
                    road.invisible = adjacencies[i][j].invisible;

                    roads.Add(road);
                }
            }
            return roads;
        }

        //Adds an area to the map. It's values can be modified by selecting
        //the area in the tree view.
        private void addAreaButton_Click(object sender, EventArgs e)
        {
            MapArea area = new MapArea(areas.Count);
            areas.Add(area);
            infoTreeView.Nodes[MAP_AREAS_INDEX].Nodes.Add(Convert.ToString(area.index));

            areaUpDown.Enabled = true;
            addAreaToNodeButton.Enabled = true;

            areaUpDown.Maximum = area.index;
        }

        //Sidebar functions
        private void ShowNodesPanel()
        {
            int index = currentlySelectedTreeNode.Index;
            
            nodesPanel.Visible = true;
            invisbileNodeCheckBox.Checked = nodes[index].invisible;

            areasList.Items.Clear();
            foreach (int a in nodes[index].areas)
                areasList.Items.Add(a);
        }

        private void ShowRoadsPanel()
        {
            int index = currentlySelectedTreeNode.Index;

            roadsPanel.Visible = true;
            invisibleRoadCheckBox.Checked = roads[index].invisible;

            costUpDown.Value = (decimal)roads[index].cost;
        }

        private void ShowAreasPanel()
        {
            int index = currentlySelectedTreeNode.Index;

            areasPanel.Visible = true;
            trafficUpDown.Value = (decimal)areas[index].trafficCost;
        }

        //Nodes panel callbacks
        private void invisbileNodeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            nodes[currentlySelectedTreeNode.Index].invisible = invisbileNodeCheckBox.Checked;
        }

        private void addAreaToNodeButton_Click(object sender, EventArgs e)
        {
            int index = (int)areaUpDown.Value;

            if (!nodes[currentlySelectedTreeNode.Index].areas.Contains(index))
            {
                areasList.Items.Add(index);
                nodes[currentlySelectedTreeNode.Index].areas.Add(index);
            }
        }

        //Roads panel callbacks
        private void invisibleRoadCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            roads[currentlySelectedTreeNode.Index].invisible = invisibleRoadCheckBox.Checked;
        }

        private void costUpDown_ValueChanged(object sender, EventArgs e)
        {
            roads[currentlySelectedTreeNode.Index].cost = (int)costUpDown.Value;
        }

        //Areas panel callbacks
        private void trafficUpDown_ValueChanged(object sender, EventArgs e)
        {
            areas[currentlySelectedTreeNode.Index].trafficCost = (int)trafficUpDown.Value;
        }

        private void exportJSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            
        }

        private void importJSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
