using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace BrokeReality
{
    public partial class FormMain : Form
    {
        #region Constants
        private Color LIGHTESTCOLOR = Color.FromArgb(255, 236, 236, 236);
        private Color GRIDCOLOR = Color.FromArgb(255, 204, 204, 204);
        #endregion

        #region Members
        private string imageFilePath = "";
        private string imageFileName = "";
        private Bitmap imageBMP = null;
        #endregion

        public FormMain()
        {
            InitializeComponent();

#if DEBUG
            openFileDialogImage.InitialDirectory = Application.StartupPath.Replace("\\bin\\Debug", "") + "\\Images";
#else
            openFileDialogImage.InitialDirectory = Application.StartupPath;
#endif
            
            if (!Directory.Exists(Application.StartupPath + "\\Temp"))
                Directory.CreateDirectory(Application.StartupPath + "\\Temp");

            if (!Directory.Exists(Application.StartupPath + "\\IamgeLetters"))
                Directory.CreateDirectory(Application.StartupPath + "\\ImageLetters");
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialogImage.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    textBoxImage.Text = openFileDialogImage.FileName;
                    imageFilePath = openFileDialogImage.FileName;
                    imageFileName = openFileDialogImage.SafeFileName;
                    imageBMP = new Bitmap(imageFilePath, true);
                    pictureBoxCaptcha.Image = imageBMP;
                    buttonSplit.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void buttonProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (imageBMP == null)
                    return;

                #region Stage 1 : Remove grid
                if (File.Exists(Application.StartupPath + "\\Temp\\stage1.bmp"))
                    File.Delete(Application.StartupPath + "\\Temp\\stage1.bmp");

                if (File.Exists(Application.StartupPath + "\\Temp\\original.bmp"))
                    File.Delete(Application.StartupPath + "\\Temp\\original.bmp");

                imageBMP.Save(Application.StartupPath + "\\Temp\\original.bmp", System.Drawing.Imaging.ImageFormat.Bmp);

                for (int i = 0; i < imageBMP.Width; i++)
                    for (int j = 0; j < imageBMP.Height; j++)
                    {
                        if (imageBMP.GetPixel(i, j) == GRIDCOLOR) //remove grid
                            imageBMP.SetPixel(i, j, Color.FromArgb(255, 255, 255, 255));
                    }

                imageBMP.Save(Application.StartupPath + "\\Temp\\stage1.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                pictureBoxCaptcha.Image = imageBMP;
                #endregion

                #region Stage 2 : Make white background
                if (File.Exists(Application.StartupPath + "\\Temp\\stage2.bmp"))
                    File.Delete(Application.StartupPath + "\\Temp\\stage2.bmp");

                //change the lightest grey nuances to white
                for (int i = 0; i < imageBMP.Width; i++)
                    for (int j = 0; j < imageBMP.Height; j++)
                    {
                        if (imageBMP.GetPixel(i, j).B > Color.FromArgb(255, 108, 108, 108).B) //108, 108, 108
                            imageBMP.SetPixel(i, j, Color.FromArgb(255, 255, 255, 255));
                    }

                imageBMP.Save(Application.StartupPath + "\\Temp\\stage2.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                pictureBoxCaptcha.Image = imageBMP;
                #endregion

                #region Stage 3 : Make letters black
                if (File.Exists(Application.StartupPath + "\\Temp\\stage3.bmp"))
                    File.Delete(Application.StartupPath + "\\Temp\\stage3.bmp");

                Color b = imageBMP.GetPixel(0, 0);
                for (int i = 0; i < imageBMP.Width; i++)
                    for (int j = 0; j < imageBMP.Height; j++)
                    {
                        if (imageBMP.GetPixel(i, j) != Color.FromArgb(255,255,255,255)) 
                            imageBMP.SetPixel(i, j, Color.FromArgb(255,0,0,0)); //black
                    }

                imageBMP.Save(Application.StartupPath + "\\Temp\\stage3.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                pictureBoxCaptcha.Image = imageBMP;
                #endregion

                MessageBox.Show("Succesfully finished", "Message", MessageBoxButtons.OK);
                buttonSplit.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void buttonSplit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(Application.StartupPath + "\\Temp\\stage3.bmp"))
                {
                    MessageBox.Show("The image must be processed first", "Error");
                    buttonSplit.Enabled = false;
                    return;
                }

                imageBMP = new Bitmap(Application.StartupPath + "\\Temp\\stage3.bmp");
                int lenLetters = imageBMP.Width / 3;
                Bitmap letter1 = new Bitmap(lenLetters, imageBMP.Height);
                Bitmap letter2 = new Bitmap(lenLetters, imageBMP.Height);
                Bitmap letter3 = new Bitmap(lenLetters + imageBMP.Width % 3, imageBMP.Height);

                #region Split image in 3 letters
                for (int i = 0; i < letter1.Width; i++)
                    for (int j = 0; j < imageBMP.Height; j++)
                        letter1.SetPixel(i, j, imageBMP.GetPixel(i, j));

                for (int i = 0; i < letter2.Width; i++)
                    for (int j = 0; j < imageBMP.Height; j++)
                        letter2.SetPixel(i, j, imageBMP.GetPixel(i + lenLetters, j));

                for (int i = 0; i < letter3.Width; i++)
                    for (int j = 0; j < imageBMP.Height; j++)
                        letter3.SetPixel(i, j, imageBMP.GetPixel(i + 2 * lenLetters, j));
                #endregion

                #region Crop useless white regions
                Point leftTop = getLeftMostBlackPoint(letter1);
                Point rightBottom = getRightMostBlackPoint(letter1);
                Bitmap letter1_trimed = new Bitmap(rightBottom.X - leftTop.X, rightBottom.Y - leftTop.Y);

                for (int i = 0; i < letter1_trimed.Width; i++)
                    for (int j = 0; j < letter1_trimed.Height; j++)
                        letter1_trimed.SetPixel(i, j, letter1.GetPixel(i + leftTop.X, j + leftTop.Y));

                leftTop = getLeftMostBlackPoint(letter2);
                rightBottom = getRightMostBlackPoint(letter2);
                Bitmap letter2_trimed = new Bitmap(rightBottom.X - leftTop.X, rightBottom.Y - leftTop.Y);

                for (int i = 0; i < letter2_trimed.Width; i++)
                    for (int j = 0; j < letter2_trimed.Height; j++)
                        letter2_trimed.SetPixel(i, j, letter2.GetPixel(i + leftTop.X, j + leftTop.Y));

                leftTop = getLeftMostBlackPoint(letter3);
                rightBottom = getRightMostBlackPoint(letter3);
                Bitmap letter3_trimed = new Bitmap(rightBottom.X - leftTop.X, rightBottom.Y - leftTop.Y);

                for (int i = 0; i < letter3_trimed.Width; i++)
                    for (int j = 0; j < letter3_trimed.Height; j++)
                        letter3_trimed.SetPixel(i, j, letter3.GetPixel(i + leftTop.X, j + leftTop.Y));
                #endregion

                #region Save the letters to images
                if (File.Exists(Application.StartupPath + "\\ImageLetters\\letter1.bmp"))
                    File.Delete(Application.StartupPath + "\\ImageLetters\\letter1.bmp");

                if (File.Exists(Application.StartupPath + "\\ImageLetters\\letter2.bmp"))
                    File.Delete(Application.StartupPath + "\\ImageLetters\\letter2.bmp");

                if (File.Exists(Application.StartupPath + "\\ImageLetters\\letter3.bmp"))
                    File.Delete(Application.StartupPath + "\\ImageLetters\\letter3.bmp");

                letter1_trimed.Save(Application.StartupPath + "\\ImageLetters\\letter1.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                letter2_trimed.Save(Application.StartupPath + "\\ImageLetters\\letter2.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                letter3_trimed.Save(Application.StartupPath + "\\ImageLetters\\letter3.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                #endregion

                imageBMP.Dispose();
                MessageBox.Show("Succesfully finished", "Message", MessageBoxButtons.OK);

                #region Open folder location
                string argument = "/select, " + Application.StartupPath + "\\ImageLetters\\letter1.bmp";
                System.Diagnostics.Process.Start("explorer.exe", argument);
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private Point getLeftMostBlackPoint(Bitmap image)
        {
            int leftX = 0, leftY = 0;
            bool finished = false;

            //from top -> bottom
            for (int x = 0; x < image.Width; x++)
            {
                if (finished)
                    break;

                for (int y = 0; y < image.Height; y++)
                    if (image.GetPixel(x, y) == Color.FromArgb(255, 0, 0, 0))
                    {
                        leftX = x;
                        finished = true;
                        break;
                    }
            }

            //from left -> right
            finished = false;
            for (int y = 0; y < image.Height; y++)
            {
                if (finished)
                    break;

                for (int x = 0; x < image.Width; x++)
                    if (image.GetPixel(x, y) == Color.FromArgb(255, 0, 0, 0))
                    {
                        leftY = y;
                        finished = true;
                        break;
                    }
            }

         /*   if (leftX > 0)
                leftX--;
            if (leftY > 0)
                leftY--;
            */
            return new Point(leftX, leftY);
        }

        private Point getRightMostBlackPoint(Bitmap image)
        {
            int rightX = image.Width, rightY = image.Height;
            bool finished = false;

            //from bottom -> top
            finished = false;
            for (int x = image.Width - 1; x >= 0; x--)
            {
                if (finished)
                    break;

                for (int y = image.Height - 1; y >= 0; y--)
                    if (image.GetPixel(x, y) == Color.FromArgb(255, 0, 0, 0))
                    {
                        rightX = x;
                        finished = true;
                        break;
                    }
            }

            //from right -> left
            finished = false;
            for (int y = image.Height - 1; y >= 0; y--)
            {
                if (finished)
                    break;

                for (int x = image.Width - 1; x >= 0; x--)
                    if (image.GetPixel(x, y) == Color.FromArgb(255, 0, 0, 0))
                    {
                        rightY = y;
                        finished = true;
                        break;
                    }
            }

            if (rightX < image.Width - 1)
                rightX++;
            if (rightY < image.Height - 1)
                rightY++;
            
            return new Point(rightX, rightY);
        }
    }
}
