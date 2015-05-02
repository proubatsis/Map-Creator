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

        //Load the map data from a text file
        private void mapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text Files (*.txt)|*.txt";

            if (dialog.ShowDialog() != DialogResult.OK) return;

            areas = new List<MapArea>();
            nodes = new List<MapNode>();
            roads = new List<MapRoad>();

            System.IO.StreamReader reader = new System.IO.StreamReader(dialog.FileName);

            //Load all the areas
            int areaCount = int.Parse(reader.ReadLine());
            for (int i = 0; i < areaCount; i++)
            {
                //Add an area initialized with an index and traffic cost
                areas.Add(new MapArea(i, int.Parse(reader.ReadLine())));
                infoTreeView.Nodes[MAP_AREAS_INDEX].Nodes.Add(Convert.ToString(i));
            }

            //Load all the nodes
            int nodeCount = int.Parse(reader.ReadLine());
            for (int i = 0; i < nodeCount; i++)
            {
                String name = reader.ReadLine();

                String[] coordStr = reader.ReadLine().Split(' ');
                int x = int.Parse(coordStr[0]), y = int.Parse(coordStr[1]);

                MapNode node = new MapNode(name, x, y, i);

                //Get all the areas that the node belongs to.
                //A string with value "-" means that the nodes does not belong to an area.
                String[] nodeAreasStr = reader.ReadLine().Split(' ');
                for (int j = 0; j < nodeAreasStr.Length; j++)
                    if (nodeAreasStr[j] != "-") node.areas.Add(int.Parse(nodeAreasStr[j]));

                //Check for the invisible flag "I", if it exists make the
                //node an invisible routing node.
                node.invisible = reader.ReadLine().Contains('I');

                //Store the node and display it in the tree view
                nodes.Add(node);
                infoTreeView.Nodes[MAP_NODES_INDEX].Nodes.Add(name);
            }

            //Load all the roads (stored as an adjacency list)
            for (int i = 0; i < nodeCount; i++)
            {
                String[] tokens = reader.ReadLine().Split(' ');

                //Each adjacency is stored in the format: destination index, cost, flags.
                //The source index is the integer 'i' in the outer loop.
                for (int j = 0; j < tokens.Length; j += 3)
                {
                    int destIndex = int.Parse(tokens[j]);
                    if (destIndex < i) continue;

                    MapRoad road = new MapRoad(nodes[i], nodes[destIndex]);
                    road.cost = int.Parse(tokens[j + 1]);
                    road.invisible = tokens[j + 2].Contains('I');

                    //Store the road and display it in the tree view
                    roads.Add(road);
                    infoTreeView.Nodes[MAP_ROADS_INDEX].Nodes.Add(road.a.name + " -> " + road.b.name);
                }
            }

            reader.Close();
            mapPanel.Invalidate();
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

        //Export the map data to a text file. It can be opened by "Map Route Finder" or
        //opened again by this application (via File->Open->Map) to edit it.
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Text Files (*.txt)|*.txt";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                List<List<Tuple<int,int,int>>> adjacencyList = buildAdjacencyList();

                System.IO.StreamWriter writer = new System.IO.StreamWriter(dialog.FileName);

                //Write the area data
                writer.WriteLine(areas.Count);
                foreach (MapArea area in areas)
                    writer.WriteLine(area.trafficCost);

                //Write the node data
                writer.WriteLine(nodes.Count.ToString());
                foreach (MapNode node in nodes)
                {
                    //Write node name
                    writer.WriteLine(node.name);

                    //Write node coordinates
                    writer.WriteLine(String.Format("{0:N0} {1:N0}", node.x, node.y));

                    //Write areas that the nodes are in
                    if (node.areas.Count > 0)
                    {
                        for (int i = 0; i < node.areas.Count; i++)
                        {
                            if (i > 0) writer.Write(" ");
                            writer.Write(node.areas[i]);
                        }
                    }
                    else writer.Write("-"); //Node is not part of an area
                    writer.WriteLine();

                    //Write a flag to indicate whether or not the node is invsibile
                    if (node.invisible) writer.WriteLine("I");
                    else writer.WriteLine("-");
                }

                //Write the adjacencies
                for(int i = 0; i < adjacencyList.Count; i++)
                {
                    for (int j = 0; j < adjacencyList[i].Count; j++)
                    {
                        if (j > 0) writer.Write(" ");

                        //Write the adjacency list: destination index, cost, invisible flag
                        writer.Write(String.Format("{0:N0} {1:N0} {2}", adjacencyList[i][j].Item1, adjacencyList[i][j].Item2, adjacencyList[i][j].Item3 == 1 ? "I" : "-"));
                    }
                    writer.WriteLine();
                }

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
        private List<List<Tuple<int,int,int>>> buildAdjacencyList()
        {
            List<List<Tuple<int,int,int>>> adj = new List<List<Tuple<int,int,int>>>();
            for (int i = 0; i < nodes.Count; i++)
                adj.Add(new List<Tuple<int, int, int>>());

            foreach (MapRoad road in roads)
            {
                adj[road.a.index].Add(new Tuple<int, int, int>(road.b.index, road.getCost(), road.invisible ? 1 : 0));
                adj[road.b.index].Add(new Tuple<int, int, int>(road.a.index, road.getCost(), road.invisible ? 1 : 0));
            }

            return adj;
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


    }
}
