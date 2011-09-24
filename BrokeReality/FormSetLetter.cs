using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace BrokeReality
{
    public partial class FormSetLetter : Form
    {
        private Image image;
        private string[] fileNames;
        private Regex regexValidLetter = new Regex("[a-zA-Z]");

        public FormSetLetter()
        {
            InitializeComponent();
        }

        public FormSetLetter(Image image) : this()
        {
            this.image = image;
            this.pictureBoxLetter.Image = image;
            this.fileNames = Directory.GetFiles(CST.LETTER_SET_DIR, "*.bmp", SearchOption.AllDirectories);

            for(int i = 0; i < fileNames.Length; i++)
                fileNames[i] = fileNames[i].Replace(CST.LETTER_SET_DIR + "\\", null);
        }


        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(textBoxLetter.Text))
                    return;

                int version = fileNames.Where(file => file.Substring(0, 1) == textBoxLetter.Text).Count();
                image.Save(CST.LETTER_SET_DIR + "\\" + textBoxLetter.Text + (version + 1) + ".bmp");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void textBoxLetter_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (textBoxLetter.Text.Length == 1 && regexValidLetter.IsMatch(textBoxLetter.Text))
                    labelNotice.Text = fileNames.Where(file => file.Substring(0, 1) == textBoxLetter.Text).Count()
                        + " versions of this letter";
                else
                    labelNotice.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
