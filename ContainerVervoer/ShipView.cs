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
            shipMaxWeigthLbl.Text = ship.MaxWeight.ToString();
            ship.GenerateRandomContainers(500); // TODO Delete deze
        }

        private void generateContainersBtn_Click(object sender, EventArgs e)
        {
            if (int.TryParse(containersAmountInput.Text, out int result))
            {
                ship.GenerateRandomContainers(result);
            }
            containerListBox.Items.Clear();
            containerListBox.Items.AddRange(ship.Containers.ToArray());
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            Container containerToAdd = new Container(Convert.ToInt32(containerWeight.Text), containerValueable.Checked, containerCooled.Checked);
            Status result = ship.AddContainer(containerToAdd);
            if (result != Status.Succes)
            {
                if (result == Status.TooHeavy)
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
                MessageBox.Show($"Not enough weight, add {weightToAdd} weight"); 
                return;
            }
            List<Status> result = ship.ExecuteAlgoritm();
            FillDataGrid(0,ship.Length,ship.Width);
            ShowResult(result);
            UpdateView();
        }


        private void ShowResult(List<Status> statusesObtained)
        {
            if (statusesObtained.Contains(Status.Succes))
            {
                MessageBox.Show("Succefully completed algoritm");
            }
            else
            {
                containerListBox.Items.Clear();
                foreach (Status status in statusesObtained)
                {
                    containerListBox.Items.Add(status.ToString());
                }
            }
        }
        
        private void UpdateView()
        {
            layersBox.Items.Clear();
            GenerateLayersCombobox();
            layersBox.SelectedIndex = 0;
            weightLeftLbl.Text = ship.WeightLeft.ToString();
            weightRightLabel.Text = ship.WeightRight.ToString();
            shipUsedWeightLbl.Text = ship.CurrentWeight.ToString();
            balanceLbl.Text = ship.Balance.ToString();
        }

        private void FillDataGrid(int layer, int length, int width)
        {
            shipGrid.Rows.Clear();
            shipGrid.ColumnCount = width;
            for (int column = 0; column < length ; column++)
            {
                DataGridViewRow cellRow = new DataGridViewRow();
                cellRow.CreateCells(shipGrid);

                for (int row = 0; row < width ; row++)
                {
                    cellRow.Cells[row].Value = ship.Layers[layer].LayerLayout[column][row].Container;
                }
                shipGrid.Rows.Add(cellRow);
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
                layersBox.Items.Add(i + 1); 
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
            if (int.TryParse(layersBox.Text, out int selectedIndex))
            {
                FillDataGrid(selectedIndex - 1,ship.Length,ship.Width);
            }
            else
            {
                MessageBox.Show("Sort First and choose a layer");
            }
        }
    }
}
