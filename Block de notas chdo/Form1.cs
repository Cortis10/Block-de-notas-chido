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

        private RichTextBox ObtenerRichTextBoxActual()
        {
            if (tabControl1.SelectedTab != null && tabControl1.SelectedTab.Controls.Count > 0)
            {
                if (tabControl1.SelectedTab.Controls[0] is RichTextBox rtb)
                {
                    return rtb;
                }
            }
            return null;
        }

        private bool GuardarArchivoComo()
        {
            RichTextBox rtbActual = ObtenerRichTextBoxActual();
            if (rtbActual == null) return false;

            SaveFileDialog ofd = new SaveFileDialog();
            ofd.AddExtension = true;
            ofd.Filter = "Archivo de texto|*.txt";
            DialogResult res = ofd.ShowDialog();

            if (res == DialogResult.OK)
            {
                File.WriteAllText(ofd.FileName, rtbActual.Text);

                tabControl1.SelectedTab.Text = Path.GetFileName(ofd.FileName);
                tabControl1.SelectedTab.Tag = ofd.FileName; // Guardar ruta
                return true;
            }

            return false;
        }
        private void guardar()
        {
            RichTextBox rtbActual = ObtenerRichTextBoxActual();
            if (rtbActual == null) return;

            // Checa si la pestaña ya está conectada a un archivo existente
            if (tabControl1.SelectedTab.Tag != null)
            {
                string rutaArchivo = tabControl1.SelectedTab.Tag.ToString();
                File.WriteAllText(rutaArchivo, rtbActual.Text);

                tabControl1.SelectedTab.Text = Path.GetFileName(rutaArchivo);
            }
            else
            {
                GuardarArchivoComo();
            }
        }

        private void nuevaPestaña()
        {
            TabPage nuevaPestaña = new TabPage();
            nuevaPestaña.Text = "Sin Título*"; // Inicia con asterisco porque no se ha guardado en disco

            // Crea el RichTextBox que va a ir dentro de la nueva pestaña
            RichTextBox nuevoRichTextBox = new RichTextBox();
            nuevoRichTextBox.Dock = DockStyle.Fill;
            nuevoRichTextBox.BorderStyle = BorderStyle.None;

            //Checa cuando el usuario escriba en esta pestaña
            nuevoRichTextBox.TextChanged += NuevoRichTextBox_TextChanged;

            // Añade el RichTextBox a la pestaña, y la pestaña al TabControl
            nuevaPestaña.Controls.Add(nuevoRichTextBox);
            tabControl1.TabPages.Add(nuevaPestaña);

            tabControl1.SelectedTab = nuevaPestaña;
        }

        private void NuevoRichTextBox_TextChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab != null && !tabControl1.SelectedTab.Text.EndsWith("*"))
            {
                tabControl1.SelectedTab.Text += "*";
            }
        }





        private void guardarComoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            GuardarArchivoComo();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox rtbActual = ObtenerRichTextBoxActual();

            // Por si el RichTextBox actual tiene texto, crea una nueva pestaña 
            if (rtbActual != null && !string.IsNullOrEmpty(rtbActual.Text))
            {
                nuevaPestaña();
            }
            else if (tabControl1.SelectedTab == null)
            {
                nuevaPestaña();
            }

            rtbActual = ObtenerRichTextBoxActual();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.AddExtension = true;
            ofd.Filter = "Archivo de texto|*.txt";
            DialogResult res = ofd.ShowDialog();

            if (res == DialogResult.OK)
            {
                rtbActual.Text = File.ReadAllText(ofd.FileName);
                // Al abrirlo está sincronizado con el disco, va sin asterisco
                tabControl1.SelectedTab.Text = Path.GetFileName(ofd.FileName);
                tabControl1.SelectedTab.Tag = ofd.FileName;
            }
        }

        private void nuevaPestañaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            nuevaPestaña();
        }

        private void cerrarPestañaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Verifica si hay alguna pestaña abierta para poder cerrarla
            if (tabControl1.SelectedTab == null) return;

            // Si el archivo ya existía y no se modificó nada, se cierra directo.
            if (tabControl1.SelectedTab.Text.EndsWith("*"))
            {
                DialogResult resultado = MessageBox.Show(
                    "¿Deseas guardar los cambios antes de cerrar? Si no los guardas, se perderá todo.",
                    "Guardar cambios",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning
                );

                if (resultado == DialogResult.Yes)
                {
                    // Si ya tiene ruta guardada previamente, sobreescribimos directo
                    if (tabControl1.SelectedTab.Tag != null)
                    {
                        RichTextBox rtbActual = ObtenerRichTextBoxActual();
                        if (rtbActual != null)
                        {
                            File.WriteAllText(tabControl1.SelectedTab.Tag.ToString(), rtbActual.Text);
                        }
                    }
                    else // Si es un archivo nuevo sin ruta, abrimos el "Guardar Como"
                    {
                        if (GuardarArchivoComo() == false)
                        {
                            return; // Canceló el guardado, se detiene el cierre de pestaña
                        }
                    }
                }
                else if (resultado == DialogResult.Cancel)
                {
                    return; // Se arrepintió, mantiene la pestaña abierta
                }
            }

            // Remueve la pestaña seleccionada
            tabControl1.TabPages.Remove(tabControl1.SelectedTab);

            // Si ya no quedan pestañas en el programa, cerramos la app por completo
            if (tabControl1.TabPages.Count == 0) Close();
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guardar();   
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (TabPage pestaña in tabControl1.TabPages)
            {
                RichTextBox rtb = pestaña.Controls[0] as RichTextBox;

                // Si el título termina con '*', significa que hay texto nuevo o modificaciones sin guardar
                if (pestaña.Text.EndsWith("*"))
                {
                    tabControl1.SelectedTab = pestaña; // Enfoca la pestaña con cambios pendientes

                    DialogResult respuesta = MessageBox.Show(
                        $"La pestaña '{pestaña.Text.Replace("*", "")}' tiene cambios sin guardar. ¿Quieres guardarla antes de salir?",
                        "Salir del programa",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Warning
                    );

                    if (respuesta == DialogResult.Yes)
                    {
                        // Si ya tiene archivo físico asociado, se auto-guarda directo
                        if (pestaña.Tag != null)
                        {
                            guardar();
                        }
                        else
                        {
                            GuardarArchivoComo();
                        }
                    }
                    else if (respuesta == DialogResult.Cancel)
                    {
                        e.Cancel = true; // Freno de mano: cancela el cierre total del programa
                        return;
                    }
                    // Si responde 'No', el bucle continúa revisando la siguiente pestaña
                }
            }
        }

        private void Guardar_Icono_Click(object sender, EventArgs e)
        {
            guardar();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            RichTextBox rtbActual = ObtenerRichTextBoxActual();

            // 2. Si hay una pestaña abierta y tiene historial para deshacer, hacemos el Undo
            if (rtbActual != null && rtbActual.CanUndo)
            {
                rtbActual.Undo();
            }

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            RichTextBox rtbActual = ObtenerRichTextBoxActual();

            if (rtbActual != null && rtbActual.CanRedo)
            {
                rtbActual.Redo();
            }
        }

        private void cortar_Click(object sender, EventArgs e)
        {
            RichTextBox rtbActual = ObtenerRichTextBoxActual();
            if (rtbActual != null && rtbActual.SelectionLength > 0)
            {
                rtbActual.Cut(); // Corta el texto seleccionado y lo manda al portapapeles
            }
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            RichTextBox rtbActual = ObtenerRichTextBoxActual();
            if (rtbActual != null && rtbActual.SelectionLength > 0)
            {
                rtbActual.Copy(); // Copia el texto seleccionado al portapapeles
            }
        }

        private void Pegar_Click(object sender, EventArgs e)
        {
            RichTextBox rtbActual = ObtenerRichTextBoxActual();

            // Verifica que haya una pestaña abierta y que el portapapeles de Windows tenga texto para pegar
            if (rtbActual != null && Clipboard.ContainsText())
            {
                rtbActual.Paste(); // Pega el texto en la posición del cursor
            }
        }

    }
}
