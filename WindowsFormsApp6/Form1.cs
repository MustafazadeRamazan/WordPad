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

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            font_box.Items.AddRange((from i in FontFamily.Families select i.Name).ToArray());
            color_box.Items.Clear();
            string[] colores = Enum.GetNames(typeof(System.Drawing.KnownColor));
            color_box.Items.AddRange(colores);
        }

        private void loadbtn_click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "All files|*.*|Text files|*.txt";

            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using(StreamReader sr = new StreamReader(openFileDialog1.FileName))
                {
                    richTextBox1.Text = sr.ReadToEnd();
                }
            }
        }

        private void savebtn_click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                {
                    sw.Write(richTextBox1.Text);
                }
            }
        }

        private void font_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(font_box.SelectedItem.ToString(), float.Parse(size_box.SelectedItem.ToString()));
        }

        private void color_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionColor = Color.FromName(color_box.Text);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox cb)
            {
                if (cb.Checked)
                {
                    var fontStyle = richTextBox1.SelectionFont.Style;
                    if (cb.Text == "B")
                        fontStyle |= FontStyle.Bold;
                    if (cb.Text == "U")
                        fontStyle |= FontStyle.Underline;
                    if (cb.Text == "I")
                        fontStyle |= FontStyle.Italic;

                    richTextBox1.SelectionFont = new Font(font_box.SelectedItem.ToString(), float.Parse(size_box.SelectedItem.ToString()), fontStyle);
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }
    }
}
