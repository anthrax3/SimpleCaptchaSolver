namespace BrokeReality
{
    partial class FormGetCaptchas
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
            this.labelAddress = new System.Windows.Forms.Label();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.textBoxNrImages = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.progressBarCaptchas = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelAddress.Location = new System.Drawing.Point(13, 13);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(102, 17);
            this.labelAddress.TabIndex = 0;
            this.labelAddress.Text = "Image Address";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(122, 13);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(303, 20);
            this.textBoxAddress.TabIndex = 1;
            // 
            // textBoxNrImages
            // 
            this.textBoxNrImages.Location = new System.Drawing.Point(141, 46);
            this.textBoxNrImages.Name = "textBoxNrImages";
            this.textBoxNrImages.Size = new System.Drawing.Size(49, 20);
            this.textBoxNrImages.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Number of images";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(349, 94);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // progressBarCaptchas
            // 
            this.progressBarCaptchas.Location = new System.Drawing.Point(12, 94);
            this.progressBarCaptchas.Name = "progressBarCaptchas";
            this.progressBarCaptchas.Size = new System.Drawing.Size(211, 23);
            this.progressBarCaptchas.TabIndex = 5;
            // 
            // FormGetCaptchas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 136);
            this.Controls.Add(this.progressBarCaptchas);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.textBoxNrImages);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.labelAddress);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGetCaptchas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Captcha Getter";
            this.Load += new System.EventHandler(this.FormGetCaptchas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.TextBox textBoxNrImages;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ProgressBar progressBarCaptchas;
    }
}

