namespace Pizzi_CaniEGatti.Grafica
{
    partial class ImpsotazioniForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImpsotazioniForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._numCaniTextBox = new System.Windows.Forms.TextBox();
            this._numGattiTextBox = new System.Windows.Forms.TextBox();
            this._okButton = new System.Windows.Forms.Button();
            this._deleteTimePicker = new System.Windows.Forms.DateTimePicker();
            this._deleteButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Numero box cani:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Numero box gatti:";
            // 
            // _numCaniTextBox
            // 
            this._numCaniTextBox.Location = new System.Drawing.Point(215, 12);
            this._numCaniTextBox.Name = "_numCaniTextBox";
            this._numCaniTextBox.Size = new System.Drawing.Size(100, 22);
            this._numCaniTextBox.TabIndex = 1;
            // 
            // _numGattiTextBox
            // 
            this._numGattiTextBox.Location = new System.Drawing.Point(215, 41);
            this._numGattiTextBox.Name = "_numGattiTextBox";
            this._numGattiTextBox.Size = new System.Drawing.Size(100, 22);
            this._numGattiTextBox.TabIndex = 2;
            // 
            // _okButton
            // 
            this._okButton.Location = new System.Drawing.Point(240, 219);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 23);
            this._okButton.TabIndex = 5;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            this._okButton.Click += new System.EventHandler(this._okButton_Click);
            // 
            // _deleteTimePicker
            // 
            this._deleteTimePicker.Location = new System.Drawing.Point(12, 133);
            this._deleteTimePicker.Name = "_deleteTimePicker";
            this._deleteTimePicker.Size = new System.Drawing.Size(239, 22);
            this._deleteTimePicker.TabIndex = 3;
            // 
            // _deleteButton
            // 
            this._deleteButton.Location = new System.Drawing.Point(12, 161);
            this._deleteButton.Name = "_deleteButton";
            this._deleteButton.Size = new System.Drawing.Size(104, 23);
            this._deleteButton.TabIndex = 4;
            this._deleteButton.Text = "CANCELLA";
            this._deleteButton.UseVisualStyleBackColor = true;
            this._deleteButton.Click += new System.EventHandler(this._deleteButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(280, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Cancella tutte le prenotazioni fino alla data:";
            // 
            // ImpsotazioniForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 254);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._deleteButton);
            this.Controls.Add(this._deleteTimePicker);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._numGattiTextBox);
            this.Controls.Add(this._numCaniTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ImpsotazioniForm";
            this.Text = "Impsotazioni";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _numCaniTextBox;
        private System.Windows.Forms.TextBox _numGattiTextBox;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.DateTimePicker _deleteTimePicker;
        private System.Windows.Forms.Button _deleteButton;
        private System.Windows.Forms.Label label3;
    }
}