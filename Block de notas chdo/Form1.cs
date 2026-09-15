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

        private void GuardarArchivo(string ruta)
        {
            if (!(tabControl1.SelectedTab?.Controls[0] is RichTextBox rtb)) return;

            // Ya no necesitas reversiones porque rtb.Text contiene los atajos ocultos
            System.IO.File.WriteAllText(ruta, rtb.Text, System.Text.Encoding.UTF8);

            tabControl1.SelectedTab.Text = tabControl1.SelectedTab.Text.TrimEnd('*');
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

        // Declara el diccionario a nivel de clase para no recrearlo en cada pulsación
        // Diccionario que relaciona el texto con imágenes reales
        private readonly Dictionary<string, Image> _imagenesEmojis = new Dictionary<string, Image>
        {
            { ":)", Properties.Resources.CaritaFeliz },
            { ":(", Properties.Resources.CaritaTriste },
            { ";)", Properties.Resources.CaritaLengua }
        };

        private void NuevoRichTextBox_TextChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == null) return;

            if (!tabControl1.SelectedTab.Text.EndsWith("*"))
            {
                tabControl1.SelectedTab.Text += "*";
            }

            if (!(sender is RichTextBox rtb)) return;

            int cursorPos = rtb.SelectionStart;
            if (cursorPos == 0) return;

            // Evaluamos únicamente los últimos caracteres inmediatos al cursor
            foreach (var par in _imagenesEmojis) // <-- Asegúrate de que aquí diga _imagenesEmojis
            {
                int atajoLen = par.Key.Length;

                // Si el cursor ha avanzado al menos la longitud del atajo
                if (cursorPos >= atajoLen)
                {
                    // Extraer el fragmento recién tecleado
                    string fragmento = rtb.Text.Substring(cursorPos - atajoLen, atajoLen);

                    // AQUI ES DONDE VA EL CÓDIGO
                    if (fragmento == par.Key)
                    {
                        rtb.TextChanged -= NuevoRichTextBox_TextChanged;

                        // --- Guardamos tu tipo de letra y color actuales antes de hacer nada ---
                        Font fuenteNormal = rtb.SelectionFont ?? rtb.Font;
                        Color colorNormal = rtb.SelectionColor;

                        // 1. Seleccionamos el texto del atajo y lo ocultamos
                        rtb.Select(cursorPos - atajoLen, atajoLen);
                        rtb.SelectionColor = rtb.BackColor;
                        rtb.SelectionFont = new Font(fuenteNormal.FontFamily, 1);

                        // 2. Nos movemos justo después del texto oculto
                        rtb.SelectionStart = cursorPos;
                        rtb.SelectionLength = 0;

                        // 3. Pegamos la imagen adaptada a la altura de tu fuente normal
                        IDataObject portapapelesPrevio = Clipboard.GetDataObject();
                        Image emojiPequeño = RedimensionarImagen(par.Value, fuenteNormal.Height);
                        Clipboard.SetImage(emojiPequeño);

                        rtb.Paste();

                        if (portapapelesPrevio != null) Clipboard.SetDataObject(portapapelesPrevio);

                        // --- 4. LA SOLUCIÓN: FORZAR AL CURSOR A SALTAR LA IMAGEN ---
                        // Una imagen en RichTextBox cuenta como 1 espacio exacto. 
                        // Sumamos 1 al cursorPos original para ponernos a la derecha de la imagen.
                        rtb.SelectionStart = cursorPos + 1;
                        rtb.SelectionLength = 0; // Aseguramos que la imagen no se quede seleccionada

                        // 5. Ahora sí, aplicamos la fuente y color originales
                        rtb.SelectionFont = fuenteNormal;
                        rtb.SelectionColor = colorNormal;

                        rtb.TextChanged += NuevoRichTextBox_TextChanged;
                        break;
                    }
                }
            }
        }

        private void RenderizarImagenesAlAbrir(RichTextBox rtb)
        {
            // Apagamos el evento para no generar falsos positivos mientras modificamos el texto
            rtb.TextChanged -= NuevoRichTextBox_TextChanged;

            foreach (var par in _imagenesEmojis)
            {
                int startIndex = 0;

                while (startIndex < rtb.TextLength)
                {
                    int index = rtb.Text.IndexOf(par.Key, startIndex);
                    if (index == -1) break;

                    // Seleccionar el atajo
                    rtb.Select(index, par.Key.Length);

                    // Ocultarlo
                    rtb.SelectionColor = rtb.BackColor;
                    rtb.SelectionFont = new Font(rtb.Font.FontFamily, 1);

                    // Pegar la imagen a la derecha adaptada al tamaño
                    rtb.SelectionStart = index + par.Key.Length;
                    rtb.SelectionLength = 0;

                    IDataObject portapapelesPrevio = Clipboard.GetDataObject();

                    // Redimensionamos usando la fuente actual del documento
                    Image emojiPequeño = RedimensionarImagen(par.Value, rtb.Font.Height);
                    Clipboard.SetImage(emojiPequeño);

                    rtb.Paste();
                    if (portapapelesPrevio != null) Clipboard.SetDataObject(portapapelesPrevio);

                    // Avanzar el índice de búsqueda
                    startIndex = index + par.Key.Length;
                }
            }

            rtb.TextChanged += NuevoRichTextBox_TextChanged;
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

                RenderizarImagenesAlAbrir(rtbActual);

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

        private Image RedimensionarImagen(Image imagenOriginal, int alturaDeseada)
        {
            // Calculamos el ancho para que no se deforme
            int anchuraDeseada = (imagenOriginal.Width * alturaDeseada) / imagenOriginal.Height;

            Bitmap imagenRedimensionada = new Bitmap(anchuraDeseada, alturaDeseada);

            using (Graphics g = Graphics.FromImage(imagenRedimensionada))
            {
                // Mejoramos la calidad visual al hacerla pequeña
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(imagenOriginal, 0, 0, anchuraDeseada, alturaDeseada);
            }

            return imagenRedimensionada;
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            RichTextBox rtbActual = ObtenerRichTextBoxActual();
            if (rtbActual == null) return;

            Font fuenteActual = rtbActual.SelectionLength > 0 ? rtbActual.SelectionFont : rtbActual.Font;

            if (fuenteActual != null)
            {
                //Calculamos el nuevo tamaño (sumamos 2 puntos al tamaño actual)
                float nuevoTamaño = fuenteActual.Size + 2F;

                if (nuevoTamaño <= 80F)
                {
                    Font nuevaFuente = new Font(fuenteActual.FontFamily, nuevoTamaño, fuenteActual.Style);

                    if (rtbActual.SelectionLength > 0)
                    {
                        rtbActual.SelectionFont = nuevaFuente; // Aplica solo al texto sombreado
                    }
                    else
                    {
                        rtbActual.Font = nuevaFuente; // Aplica a toda la hoja si no hay selección
                    }
                }
            }
        }

        private void toolStripButton2_Click_2(object sender, EventArgs e)
        {
            RichTextBox rtbActual = ObtenerRichTextBoxActual();
            if (rtbActual == null) return;

            Font fuenteActual = rtbActual.SelectionLength > 0 ? rtbActual.SelectionFont : rtbActual.Font;

            if (fuenteActual != null)
            {
                // Restamos 2 puntos al tamaño actual
                float nuevoTamaño = fuenteActual.Size - 2F;

                // Ponemos un límite mínimo (ej. 8 puntos) para que la letra no desaparezca
                if (nuevoTamaño >= 8F)
                {
                    Font nuevaFuente = new Font(fuenteActual.FontFamily, nuevoTamaño, fuenteActual.Style);

                    if (rtbActual.SelectionLength > 0)
                    {
                        rtbActual.SelectionFont = nuevaFuente;
                    }
                    else
                    {
                        rtbActual.Font = nuevaFuente;
                    }
                }
            }
        }

        private void Negrita_Click(object sender, EventArgs e)
        {
            RichTextBox rtbActual = ObtenerRichTextBoxActual();
            if (rtbActual == null) return;

            // Evaluamos la fuente actual del texto seleccionado o de la hoja entera
            Font fuenteActual = rtbActual.SelectionLength > 0 ? rtbActual.SelectionFont : rtbActual.Font;

            if (fuenteActual != null)
            {
                FontStyle nuevoEstilo = fuenteActual.Style ^ FontStyle.Bold;
                Font nuevaFuente = new Font(fuenteActual.FontFamily, fuenteActual.Size, nuevoEstilo);

                if (rtbActual.SelectionLength > 0)
                    rtbActual.SelectionFont = nuevaFuente; // Cambia solo lo seleccionado
                else
                    rtbActual.Font = nuevaFuente; // Cambia toda la hoja si no hay selección
            }
        }

        private void cursiva_Click(object sender, EventArgs e)
        {
            RichTextBox rtbActual = ObtenerRichTextBoxActual();
            if (rtbActual == null) return;

            Font fuenteActual = rtbActual.SelectionLength > 0 ? rtbActual.SelectionFont : rtbActual.Font;

            if (fuenteActual != null)
            {
                FontStyle nuevoEstilo = fuenteActual.Style ^ FontStyle.Italic;
                Font nuevaFuente = new Font(fuenteActual.FontFamily, fuenteActual.Size, nuevoEstilo);

                if (rtbActual.SelectionLength > 0)
                    rtbActual.SelectionFont = nuevaFuente;
                else
                    rtbActual.Font = nuevaFuente;
            }
        }

        private void Sub_Click(object sender, EventArgs e)
        {
            RichTextBox rtbActual = ObtenerRichTextBoxActual();
            if (rtbActual == null) return;

            Font fuenteActual = rtbActual.SelectionLength > 0 ? rtbActual.SelectionFont : rtbActual.Font;

            if (fuenteActual != null)
            {
                
                FontStyle nuevoEstilo = fuenteActual.Style ^ FontStyle.Underline;
                Font nuevaFuente = new Font(fuenteActual.FontFamily, fuenteActual.Size, nuevoEstilo);

                if (rtbActual.SelectionLength > 0)
                    rtbActual.SelectionFont = nuevaFuente;
                else
                    rtbActual.Font = nuevaFuente;
            }
        }

        private void tachado_Click(object sender, EventArgs e)
        {
            RichTextBox rtbActual = ObtenerRichTextBoxActual();
            if (rtbActual == null) return;

            Font fuenteActual = rtbActual.SelectionLength > 0 ? rtbActual.SelectionFont : rtbActual.Font;

            if (fuenteActual != null)
            {
                FontStyle nuevoEstilo = fuenteActual.Style ^ FontStyle.Strikeout;
                Font nuevaFuente = new Font(fuenteActual.FontFamily, fuenteActual.Size, nuevoEstilo);

                if (rtbActual.SelectionLength > 0)
                    rtbActual.SelectionFont = nuevaFuente;
                else
                    rtbActual.Font = nuevaFuente;
            }
        }
    }
}
