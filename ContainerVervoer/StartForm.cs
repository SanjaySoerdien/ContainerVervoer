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
        }

        private void GoBtn_Click(object sender, EventArgs e)
        {
            int width = -1;
            int length = -1;
            //try
            //{
                width = Convert.ToInt32(widthBox.Text);
                length = Convert.ToInt32(lengthBox.Text);
                if (width <= 0 || length <= 0)
                {
                    throw new Exception("Insert values higher than 0!");
       
                }
                else if (width > length)
                {
                    return; //delete dit als je exeptions er weer in gooit
                    throw new Exception("Insert higher length then width");
                }
                ShipView view = new ShipView(width,length);
                this.Hide();          
                view.ShowDialog();     
                this.Show();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

    }
}
