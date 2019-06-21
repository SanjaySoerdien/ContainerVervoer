using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContainerVervoer.Classes;
using ContainerVervoer.Enums;
using Container = ContainerVervoer.Classes.Container;

namespace ContainerVervoer
{
    public partial class ShipView : Form
    {
        private Ship ship;
        public ShipView(int width , int length)
        {
            ship = new Ship(width,length);
            InitializeComponent();
        }

        private void generateContainersBtn_Click(object sender, EventArgs e)
        {
            if (int.TryParse(containersAmountInput.Text, out int result))
            {
                ship.GenerateRandomContainers(result);
            }
            //containerListBox.DataSource = ship.Containers;
            containerListBox.Items.Clear();
            containerListBox.Items.AddRange(ship.Containers.ToArray());
            // containerListBox.Items.Add(ship.Containers[0].ToString());
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            
            Container containerToAdd = new Container(Convert.ToInt32(containerWeight.Text), containerValueable.Checked, containerCooled.Checked);
            ErrorMessage result = ship.AddContainer(containerToAdd);
            if (result != ErrorMessage.Succes)
            {
                if (result == ErrorMessage.TooHeavy)
                {
                    MessageBox.Show("Container is too heavy to be added");
                }
                return;
            }
            containerListBox.Items.Clear();
            containerListBox.Items.AddRange(ship.Containers.ToArray());
        }

        private void sortBtn_Click(object sender, EventArgs e)
        {
            if (!ship.CheckWeight())
            {
                int weightToAdd = (ship.MaxWeight / 2) - GetTotalWeight(); 
                MessageBox.Show($"Not enough weight, add {weightToAdd} weight"); //TODO check dis
                return;
            }
            layersBox.Items.Clear();
            ship.PlaceContainersInShip();
            GenerateLayersCombobox();
            layersBox.SelectedIndex = 0;
            FillDataGrid(0);
            

        }

        private void FillDataGrid(int layer)
        {
            layer += 1;
            int length = ship.Layers[layer].LayerLayout[0].Count;
            int width = ship.Layers[layer].LayerLayout.Count;
            this.shipGrid.ColumnCount = width;
            for (int r = 0; r < length; r++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.shipGrid);
                for (int c = 0; c < width; c++)
                {
                    row.Cells[c].Value = ship.Layers[layer].LayerLayout[r][c].ToString();
                }
                this.shipGrid.Rows.Add(row);
            }
        }

        private int GetTotalWeight()
        {
            int containerTotalWeight = 0;
            foreach (Container container in ship.Containers)
            {
                containerTotalWeight += container.Weight;
            }
            return containerTotalWeight;
        }

        private void GenerateLayersCombobox()
        {
            for (int i = 0; i < ship.Layers.Count; i++)
            {
                layersBox.Items.Add(i + 1); //TODO add total layers here
            }
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            int index = containerListBox.SelectedIndex;
            if (index > -1 )
            {
                containerListBox.Items.RemoveAt(index);
                ship.RemoveContainer(index);
            }
            else
            {
                MessageBox.Show("Select a container to remove");
            }
        }

        private void clearAllContainer_Click(object sender, EventArgs e)
        {
            ship.RemoveAllContainers();
            containerListBox.Items.Clear();
        }

        private void layersBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = layersBox.SelectedIndex;
            if (selectedIndex > -1)
            {
                FillDataGrid(selectedIndex);
            }
        }
    }
}
