using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Area_of_Shape
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            Form1 nextForm = new Form1(); // Ensure Form2 exists
            nextForm.Show();
            this.Hide(); // Hides current form
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.Image = Properties.Resources.close_hover; // Change image on hover
            btnClose.BackgroundImageLayout = ImageLayout.Center; // Keeps proportions
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.Image = Properties.Resources.close; // Restore default image
            btnClose.BackgroundImageLayout = ImageLayout.Center;
        }
    }
}
