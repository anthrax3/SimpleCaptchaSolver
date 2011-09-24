namespace BrokeReality
{
    partial class FormSetLetter
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.pictureBoxLetter = new System.Windows.Forms.PictureBox();
            this.textBoxLetter = new System.Windows.Forms.TextBox();
            this.labelNotice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLetter)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(81, 64);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // pictureBoxLetter
            // 
            this.pictureBoxLetter.Location = new System.Drawing.Point(12, 8);
            this.pictureBoxLetter.Name = "pictureBoxLetter";
            this.pictureBoxLetter.Size = new System.Drawing.Size(100, 50);
            this.pictureBoxLetter.TabIndex = 1;
            this.pictureBoxLetter.TabStop = false;
            // 
            // textBoxLetter
            // 
            this.textBoxLetter.Location = new System.Drawing.Point(149, 10);
            this.textBoxLetter.Name = "textBoxLetter";
            this.textBoxLetter.Size = new System.Drawing.Size(42, 20);
            this.textBoxLetter.TabIndex = 1;
            this.textBoxLetter.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxLetter_KeyUp);
            // 
            // labelNotice
            // 
            this.labelNotice.AutoSize = true;
            this.labelNotice.Location = new System.Drawing.Point(119, 32);
            this.labelNotice.Name = "labelNotice";
            this.labelNotice.Size = new System.Drawing.Size(0, 13);
            this.labelNotice.TabIndex = 3;
            // 
            // FormSetLetter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 99);
            this.Controls.Add(this.labelNotice);
            this.Controls.Add(this.textBoxLetter);
            this.Controls.Add(this.pictureBoxLetter);
            this.Controls.Add(this.buttonOK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSetLetter";
            this.Text = "FormSetLetter";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLetter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.PictureBox pictureBoxLetter;
        private System.Windows.Forms.TextBox textBoxLetter;
        private System.Windows.Forms.Label labelNotice;
    }
}