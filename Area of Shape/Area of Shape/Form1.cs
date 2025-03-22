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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cmbShape.Items.AddRange(new string[] {
                "Trapezium", "Circle", "Rectangle", "Triangle",
                "Square", "Parallelogram", "Kite", "Prism", "Cylinder", "Rhombus"
            });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblInput1.Text = "Enter First Value:";
            lblInput2.Text = "Enter Second Value:";
            btnClose.Visible = true; // Ensure it's visible on startup
        }





        private async void btnCalculate_Click(object sender, EventArgs e)
        {
            // Reset result label and progress bar
            lblResult.Text = "Calculating...";
            lblResult.ForeColor = Color.Black;


            // Validate input fields
            if (!double.TryParse(txtInput1.Text, out double input1) ||
                !double.TryParse(txtInput2.Text, out double input2))
            {
                MessageBox.Show("Please enter valid numeric values.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                lblResult.Text = "Error: Invalid Input!";
                lblResult.ForeColor = Color.Red;
                return;
            }

            // Validate shape selection
            if (cmbShape.SelectedItem == null)
            {
                MessageBox.Show("Please select a shape first.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                lblResult.Text = "Error: No Shape Selected!";
                lblResult.ForeColor = Color.Red;
                return;
            }

            string shape = cmbShape.SelectedItem.ToString();
            double result = 0;

            switch (shape)
            {
                case "Trapezium": result = (input1 + input2) * 0.5; break;
                case "Circle": result = Math.PI * input1 * input1; break;
                case "Rectangle": result = input1 * input2; break;
                case "Triangle": result = 0.5 * input1 * input2; break;
                case "Square": result = input1 * input1; break;
                case "Parallelogram": result = input1 * input2; break;
                case "Kite": result = 0.5 * input1 * input2; break;
                case "Prism": result = 2 * input1 + input2; break;
                case "Cylinder": result = 2 * Math.PI * input1 * input2 + 2 * Math.PI * input1 * input1; break;
                case "Rhombus": result = 0.5 * input1 * input2; break;
                default:
                    MessageBox.Show("Unknown shape selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    lblResult.Text = "Error: Unknown Shape!";
                    lblResult.ForeColor = Color.Red;
                    return;
            }

            // Animate progress bar for smooth UI effect
            for (int i = 0; i <= 100; i += 10)
            {

                await Task.Delay(50);

            }


            // Show the final result
            lblResult.Text = $"Area: {result:F2}";
            lblResult.ForeColor = Color.DarkGreen;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmbShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            string shape = cmbShape.SelectedItem.ToString();

            // Reset visibility
            lblInput1.Visible = true;
            lblInput2.Visible = true;
            txtInput1.Visible = true;
            txtInput2.Visible = true;

            switch (shape)
            {
                case "Circle":
                    lblInput1.Text = "Enter Radius:";
                    lblInput2.Visible = false;
                    txtInput2.Visible = false; // Circle only needs one input (radius)
                    break;

                case "Rectangle":
                case "Parallelogram":
                    lblInput1.Text = "Enter Length:";
                    lblInput2.Text = "Enter Width:";
                    break;

                case "Triangle":
                    lblInput1.Text = "Enter Base:";
                    lblInput2.Text = "Enter Height:";
                    break;

                case "Square":
                    lblInput1.Text = "Enter Side:";
                    lblInput2.Visible = false;
                    txtInput2.Visible = false; // Square needs only one input
                    break;

                case "Trapezium":
                    lblInput1.Text = "Enter Base 1:";
                    lblInput2.Text = "Enter Base 2:";
                    break;

                case "Kite":
                case "Rhombus":
                    lblInput1.Text = "Enter Diagonal 1:";
                    lblInput2.Text = "Enter Diagonal 2:";
                    break;

                case "Prism":
                    lblInput1.Text = "Enter Base Area:";
                    lblInput2.Text = "Enter Height:";
                    break;

                case "Cylinder":
                    lblInput1.Text = "Enter Radius:";
                    lblInput2.Text = "Enter Height:";
                    break;

                default:
                    lblInput1.Text = "Enter First Value:";
                    lblInput2.Text = "Enter Second Value:";
                    break;
            }
        }

       

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            btnClose.Image = Properties.Resources.close_hover; // Change image on hover
            btnClose.BackgroundImageLayout = ImageLayout.Center; // Keeps proportions
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            btnClose.Image = Properties.Resources.close; // Restore default image
            btnClose.BackgroundImageLayout = ImageLayout.Center;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
