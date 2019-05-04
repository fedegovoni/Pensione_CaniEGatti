namespace Pensione_CaniEGatti.Grafica
{
    partial class AnagraficaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnagraficaForm));
            this._rubricaListView = new System.Windows.Forms.ListView();
            this._id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._cognome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._nome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._telefono = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._codiceFiscale = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._padroneDi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._inserisciPersonaButton = new System.Windows.Forms.Button();
            this._searchTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.modificaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancellaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _rubricaListView
            // 
            this._rubricaListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._id,
            this._cognome,
            this._nome,
            this._telefono,
            this._codiceFiscale,
            this._padroneDi});
            this._rubricaListView.FullRowSelect = true;
            this._rubricaListView.Location = new System.Drawing.Point(12, 43);
            this._rubricaListView.Name = "_rubricaListView";
            this._rubricaListView.Size = new System.Drawing.Size(1082, 433);
            this._rubricaListView.TabIndex = 0;
            this._rubricaListView.UseCompatibleStateImageBehavior = false;
            this._rubricaListView.View = System.Windows.Forms.View.Details;
            this._rubricaListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this._listView_ColumnClick);
            this._rubricaListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this._rubricaListView_MouseClick);
            this._rubricaListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this._rubricaListView_MouseDoubleClick);
            // 
            // _id
            // 
            this._id.Text = "ID";
            this._id.Width = 0;
            // 
            // _cognome
            // 
            this._cognome.Text = "Cognome";
            this._cognome.Width = 135;
            // 
            // _nome
            // 
            this._nome.Text = "Nome";
            this._nome.Width = 135;
            // 
            // _telefono
            // 
            this._telefono.Text = "Telefono";
            this._telefono.Width = 130;
            // 
            // _codiceFiscale
            // 
            this._codiceFiscale.Text = "Codice Fiscale";
            this._codiceFiscale.Width = 135;
            // 
            // _padroneDi
            // 
            this._padroneDi.Text = "PadroneDi";
            this._padroneDi.Width = 320;
            // 
            // _inserisciPersonaButton
            // 
            this._inserisciPersonaButton.Location = new System.Drawing.Point(976, 482);
            this._inserisciPersonaButton.Name = "_inserisciPersonaButton";
            this._inserisciPersonaButton.Size = new System.Drawing.Size(118, 23);
            this._inserisciPersonaButton.TabIndex = 2;
            this._inserisciPersonaButton.Text = "INSERISCI";
            this._inserisciPersonaButton.UseVisualStyleBackColor = true;
            this._inserisciPersonaButton.Click += new System.EventHandler(this._inserisciPersonaButton_Click);
            // 
            // _searchTextBox
            // 
            this._searchTextBox.Location = new System.Drawing.Point(67, 6);
            this._searchTextBox.Name = "_searchTextBox";
            this._searchTextBox.Size = new System.Drawing.Size(250, 22);
            this._searchTextBox.TabIndex = 1;
            this._searchTextBox.TextChanged += new System.EventHandler(this._searchTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Cerca:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modificaToolStripMenuItem,
            this.cancellaToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(144, 56);
            // 
            // modificaToolStripMenuItem
            // 
            this.modificaToolStripMenuItem.Name = "modificaToolStripMenuItem";
            this.modificaToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.modificaToolStripMenuItem.Text = "Modifica";
            this.modificaToolStripMenuItem.Click += new System.EventHandler(this.modificaToolStripMenuItem_Click);
            // 
            // cancellaToolStripMenuItem
            // 
            this.cancellaToolStripMenuItem.Name = "cancellaToolStripMenuItem";
            this.cancellaToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.cancellaToolStripMenuItem.Text = "Cancella";
            this.cancellaToolStripMenuItem.Click += new System.EventHandler(this.cancellaToolStripMenuItem_Click);
            // 
            // AnagraficaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 514);
            this.Controls.Add(this._searchTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._inserisciPersonaButton);
            this.Controls.Add(this._rubricaListView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AnagraficaForm";
            this.Text = "Rubrica";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView _rubricaListView;
        private System.Windows.Forms.Button _inserisciPersonaButton;
        private System.Windows.Forms.TextBox _searchTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader _cognome;
        private System.Windows.Forms.ColumnHeader _nome;
        private System.Windows.Forms.ColumnHeader _telefono;
        private System.Windows.Forms.ColumnHeader _codiceFiscale;
        private System.Windows.Forms.ColumnHeader _padroneDi;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem modificaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancellaToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader _id;
    }
}