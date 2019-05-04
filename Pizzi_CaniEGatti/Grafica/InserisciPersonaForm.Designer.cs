namespace Pensione_CaniEGatti.Grafica
{
    partial class InserisciPersonaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InserisciPersonaForm));
            this._cognomeTextBox = new System.Windows.Forms.TextBox();
            this._telefonoTextBox = new System.Windows.Forms.TextBox();
            this._nomeTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._cfTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._padroneDiTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this._annullaButton = new System.Windows.Forms.Button();
            this._okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _cognomeTextBox
            // 
            this._cognomeTextBox.Location = new System.Drawing.Point(163, 40);
            this._cognomeTextBox.Name = "_cognomeTextBox";
            this._cognomeTextBox.Size = new System.Drawing.Size(182, 22);
            this._cognomeTextBox.TabIndex = 11;
            // 
            // _telefonoTextBox
            // 
            this._telefonoTextBox.Location = new System.Drawing.Point(163, 68);
            this._telefonoTextBox.Name = "_telefonoTextBox";
            this._telefonoTextBox.Size = new System.Drawing.Size(182, 22);
            this._telefonoTextBox.TabIndex = 13;
            // 
            // _nomeTextBox
            // 
            this._nomeTextBox.Location = new System.Drawing.Point(163, 12);
            this._nomeTextBox.Name = "_nomeTextBox";
            this._nomeTextBox.Size = new System.Drawing.Size(182, 22);
            this._nomeTextBox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Telefono:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Cognome:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Nome:";
            // 
            // _cfTextBox
            // 
            this._cfTextBox.Location = new System.Drawing.Point(163, 96);
            this._cfTextBox.Name = "_cfTextBox";
            this._cfTextBox.Size = new System.Drawing.Size(182, 22);
            this._cfTextBox.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Codice Fiscale:";
            // 
            // _padroneDiTextBox
            // 
            this._padroneDiTextBox.Location = new System.Drawing.Point(163, 124);
            this._padroneDiTextBox.Multiline = true;
            this._padroneDiTextBox.Name = "_padroneDiTextBox";
            this._padroneDiTextBox.Size = new System.Drawing.Size(182, 94);
            this._padroneDiTextBox.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Padrone di:";
            // 
            // _annullaButton
            // 
            this._annullaButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._annullaButton.Location = new System.Drawing.Point(317, 329);
            this._annullaButton.Name = "_annullaButton";
            this._annullaButton.Size = new System.Drawing.Size(101, 23);
            this._annullaButton.TabIndex = 19;
            this._annullaButton.Text = "ANNULLA";
            this._annullaButton.UseVisualStyleBackColor = true;
            this._annullaButton.Click += new System.EventHandler(this._annullaButton_Click);
            // 
            // _okButton
            // 
            this._okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._okButton.Location = new System.Drawing.Point(236, 329);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 23);
            this._okButton.TabIndex = 18;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            this._okButton.Click += new System.EventHandler(this._okButton_Click);
            // 
            // InserisciPersonaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 364);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._annullaButton);
            this.Controls.Add(this._padroneDiTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._cfTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._cognomeTextBox);
            this.Controls.Add(this._telefonoTextBox);
            this.Controls.Add(this._nomeTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InserisciPersonaForm";
            this.Text = "Inserisci Nuovo Cliente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _cognomeTextBox;
        private System.Windows.Forms.TextBox _telefonoTextBox;
        private System.Windows.Forms.TextBox _nomeTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _cfTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _padroneDiTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button _annullaButton;
        private System.Windows.Forms.Button _okButton;
    }
}