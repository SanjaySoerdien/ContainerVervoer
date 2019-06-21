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
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
           // openQuickNewForm();
        }

        private void GoBtn_Click(object sender, EventArgs e)
        {
            int width = -1;
            int length = -1;
            try
            {
                width = Convert.ToInt32(widthBox.Text);
                length = Convert.ToInt32(lengthBox.Text);
                if (width <= 0 || length <= 0)
                {
                    throw new Exception("Insert values higher than 0!");
                }
                else if (width > length)
                {
                    throw new Exception("Insert higher length then width");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            openNewForm(width, length);
        }

        private void openNewForm(int width, int length)
        {
            ShipView view = new ShipView(width, length);
            this.Hide();
            view.ShowDialog();
            this.Show();
        }

        private void openQuickNewForm()
        {
            ShipView view = new ShipView(5, 10);
            this.Hide();
            view.ShowDialog();
            this.Show();
        }
    }
}
