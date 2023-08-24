using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad.WindowsFormsApp
{
    public partial class Form : System.Windows.Forms.Form
    {
        public string FilePath;
        private FileHandler FH = new FileHandler();
        public Form()
        {
            InitializeComponent();
            richTextBox1.ReadOnly = true;
            richTextBox1.Text = "Please load file";
            richTextBox1.Font = new Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular,
                                        System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        }

        private void wczytajToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = false;
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine("FileOK");
                FilePath = openFileDialog1.FileName;
                richTextBox1.Text = FH.ReadFile(FilePath);
                richTextBox1.ReadOnly = false;
            }
            
            


        }

        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog()==DialogResult.OK)
            {
                FH.WriteToFile(saveFileDialog1.FileName, richTextBox1.Text);
            }
            
        }

        private void usuńZawartośćPlikuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!richTextBox1.ReadOnly)
            {
                richTextBox1.Text = "";
            }
            
        }

        private void zamknijBezZapisywaniaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void zapiszIZamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FH.WriteToFile(saveFileDialog1.FileName, richTextBox1.Text);
            }
            Application.Exit();
        }
    }
}
