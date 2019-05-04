namespace Pizzi_CaniEGatti.Grafica
{
    partial class CercaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CercaForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._dataInizio = new System.Windows.Forms.DateTimePicker();
            this._oraInizio = new System.Windows.Forms.DateTimePicker();
            this._dataFine = new System.Windows.Forms.DateTimePicker();
            this._oraFine = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._resLabel = new System.Windows.Forms.Label();
            this._chiudiButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this._caniRadioButton = new System.Windows.Forms.RadioButton();
            this._gattiRadioButton = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data inizio:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ora inizio:";
            // 
            // _dataInizio
            // 
            this._dataInizio.Location = new System.Drawing.Point(184, 13);
            this._dataInizio.Name = "_dataInizio";
            this._dataInizio.Size = new System.Drawing.Size(263, 22);
            this._dataInizio.TabIndex = 1;
            // 
            // _oraInizio
            // 
            this._oraInizio.CustomFormat = "HH:mm";
            this._oraInizio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._oraInizio.Location = new System.Drawing.Point(184, 42);
            this._oraInizio.Name = "_oraInizio";
            this._oraInizio.ShowUpDown = true;
            this._oraInizio.Size = new System.Drawing.Size(112, 22);
            this._oraInizio.TabIndex = 2;
            this._oraInizio.ValueChanged += new System.EventHandler(this._oraInizio_ValueChanged);
            // 
            // _dataFine
            // 
            this._dataFine.Location = new System.Drawing.Point(184, 72);
            this._dataFine.Name = "_dataFine";
            this._dataFine.Size = new System.Drawing.Size(263, 22);
            this._dataFine.TabIndex = 3;
            // 
            // _oraFine
            // 
            this._oraFine.CustomFormat = "HH:mm";
            this._oraFine.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._oraFine.Location = new System.Drawing.Point(184, 100);
            this._oraFine.Name = "_oraFine";
            this._oraFine.ShowUpDown = true;
            this._oraFine.Size = new System.Drawing.Size(112, 22);
            this._oraFine.TabIndex = 4;
            this._oraFine.ValueChanged += new System.EventHandler(this._oraFine_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Data fine:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ora fine:";
            // 
            // _resLabel
            // 
            this._resLabel.AutoSize = true;
            this._resLabel.Location = new System.Drawing.Point(12, 185);
            this._resLabel.Name = "_resLabel";
            this._resLabel.Size = new System.Drawing.Size(101, 17);
            this._resLabel.TabIndex = 8;
            this._resLabel.Text = "Box disponibili:";
            this._resLabel.Click += new System.EventHandler(this._resLabel_Click);
            // 
            // _chiudiButton
            // 
            this._chiudiButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._chiudiButton.Location = new System.Drawing.Point(660, 435);
            this._chiudiButton.Name = "_chiudiButton";
            this._chiudiButton.Size = new System.Drawing.Size(75, 23);
            this._chiudiButton.TabIndex = 7;
            this._chiudiButton.Text = "CHIUDI";
            this._chiudiButton.UseVisualStyleBackColor = true;
            this._chiudiButton.Click += new System.EventHandler(this._chiudiButton_Click_1);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(579, 435);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "CERCA";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this._cercaButton_Click);
            // 
            // _caniRadioButton
            // 
            this._caniRadioButton.AutoSize = true;
            this._caniRadioButton.Location = new System.Drawing.Point(184, 132);
            this._caniRadioButton.Name = "_caniRadioButton";
            this._caniRadioButton.Size = new System.Drawing.Size(57, 21);
            this._caniRadioButton.TabIndex = 15;
            this._caniRadioButton.TabStop = true;
            this._caniRadioButton.Text = "Cani";
            this._caniRadioButton.UseVisualStyleBackColor = true;
            // 
            // _gattiRadioButton
            // 
            this._gattiRadioButton.AutoSize = true;
            this._gattiRadioButton.Location = new System.Drawing.Point(184, 159);
            this._gattiRadioButton.Name = "_gattiRadioButton";
            this._gattiRadioButton.Size = new System.Drawing.Size(59, 21);
            this._gattiRadioButton.TabIndex = 13;
            this._gattiRadioButton.TabStop = true;
            this._gattiRadioButton.Text = "Gatti";
            this._gattiRadioButton.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "Tipo:";
            // 
            // CercaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 470);
            this.Controls.Add(this.label6);
            this.Controls.Add(this._gattiRadioButton);
            this.Controls.Add(this._caniRadioButton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this._chiudiButton);
            this.Controls.Add(this._resLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._oraFine);
            this.Controls.Add(this._dataFine);
            this.Controls.Add(this._oraInizio);
            this.Controls.Add(this._dataInizio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CercaForm";
            this.Text = "Disponibilità";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _resLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker _oraFine;
        private System.Windows.Forms.DateTimePicker _dataFine;
        private System.Windows.Forms.DateTimePicker _oraInizio;
        private System.Windows.Forms.DateTimePicker _dataInizio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _chiudiButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton _caniRadioButton;
        private System.Windows.Forms.RadioButton _gattiRadioButton;
        private System.Windows.Forms.Label label6;
    }
}