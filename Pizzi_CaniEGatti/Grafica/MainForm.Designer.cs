namespace Pizzi_CaniEGatti
{
    partial class MainForm
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this._inserisciButton = new System.Windows.Forms.Button();
            this._cercaButton = new System.Windows.Forms.Button();
            this._prenotazioniListView = new System.Windows.Forms.ListView();
            this._id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._animale = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._nome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._cognome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._telefono = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._entrata = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._uscita = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._numBox = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._listaBox = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._toDoText = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.modificaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancellaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this._searchTextBox = new System.Windows.Forms.TextBox();
            this._rubricaButton = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _inserisciButton
            // 
            this._inserisciButton.Location = new System.Drawing.Point(1289, 764);
            this._inserisciButton.Name = "_inserisciButton";
            this._inserisciButton.Size = new System.Drawing.Size(98, 23);
            this._inserisciButton.TabIndex = 2;
            this._inserisciButton.Text = "INSERISCI";
            this._inserisciButton.UseVisualStyleBackColor = true;
            this._inserisciButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // _cercaButton
            // 
            this._cercaButton.Location = new System.Drawing.Point(1393, 764);
            this._cercaButton.Name = "_cercaButton";
            this._cercaButton.Size = new System.Drawing.Size(130, 23);
            this._cercaButton.TabIndex = 3;
            this._cercaButton.Text = "DISPONIBILITA\'";
            this._cercaButton.UseVisualStyleBackColor = true;
            this._cercaButton.Click += new System.EventHandler(this._cercaButton_Click);
            // 
            // _prenotazioniListView
            // 
            this._prenotazioniListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._id,
            this._animale,
            this._nome,
            this._cognome,
            this._telefono,
            this._entrata,
            this._uscita,
            this._numBox,
            this._listaBox});
            this._prenotazioniListView.FullRowSelect = true;
            this._prenotazioniListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this._prenotazioniListView.Location = new System.Drawing.Point(12, 41);
            this._prenotazioniListView.Name = "_prenotazioniListView";
            this._prenotazioniListView.Size = new System.Drawing.Size(1111, 717);
            this._prenotazioniListView.TabIndex = 4;
            this._prenotazioniListView.UseCompatibleStateImageBehavior = false;
            this._prenotazioniListView.View = System.Windows.Forms.View.Details;
            this._prenotazioniListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this._prenotazioniListView_ColumnClick);
            this._prenotazioniListView.Click += new System.EventHandler(this._prenotazioniListView_Click);
            this._prenotazioniListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this._prenotazioniListView_MouseClick);
            // 
            // _id
            // 
            this._id.Text = "ID";
            this._id.Width = 0;
            // 
            // _animale
            // 
            this._animale.Text = "Animale";
            this._animale.Width = 55;
            // 
            // _nome
            // 
            this._nome.Text = "Nome";
            this._nome.Width = 120;
            // 
            // _cognome
            // 
            this._cognome.Text = "Cognome";
            this._cognome.Width = 120;
            // 
            // _telefono
            // 
            this._telefono.Text = "Telefono";
            this._telefono.Width = 120;
            // 
            // _entrata
            // 
            this._entrata.Text = "Entrata";
            this._entrata.Width = 110;
            // 
            // _uscita
            // 
            this._uscita.Text = "Uscita";
            this._uscita.Width = 110;
            // 
            // _numBox
            // 
            this._numBox.Text = "NumBox";
            this._numBox.Width = 59;
            // 
            // _listaBox
            // 
            this._listaBox.Text = "ListaBox";
            this._listaBox.Width = 192;
            // 
            // _toDoText
            // 
            this._toDoText.Location = new System.Drawing.Point(1129, 41);
            this._toDoText.Multiline = true;
            this._toDoText.Name = "_toDoText";
            this._toDoText.Size = new System.Drawing.Size(394, 717);
            this._toDoText.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1393, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "IMPOSTAZIONI";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this._impostazioni_Click);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Filtra prenotazioni:";
            // 
            // _searchTextBox
            // 
            this._searchTextBox.Location = new System.Drawing.Point(144, 12);
            this._searchTextBox.Name = "_searchTextBox";
            this._searchTextBox.Size = new System.Drawing.Size(250, 22);
            this._searchTextBox.TabIndex = 1;
            this._searchTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // _rubricaButton
            // 
            this._rubricaButton.Location = new System.Drawing.Point(1303, 12);
            this._rubricaButton.Name = "_rubricaButton";
            this._rubricaButton.Size = new System.Drawing.Size(84, 23);
            this._rubricaButton.TabIndex = 4;
            this._rubricaButton.Text = "RUBRICA";
            this._rubricaButton.UseVisualStyleBackColor = true;
            this._rubricaButton.Click += new System.EventHandler(this._rubricaButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1535, 799);
            this.Controls.Add(this._rubricaButton);
            this.Controls.Add(this._searchTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this._toDoText);
            this.Controls.Add(this._prenotazioniListView);
            this.Controls.Add(this._cercaButton);
            this.Controls.Add(this._inserisciButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Pensione_Cani&Gatti";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button _inserisciButton;
        private System.Windows.Forms.Button _cercaButton;
        public System.Windows.Forms.ListView _prenotazioniListView;
        private System.Windows.Forms.ColumnHeader _id;
        private System.Windows.Forms.ColumnHeader _nome;
        private System.Windows.Forms.ColumnHeader _cognome;
        private System.Windows.Forms.ColumnHeader _telefono;
        private System.Windows.Forms.ColumnHeader _entrata;
        private System.Windows.Forms.ColumnHeader _uscita;
        private System.Windows.Forms.ColumnHeader _listaBox;
        private System.Windows.Forms.TextBox _toDoText;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem modificaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancellaToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader _animale;
        private System.Windows.Forms.ColumnHeader _numBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _searchTextBox;
        private System.Windows.Forms.Button _rubricaButton;
    }
}

