using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Windows.Forms.VisualStyles;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;


namespace ScientificCalculator
{
    public partial class Form1 : Form
    {


       
        List<String> Filelist = new List<String>();
        GraphAlgorithms g;

        String calcHistory = "";
        String SavedCalcHistory = "";
        String result = "";
        String equation = "";
        double num;


        public Form1()
        {
            InitializeComponent();
            g = new GraphAlgorithms(toolStripProgressBar1, toolStripStatusLabel2, statusStrip2);
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

        

        

        

        private void TxtMatrix(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select File";
            openFileDialog.Filter = "txt files(*.txt)| *.txt";
            
            if (openFileDialog.ShowDialog() == DialogResult.OK) //test
            {
                g.ReadGraphFromTXTFile(openFileDialog.FileName);
                Filelist.Add(openFileDialog.FileName);

                listBox1.Items.Clear();


                for (int i = Filelist.Count - 1; i >= 0; i--)
                {
                    listBox1.Items.Add(Filelist[i]);

                }
            }
            
        }

        private void csvMatrix(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select File";
            openFileDialog.Filter = "csv files(*.csv)| *.csv";
            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                

                g.ReadGraphFromCSVFile(openFileDialog.FileName);
                Filelist.Add(openFileDialog.FileName);

                listBox1.Items.Clear();

                for (int i = Filelist.Count - 1; i >= 0; i--)
                {
                    listBox1.Items.Add(Filelist[i]);
                }
            }

            
        }

        private void txtcsvMatrix(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select File";
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "all supported(*.csv,*.txt)| *.csv; *.txt | csv files(*.csv) | *.csv | txt files(*.txt) | *.txt";
            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                
                foreach (string file in openFileDialog.FileNames)
                {
                    if (file[file.Length-1] == 't' ) //if .txt
                    {
                        g.ReadGraphFromTXTFile(file);
                        Filelist.Add(file);
                    }
                    else
                    {
                        g.ReadGraphFromCSVFile(file);
                        Filelist.Add(file);
                    }
                    //Bothlist.Add(openFileDialog.FileName);

                }
                listBox1.Items.Clear();
                for (int i = Filelist.Count - 1; i >= 0; i--)
                {
                    listBox1.Items.Add(Filelist[i]);
                }


            }
        }

        private void deleteGraph(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;
            Filelist.Remove(listBox1.SelectedItem.ToString());
            listBox1.Items.Remove(listBox1.SelectedItem.ToString());
            
            Console.WriteLine(Filelist.Count);
            
            
        }

        private void deleteAllGraphs(object sender, EventArgs e)
        {
            if (Filelist.Count == 0) return;
            for (int i = Filelist.Count - 1; i >= 0; i--)
            {
                listBox1.Items.Remove(Filelist[i]); //maybe to string
                Filelist.RemoveAt(i);

            }
            Console.WriteLine(Filelist.Count());
        }

        private void primAlgorithm(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;
            g.GetMST(listBox1.SelectedItem.ToString());
            listBox2.Items.Add("MST: " + listBox1.SelectedItem);


        }

        private void toolStripButton16_Click(object sender, EventArgs e)
        {

        }

        private void dijkstraAlgorithm(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return; // here is the glitch...
            g.Dijkstra((listBox1.SelectedItem.ToString()));
            listBox2.Items.Add("Shortest Paths: " + listBox1.SelectedItem);
        }

        private void saveGraphOperation(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem == null) return;
            if (((listBox2.SelectedItem).ToString())[0] == 'M')
            //if selected file was done by prim's algorithm
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //g.WriteMSTSolutionTo(AccessibleName, saveFileDialog.FileName);
                    g.WriteMSTSolutionTo(saveFileDialog.FileName, listBox1.SelectedItem.ToString());
                }
            }
            else // if selected file was done by djiskta's alg.
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    g.WriteSSSPSolutionTo(saveFileDialog.FileName, listBox1.SelectedItem.ToString());
                }
            }
            listBox2.Items.Remove(listBox2.SelectedItem.ToString());
        }
        private void digits_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            equation += b.Text;
            textBox1.Text += b.Text;

        }

        private void operation_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            equation += " " + b.Text + " ";
            textBox1.Text = b.Text + " "; 
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
            result = equation;
            result = new DataTable().Compute(equation, null).ToString();
            calcHistory += equation + " = " + result + "\n";
            textBox1.Text = result;
        }

        private void clear_Click(object sender, EventArgs e)  //-------------------------------
        {
            textBox1.Text = "";
            equation = "";
        }

        private void CE_Click(object sender, EventArgs e) //--------------------------------------
        {
            textBox1.Text = "";
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
