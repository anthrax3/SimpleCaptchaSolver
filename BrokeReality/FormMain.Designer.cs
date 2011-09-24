namespace BrokeReality
{
    partial class FormMain
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
            this.pictureBoxCaptcha = new System.Windows.Forms.PictureBox();
            this.labelFile = new System.Windows.Forms.Label();
            this.openFileDialogImage = new System.Windows.Forms.OpenFileDialog();
            this.textBoxImage = new System.Windows.Forms.TextBox();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.buttonProcess = new System.Windows.Forms.Button();
            this.buttonSplit = new System.Windows.Forms.Button();
            this.btnGetCaptchas = new System.Windows.Forms.Button();
            this.checkBoxShow = new System.Windows.Forms.CheckBox();
            this.groupBoxSplit = new System.Windows.Forms.GroupBox();
            this.labelLetter3 = new System.Windows.Forms.Label();
            this.labelLetter2 = new System.Windows.Forms.Label();
            this.labelLetter1 = new System.Windows.Forms.Label();
            this.checkBoxLetterSet = new System.Windows.Forms.CheckBox();
            this.groupBoxCaptcha = new System.Windows.Forms.GroupBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCaptcha)).BeginInit();
            this.groupBoxSplit.SuspendLayout();
            this.groupBoxCaptcha.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxCaptcha
            // 
            this.pictureBoxCaptcha.Location = new System.Drawing.Point(426, 186);
            this.pictureBoxCaptcha.Name = "pictureBoxCaptcha";
            this.pictureBoxCaptcha.Size = new System.Drawing.Size(129, 63);
            this.pictureBoxCaptcha.TabIndex = 0;
            this.pictureBoxCaptcha.TabStop = false;
            // 
            // labelFile
            // 
            this.labelFile.AutoSize = true;
            this.labelFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFile.Location = new System.Drawing.Point(13, 13);
            this.labelFile.Name = "labelFile";
            this.labelFile.Size = new System.Drawing.Size(109, 17);
            this.labelFile.TabIndex = 1;
            this.labelFile.Text = "Select an image";
            // 
            // openFileDialogImage
            // 
            this.openFileDialogImage.Filter = "Image file *bmp|*bmp";
            // 
            // textBoxImage
            // 
            this.textBoxImage.Location = new System.Drawing.Point(13, 34);
            this.textBoxImage.Name = "textBoxImage";
            this.textBoxImage.Size = new System.Drawing.Size(212, 20);
            this.textBoxImage.TabIndex = 2;
            // 
            // buttonSelect
            // 
            this.buttonSelect.Location = new System.Drawing.Point(232, 32);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(79, 23);
            this.buttonSelect.TabIndex = 3;
            this.buttonSelect.Text = "Select";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // buttonProcess
            // 
            this.buttonProcess.Location = new System.Drawing.Point(13, 60);
            this.buttonProcess.Name = "buttonProcess";
            this.buttonProcess.Size = new System.Drawing.Size(75, 23);
            this.buttonProcess.TabIndex = 4;
            this.buttonProcess.Text = "Process";
            this.buttonProcess.UseVisualStyleBackColor = true;
            this.buttonProcess.Click += new System.EventHandler(this.buttonProcess_Click);
            // 
            // buttonSplit
            // 
            this.buttonSplit.Enabled = false;
            this.buttonSplit.Location = new System.Drawing.Point(7, 111);
            this.buttonSplit.Name = "buttonSplit";
            this.buttonSplit.Size = new System.Drawing.Size(75, 23);
            this.buttonSplit.TabIndex = 5;
            this.buttonSplit.Text = "Split";
            this.buttonSplit.UseVisualStyleBackColor = true;
            this.buttonSplit.Click += new System.EventHandler(this.buttonSplit_Click);
            // 
            // btnGetCaptchas
            // 
            this.btnGetCaptchas.Location = new System.Drawing.Point(17, 64);
            this.btnGetCaptchas.Name = "btnGetCaptchas";
            this.btnGetCaptchas.Size = new System.Drawing.Size(95, 23);
            this.btnGetCaptchas.TabIndex = 6;
            this.btnGetCaptchas.Text = "Get Captchas";
            this.btnGetCaptchas.UseVisualStyleBackColor = true;
            this.btnGetCaptchas.Click += new System.EventHandler(this.btnGetCaptchas_Click);
            // 
            // checkBoxShow
            // 
            this.checkBoxShow.AutoSize = true;
            this.checkBoxShow.Location = new System.Drawing.Point(6, 19);
            this.checkBoxShow.Name = "checkBoxShow";
            this.checkBoxShow.Size = new System.Drawing.Size(129, 17);
            this.checkBoxShow.TabIndex = 7;
            this.checkBoxShow.Text = "Show letters after split";
            this.checkBoxShow.UseVisualStyleBackColor = true;
            this.checkBoxShow.CheckedChanged += new System.EventHandler(this.checkBoxShow_CheckedChanged);
            // 
            // groupBoxSplit
            // 
            this.groupBoxSplit.Controls.Add(this.labelLetter3);
            this.groupBoxSplit.Controls.Add(this.labelLetter2);
            this.groupBoxSplit.Controls.Add(this.labelLetter1);
            this.groupBoxSplit.Controls.Add(this.checkBoxLetterSet);
            this.groupBoxSplit.Controls.Add(this.checkBoxShow);
            this.groupBoxSplit.Controls.Add(this.buttonSplit);
            this.groupBoxSplit.Location = new System.Drawing.Point(13, 109);
            this.groupBoxSplit.Name = "groupBoxSplit";
            this.groupBoxSplit.Size = new System.Drawing.Size(200, 140);
            this.groupBoxSplit.TabIndex = 8;
            this.groupBoxSplit.TabStop = false;
            this.groupBoxSplit.Text = "Split";
            // 
            // labelLetter3
            // 
            this.labelLetter3.AutoSize = true;
            this.labelLetter3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelLetter3.Location = new System.Drawing.Point(108, 63);
            this.labelLetter3.Name = "labelLetter3";
            this.labelLetter3.Size = new System.Drawing.Size(36, 13);
            this.labelLetter3.TabIndex = 10;
            this.labelLetter3.Text = "letter3";
            this.labelLetter3.Click += new System.EventHandler(this.labelLetter3_Click);
            // 
            // labelLetter2
            // 
            this.labelLetter2.AutoSize = true;
            this.labelLetter2.Location = new System.Drawing.Point(66, 63);
            this.labelLetter2.Name = "labelLetter2";
            this.labelLetter2.Size = new System.Drawing.Size(36, 13);
            this.labelLetter2.TabIndex = 10;
            this.labelLetter2.Text = "letter2";
            this.labelLetter2.Click += new System.EventHandler(this.labelLetter2_Click);
            // 
            // labelLetter1
            // 
            this.labelLetter1.AutoSize = true;
            this.labelLetter1.Location = new System.Drawing.Point(24, 63);
            this.labelLetter1.Name = "labelLetter1";
            this.labelLetter1.Size = new System.Drawing.Size(36, 13);
            this.labelLetter1.TabIndex = 9;
            this.labelLetter1.Text = "letter1";
            this.labelLetter1.Click += new System.EventHandler(this.labelLetter1_Click);
            // 
            // checkBoxLetterSet
            // 
            this.checkBoxLetterSet.AutoSize = true;
            this.checkBoxLetterSet.Location = new System.Drawing.Point(7, 43);
            this.checkBoxLetterSet.Name = "checkBoxLetterSet";
            this.checkBoxLetterSet.Size = new System.Drawing.Size(167, 17);
            this.checkBoxLetterSet.TabIndex = 8;
            this.checkBoxLetterSet.Text = "Save as letter for comparation";
            this.checkBoxLetterSet.UseVisualStyleBackColor = true;
            this.checkBoxLetterSet.CheckedChanged += new System.EventHandler(this.checkBoxLetterSet_CheckedChanged);
            // 
            // groupBoxCaptcha
            // 
            this.groupBoxCaptcha.Controls.Add(this.buttonDelete);
            this.groupBoxCaptcha.Controls.Add(this.btnGetCaptchas);
            this.groupBoxCaptcha.Location = new System.Drawing.Point(426, 13);
            this.groupBoxCaptcha.Name = "groupBoxCaptcha";
            this.groupBoxCaptcha.Size = new System.Drawing.Size(129, 93);
            this.groupBoxCaptcha.TabIndex = 9;
            this.groupBoxCaptcha.TabStop = false;
            this.groupBoxCaptcha.Text = "Captcha";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(17, 35);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(95, 23);
            this.buttonDelete.TabIndex = 7;
            this.buttonDelete.Text = "Delete All";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 261);
            this.Controls.Add(this.groupBoxCaptcha);
            this.Controls.Add(this.groupBoxSplit);
            this.Controls.Add(this.buttonProcess);
            this.Controls.Add(this.buttonSelect);
            this.Controls.Add(this.textBoxImage);
            this.Controls.Add(this.labelFile);
            this.Controls.Add(this.pictureBoxCaptcha);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BrokenReality";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCaptcha)).EndInit();
            this.groupBoxSplit.ResumeLayout(false);
            this.groupBoxSplit.PerformLayout();
            this.groupBoxCaptcha.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxCaptcha;
        private System.Windows.Forms.Label labelFile;
        private System.Windows.Forms.OpenFileDialog openFileDialogImage;
        private System.Windows.Forms.TextBox textBoxImage;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.Button buttonProcess;
        private System.Windows.Forms.Button buttonSplit;
        private System.Windows.Forms.Button btnGetCaptchas;
        private System.Windows.Forms.CheckBox checkBoxShow;
        private System.Windows.Forms.GroupBox groupBoxSplit;
        private System.Windows.Forms.CheckBox checkBoxLetterSet;
        private System.Windows.Forms.Label labelLetter1;
        private System.Windows.Forms.Label labelLetter2;
        private System.Windows.Forms.Label labelLetter3;
        private System.Windows.Forms.GroupBox groupBoxCaptcha;
        private System.Windows.Forms.Button buttonDelete;
    }
}

