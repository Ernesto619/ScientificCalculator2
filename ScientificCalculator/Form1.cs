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
        String calcHistory = "";
        String SavedCalcHistory = "";
        String result = "";
        double num;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
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

        private void calcFontChange_Click(object sender, EventArgs e)
        {
            FontDialog font = new FontDialog();
            if (font.ShowDialog() != DialogResult.Cancel)
            {
                textBox1.Font = font.Font;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Good Day! Today is " + DateTime.Now;
        }

        private void digits_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            textBox1.Text += b.Text;

        }

        private void operation_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            textBox1.Text += " " + b.Text + " ";
        }

        private void numberSign_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Contains('-'))
            {
                textBox1.Text.Remove('-');
            }
            if (!textBox1.Text.Contains('-'))
            {
                textBox1.Text += "-";
            }
        }

        private void percent_Click(object sender, EventArgs e)
        {
            textBox1.Text += "/100 ";
        }

        private void OneOverX_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1/";
        }

        private void square_Click(object sender, EventArgs e)
        {
            calcHistory += textBox1.Text + " Sqaured = ";
            num = Convert.ToInt32(textBox1.Text);
            num = Math.Pow(num, 2);
            textBox1.Text = num.ToString();
            calcHistory += textBox1.Text + "\n";
        }

        private void sqRoot_click(object sender, EventArgs e)
        {
            calcHistory += "Square Root of " + textBox1.Text + " = ";
            num = Convert.ToInt32(textBox1.Text);
            num = Math.Sqrt(num);
            textBox1.Text = num.ToString();
            calcHistory += textBox1.Text + "\n";
            
        }

        private void equals_Click(object sender, EventArgs e)
        {
            result = textBox1.Text;
            result = new DataTable().Compute(textBox1.Text, null).ToString();
            calcHistory += textBox1.Text + " = " + result + "\n";
            textBox1.Text = result;
        }

        private void clear_Click(object sender, EventArgs e)  //-------------------------------
        {
            textBox1.Text = "";
        }

        private void CE_Click(object sender, EventArgs e) //--------------------------------------
        {

        }

        private void calcHistory_Click(object sender, EventArgs e)
        {
            MessageBox.Show(calcHistory + "\n" + "\nSaved History:\n" + SavedCalcHistory);
        }

        private void clearCalcHistory_Click(object sender, EventArgs e)
        {
            calcHistory = "";
        }

        private void saveCalcHistory_Click(object sender, EventArgs e)
        {
            SavedCalcHistory += calcHistory;
        }

        private void printCalcHistory_Click(object sender, EventArgs e)
        {

        }

        private void about_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is a scientific calculator with nice graphs!\n\n By: Ernesto Riera & Samuel Pellot");
        }
    }
}
