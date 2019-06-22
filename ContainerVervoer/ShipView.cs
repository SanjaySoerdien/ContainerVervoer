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
            minWeightLbl.Text = (ship.MaxWeight / 2).ToString();
        }

        private void generateContainersBtn_Click(object sender, EventArgs e)
        {
            Status status = Status.Succes;
            if (int.TryParse(containersAmountInput.Text, out int result))
            {
                status = ship.GenerateRandomContainers(result);
            }

            for (int i = containerListBox.Items.Count - 1; i < ship.Containers.Count - 1; i++)
            {
                if (i > -1)
                {
                    containerListBox.Items.Add(ship.Containers[i]);
                 
                }
            }

            if (status != Status.Succes)
            {
                MessageBox.Show(status.ToString());
            }

            containerListWeightLbl.Text = ship.CurrentWeight.ToString();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            string weight = containerWeight.Text;
            ContainerType type = GetContainerType();
            Container containerToAdd = new Container(Convert.ToInt32(weight), type);
            Status result = ship.AddContainer(containerToAdd);
            if (result == Status.TooHeavy)
            {
                MessageBox.Show("Container is too heavy to be added");
                return;
            }

            containerListWeightLbl.Text = ship.CurrentWeight.ToString();
            containerListBox.Items.Add(containerToAdd);
        }

        private ContainerType GetContainerType()
        {
            ContainerType type = ContainerType.Normal;
            if (containerValueable.Checked)
            {
                type = ContainerType.Valuable;
                if (containerCooled.Checked)
                {
                    type = ContainerType.CooledValuable;
                }
            }
            else if (containerCooled.Checked)
            {
                type = ContainerType.Cooled;
            }
            return type;
        }

        private void sortBtn_Click(object sender, EventArgs e)
        {
            if (!ship.CheckWeight())
            {
                int weightToAdd = (ship.MaxWeight / 2) - GetTotalWeight(); 
                MessageBox.Show($"Not enough weight, add {weightToAdd} weight"); 
                return;
            }
            ship.ClearLayers();
            List<Status> result = ship.ExecuteAlgoritm();
            FillDataGrid(0,ship.Length ,ship.Width);
            ShowResult(result);
            UpdateView();
        }


        private void ShowResult(List<Status> statusesObtained)
        {
            containersLeftListBox.Items.Clear();
            if (statusesObtained.Contains(Status.Succes))
            {
                MessageBox.Show("Succefully completed algorithm");
            }
            else
            {
                string message = "";
                foreach (Container containerLeftOver in ship.Containers)
                {
                    containersLeftListBox.Items.Add(containerLeftOver);
                }

                foreach (Status status in statusesObtained)
                {
                    message += status + "\n";
                }
                MessageBox.Show(message);
            }
        }
        
        private void UpdateView()
        {

            layersBox.Items.Clear();
            GenerateLayersCombobox();
            weightLeftLbl.Text = ship.WeightLeft.ToString();
            weightRightLabel.Text = ship.WeightRight.ToString();
            shipUsedWeightLbl.Text = ship.CurrentWeight.ToString();
            var balance = ship.Marge;
            balanceLbl.Text = $@"{balance}%"; 
        }

        private void FillDataGrid(int layer, int length, int width)
        {
            shipGrid.Columns.Clear();
            shipGrid.Rows.Clear();
            shipGrid.ColumnCount = length;

            for (int row = 0; row < width; row++)
            {
                DataGridViewRow cellRow = new DataGridViewRow();
                cellRow.CreateCells(shipGrid);

                for (int column = 0; column < length; column++)
                {
                    cellRow.Cells[column].Value = ship.Layers[layer].LayerLayout[column][row];
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
            for (int i = 0; i < ship.Layers.Count-1; i++)
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
            containerListWeightLbl.Text = "0";
            ship.RemoveAllContainers();
            containerListBox.Items.Clear();
            containersLeftListBox.Items.Clear();
        }

        private void layersBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(layersBox.Text, out int selectedIndex))
            {
                FillDataGrid(selectedIndex - 1,ship.Length ,ship.Width);
            }
            else
            {
                MessageBox.Show("Sort First and choose a layer");
            }
        }

        private void shipGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Space space = (Space) shipGrid.CurrentCell.Value;
            weightAllowedOnTopLbl.Text = space.WeightAllowedOnTop.ToString();
            posLbl.Text = space.Position.ToString();
            if (space.Container != null)
            {
                containerLbl.Text = space.Container.ToString();
            }
            else
            {
                containerLbl.Text = "No container";
            }
        }
    }
}
