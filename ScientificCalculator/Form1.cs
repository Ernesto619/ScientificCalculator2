using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScientificCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void fromDate_ValueChanged(object sender, EventArgs e)
        {
            if (((DateTimePicker)sender).ContainsFocus)
            {
                DateTime to = toDate.Value;
                DateTime from = fromDate.Value;
                numericUpDown1.Value = to.Subtract(from).Days;
                numericUpDown1.Value = numericUpDown1.Value + (decimal)1;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.ContainsFocus)
            {
                decimal count = numericUpDown1.Value;
                if (count > 0)
                    toDate.Value = fromDate.Value.AddDays((double)count);
                else if (count < 0)
                    fromDate.Value = toDate.Value.AddDays((double)-count);
                else
                    toDate.Value = fromDate.Value;
            }
        }

        private void color_Calculator(object sender, EventArgs e)
        {
            ColorDialog calcColor = new ColorDialog();
            if (calcColor.ShowDialog() == DialogResult.OK)
            {
                tableLayoutPanel1.BackColor = calcColor.Color;
            }
        }

        private void dayColor(object sender, EventArgs e)
        {
            ColorDialog dayColored = new ColorDialog();
            if (dayColored.ShowDialog() == DialogResult.OK)
            {
                splitContainer2.Panel2.BackColor = dayColored.Color;
            }
        }

        private void graphColor(object sender, EventArgs e)
        {
            ColorDialog graphColored = new ColorDialog();
            if (graphColored.ShowDialog() == DialogResult.OK)
            {
                splitContainer1.Panel2.BackColor = graphColored.Color;
            }
            
        }
    }
}
