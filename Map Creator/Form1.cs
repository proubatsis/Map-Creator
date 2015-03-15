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

        private List<MapNode> nodes = new List<MapNode>();
        private List<MapRoad> roads = new List<MapRoad>();

        Image mapImage = null;

        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            infoTreeView.Nodes.Add("Map Nodes");
            infoTreeView.Nodes.Add("Map Roads");
        }

        private void infoTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
        }

        private void mapPanel_Paint(object sender, PaintEventArgs e)
        {
            if (mapImage != null) e.Graphics.DrawImage(mapImage, 0, 0);

            const int RADIUS = 10;
            const int HALF_RADIUS = RADIUS / 2;
            const int TEXT_OFFSET = 12;

            foreach (MapNode mapNode in nodes)
            {
                e.Graphics.FillEllipse(Brushes.Blue, mapNode.x, mapNode.y, RADIUS, RADIUS);
                e.Graphics.DrawString(mapNode.name, new Font(FontFamily.GenericSansSerif, 8), Brushes.Black, mapNode.x + TEXT_OFFSET, mapNode.y + TEXT_OFFSET);
            }

            Pen roadPen = new Pen(Brushes.Green, 3);
            foreach (MapRoad mapRoad in roads)
            {
                e.Graphics.DrawLine(roadPen, mapRoad.a.x + HALF_RADIUS, mapRoad.a.y + HALF_RADIUS, mapRoad.b.x + HALF_RADIUS, mapRoad.b.y + HALF_RADIUS);
            }
        }

        private void mapPanel_MouseClick(object sender, MouseEventArgs e)
        {
            MapNode node = new MapNode(itemNameTextBox.Text, e.X, e.Y, nodes.Count);

            //Make sure the name is valid
            if (node.name.Length == 0)
            {
                MessageBox.Show("Name length must contain at least one character.");
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

            mapPanel.Width += dx;
            mapPanel.Height += dy;

            this.Width += dx;
            this.Height += dy;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void mapToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void imageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                mapImage = Image.FromFile(dialog.FileName);
                ResizePanelAndForm(mapImage.Width, mapImage.Height);
                mapPanel.Invalidate();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                List<List<Tuple<int,int>>> adjacencyList = buildAdjacencyList();

                System.IO.StreamWriter writer = new System.IO.StreamWriter(dialog.FileName);

                writer.WriteLine(nodes.Count.ToString());
                foreach (MapNode node in nodes)
                {
                    writer.WriteLine(node.name);
                    writer.WriteLine(String.Format("{0:N0} {1:N0}", node.x, node.y));
                }

                for(int i = 0; i < adjacencyList.Count; i++)
                {
                    for (int j = 0; j < adjacencyList[i].Count; j++)
                    {
                        if (j > 0) writer.Write(" ");
                        writer.Write(String.Format("{0:N0} {1:N0}", adjacencyList[i][j].Item1, adjacencyList[i][j].Item2));
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
        //destination node, the second integer is the cost.
        private List<List<Tuple<int,int>>> buildAdjacencyList()
        {
            List<List<Tuple<int,int>>> adj = new List<List<Tuple<int,int>>>();
            for (int i = 0; i < nodes.Count; i++)
                adj.Add(new List<Tuple<int, int>>());

            foreach (MapRoad road in roads)
            {
                adj[road.a.index].Add(new Tuple<int, int>(road.b.index, road.getCost()));
                adj[road.b.index].Add(new Tuple<int, int>(road.a.index, road.getCost()));
            }

            return adj;
        }
    }
}
