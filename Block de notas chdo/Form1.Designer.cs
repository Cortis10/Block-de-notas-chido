namespace Block_de_notas_chdo
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaPestañaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarComoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarPestañaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Guardar_Icono = new System.Windows.Forms.ToolStripButton();
            this.cntrlX = new System.Windows.Forms.ToolStripButton();
            this.CntrlY = new System.Windows.Forms.ToolStripButton();
            this.cortar = new System.Windows.Forms.ToolStripButton();
            this.copiar = new System.Windows.Forms.ToolStripButton();
            this.Pegar = new System.Windows.Forms.ToolStripButton();
            this.Grande = new System.Windows.Forms.ToolStripButton();
            this.chica = new System.Windows.Forms.ToolStripButton();
            this.Negrita = new System.Windows.Forms.ToolStripButton();
            this.cursiva = new System.Windows.Forms.ToolStripButton();
            this.Sub = new System.Windows.Forms.ToolStripButton();
            this.tachado = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(971, 474);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.richTextBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(977, 480);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1108, 33);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaPestañaToolStripMenuItem,
            this.abrirToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.guardarComoToolStripMenuItem,
            this.cerrarPestañaToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 32);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // nuevaPestañaToolStripMenuItem
            // 
            this.nuevaPestañaToolStripMenuItem.Name = "nuevaPestañaToolStripMenuItem";
            this.nuevaPestañaToolStripMenuItem.Size = new System.Drawing.Size(229, 34);
            this.nuevaPestañaToolStripMenuItem.Text = "Nueva Pestaña";
            this.nuevaPestañaToolStripMenuItem.Click += new System.EventHandler(this.nuevaPestañaToolStripMenuItem_Click_1);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(229, 34);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(229, 34);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // guardarComoToolStripMenuItem
            // 
            this.guardarComoToolStripMenuItem.Name = "guardarComoToolStripMenuItem";
            this.guardarComoToolStripMenuItem.Size = new System.Drawing.Size(229, 34);
            this.guardarComoToolStripMenuItem.Text = "Guardar como";
            this.guardarComoToolStripMenuItem.Click += new System.EventHandler(this.guardarComoToolStripMenuItem_Click_1);
            // 
            // cerrarPestañaToolStripMenuItem
            // 
            this.cerrarPestañaToolStripMenuItem.Name = "cerrarPestañaToolStripMenuItem";
            this.cerrarPestañaToolStripMenuItem.Size = new System.Drawing.Size(229, 34);
            this.cerrarPestañaToolStripMenuItem.Text = "Cerrar Pestaña";
            this.cerrarPestañaToolStripMenuItem.Click += new System.EventHandler(this.cerrarPestañaToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(229, 34);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Guardar_Icono,
            this.cntrlX,
            this.CntrlY,
            this.cortar,
            this.copiar,
            this.Pegar,
            this.Grande,
            this.chica,
            this.Negrita,
            this.cursiva,
            this.Sub,
            this.tachado});
            this.toolStrip1.Location = new System.Drawing.Point(0, 33);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1108, 34);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Guardar_Icono
            // 
            this.Guardar_Icono.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Guardar_Icono.Image = ((System.Drawing.Image)(resources.GetObject("Guardar_Icono.Image")));
            this.Guardar_Icono.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Guardar_Icono.Name = "Guardar_Icono";
            this.Guardar_Icono.Size = new System.Drawing.Size(34, 29);
            this.Guardar_Icono.Click += new System.EventHandler(this.Guardar_Icono_Click);
            // 
            // cntrlX
            // 
            this.cntrlX.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cntrlX.Image = ((System.Drawing.Image)(resources.GetObject("cntrlX.Image")));
            this.cntrlX.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cntrlX.Name = "cntrlX";
            this.cntrlX.Size = new System.Drawing.Size(34, 33);
            this.cntrlX.Text = "toolStripButton2";
            this.cntrlX.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // CntrlY
            // 
            this.CntrlY.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CntrlY.Image = ((System.Drawing.Image)(resources.GetObject("CntrlY.Image")));
            this.CntrlY.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CntrlY.Name = "CntrlY";
            this.CntrlY.Size = new System.Drawing.Size(34, 33);
            this.CntrlY.Text = "toolStripButton3";
            this.CntrlY.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // cortar
            // 
            this.cortar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cortar.Image = ((System.Drawing.Image)(resources.GetObject("cortar.Image")));
            this.cortar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cortar.Name = "cortar";
            this.cortar.Size = new System.Drawing.Size(34, 33);
            this.cortar.Text = "toolStripButton1";
            this.cortar.Click += new System.EventHandler(this.cortar_Click);
            // 
            // copiar
            // 
            this.copiar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copiar.Image = ((System.Drawing.Image)(resources.GetObject("copiar.Image")));
            this.copiar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copiar.Name = "copiar";
            this.copiar.Size = new System.Drawing.Size(34, 33);
            this.copiar.Text = "toolStripButton2";
            this.copiar.Click += new System.EventHandler(this.toolStripButton2_Click_1);
            // 
            // Pegar
            // 
            this.Pegar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Pegar.Image = ((System.Drawing.Image)(resources.GetObject("Pegar.Image")));
            this.Pegar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Pegar.Name = "Pegar";
            this.Pegar.Size = new System.Drawing.Size(34, 33);
            this.Pegar.Text = "toolStripButton3";
            this.Pegar.Click += new System.EventHandler(this.Pegar_Click);
            // 
            // Grande
            // 
            this.Grande.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Grande.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Grande.Name = "Grande";
            this.Grande.Size = new System.Drawing.Size(44, 29);
            this.Grande.Text = "Aaˆ";
            this.Grande.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Grande.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // chica
            // 
            this.chica.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.chica.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.chica.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.chica.Name = "chica";
            this.chica.Size = new System.Drawing.Size(34, 29);
            this.chica.Text = "Aaˇ";
            this.chica.Click += new System.EventHandler(this.toolStripButton2_Click_2);
            // 
            // Negrita
            // 
            this.Negrita.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Negrita.Image = ((System.Drawing.Image)(resources.GetObject("Negrita.Image")));
            this.Negrita.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Negrita.Name = "Negrita";
            this.Negrita.Size = new System.Drawing.Size(34, 33);
            this.Negrita.Text = "toolStripButton1";
            this.Negrita.Click += new System.EventHandler(this.Negrita_Click);
            // 
            // cursiva
            // 
            this.cursiva.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cursiva.Image = global::Block_de_notas_chdo.Properties.Resources._59377;
            this.cursiva.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cursiva.Name = "cursiva";
            this.cursiva.Size = new System.Drawing.Size(34, 33);
            this.cursiva.Text = "__";
            this.cursiva.Click += new System.EventHandler(this.cursiva_Click);
            // 
            // Sub
            // 
            this.Sub.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Sub.Image = ((System.Drawing.Image)(resources.GetObject("Sub.Image")));
            this.Sub.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Sub.Name = "Sub";
            this.Sub.Size = new System.Drawing.Size(34, 33);
            this.Sub.Text = "toolStripButton1";
            this.Sub.Click += new System.EventHandler(this.Sub_Click);
            // 
            // tachado
            // 
            this.tachado.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tachado.Image = ((System.Drawing.Image)(resources.GetObject("tachado.Image")));
            this.tachado.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tachado.Name = "tachado";
            this.tachado.Size = new System.Drawing.Size(34, 33);
            this.tachado.Text = "toolStripButton1";
            this.tachado.Click += new System.EventHandler(this.tachado_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 67);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1108, 569);
            this.tabControl1.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 636);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Block de Notas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabPage1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaPestañaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarComoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarPestañaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStripButton Guardar_Icono;
        private System.Windows.Forms.ToolStripButton cntrlX;
        private System.Windows.Forms.ToolStripButton CntrlY;
        private System.Windows.Forms.ToolStripButton cortar;
        private System.Windows.Forms.ToolStripButton copiar;
        private System.Windows.Forms.ToolStripButton Pegar;
        private System.Windows.Forms.ToolStripButton Grande;
        private System.Windows.Forms.ToolStripButton chica;
        private System.Windows.Forms.ToolStripButton Negrita;
        private System.Windows.Forms.ToolStripButton cursiva;
        private System.Windows.Forms.ToolStripButton Sub;
        private System.Windows.Forms.ToolStripButton tachado;
    }
}

