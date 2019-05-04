namespace WindowsFormsApplication3
{
    partial class Form1
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
            this._inserisciButton = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this._cercaButton = new System.Windows.Forms.Button();
            this._id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._nome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._cognome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._periodo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._box = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // _inserisciButton
            // 
            this._inserisciButton.Location = new System.Drawing.Point(1002, 480);
            this._inserisciButton.Name = "_inserisciButton";
            this._inserisciButton.Size = new System.Drawing.Size(109, 23);
            this._inserisciButton.TabIndex = 0;
            this._inserisciButton.Text = "INSERISCI";
            this._inserisciButton.UseVisualStyleBackColor = true;
            this._inserisciButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // listView1
            // 
            this.listView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._id,
            this._nome,
            this._cognome,
            this._periodo,
            this._box});
            this.listView1.HotTracking = true;
            this.listView1.HoverSelection = true;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1099, 462);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // _cercaButton
            // 
            this._cercaButton.Location = new System.Drawing.Point(921, 480);
            this._cercaButton.Name = "_cercaButton";
            this._cercaButton.Size = new System.Drawing.Size(75, 23);
            this._cercaButton.TabIndex = 2;
            this._cercaButton.Text = "CERCA";
            this._cercaButton.UseVisualStyleBackColor = true;
            // 
            // _id
            // 
            this._id.Text = "ID";
            this._id.Width = 47;
            // 
            // _nome
            // 
            this._nome.DisplayIndex = 2;
            this._nome.Text = "Nome";
            this._nome.Width = 141;
            // 
            // _cognome
            // 
            this._cognome.DisplayIndex = 1;
            this._cognome.Text = "Cognome";
            this._cognome.Width = 134;
            // 
            // _periodo
            // 
            this._periodo.Text = "Periodo";
            this._periodo.Width = 296;
            // 
            // _box
            // 
            this._box.Text = "Box";
            this._box.Width = 476;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 515);
            this.Controls.Add(this._cercaButton);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this._inserisciButton);
            this.Name = "Form1";
            this.Text = "Pizzi_Cani&Gatti";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _inserisciButton;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button _cercaButton;
        private System.Windows.Forms.ColumnHeader _id;
        private System.Windows.Forms.ColumnHeader _nome;
        private System.Windows.Forms.ColumnHeader _cognome;
        private System.Windows.Forms.ColumnHeader _periodo;
        private System.Windows.Forms.ColumnHeader _box;
    }
}

