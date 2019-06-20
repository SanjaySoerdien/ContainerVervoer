using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            ErrorMessage result = ship.addContainer(containerToAdd);
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
            if (!ship.checkWeight())
            {
                int containerTotalWeight = 0;
                foreach (Container container in ship.Containers)
                {
                    containerTotalWeight += container.Weight;
                }
                int weightToAdd = (ship.MaxWeight / 2) - containerTotalWeight; 
                MessageBox.Show($"Not enough weight, add {weightToAdd} weight"); //TODO check dis
                return;
            }
            layersBox.Items.Clear();
            ship.PlaceContainersInShip();
            /*for (int i = 0; i < 12; i++)
            {
                layersBox.Items.Add(i); //TODO add total layers here
            }*/
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            int index = containerListBox.SelectedIndex;
            if (index > -1 )
            {
                containerListBox.Items.RemoveAt(index);
                ship.removeContainer(index);
            }
            else
            {
                MessageBox.Show("Select a container to remove");
            }
        }

        private void clearAllContainer_Click(object sender, EventArgs e)
        {
            ship.removeAllContainers();
            containerListBox.Items.Clear();
        }
    }
}
