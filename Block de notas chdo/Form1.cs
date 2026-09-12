using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;

namespace Block_de_notas_chdo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog ofd = new SaveFileDialog();

            ofd.AddExtension = true;
            ofd.Filter = "Archivo de texto|*.txt";
            DialogResult res = ofd.ShowDialog();

            if (res == DialogResult.OK)
                File.WriteAllText(ofd.FileName, richTextBox1.Text);
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.AddExtension = true;
            ofd.Filter = "Archivo de texto|*.txt";
            DialogResult res = ofd.ShowDialog();

            if (res == DialogResult.OK)
                richTextBox1.Text = File.ReadAllText(ofd.FileName);
        }
    }
}
