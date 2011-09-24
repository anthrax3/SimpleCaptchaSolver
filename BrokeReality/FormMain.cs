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
        #region Members
        private string imageFilePath = "";
        private string imageFileName = "";
        private Bitmap imageBMP = null;

        private bool showLetterFolder = false;
        private bool saveInLetterSet = false;

        private bool[] savingLetters = new bool[]{false, false, false};
        #endregion

        public FormMain()
        {
            InitializeComponent();

            try
            {
                if (!Directory.Exists(CST.TEMP_DIR))
                    Directory.CreateDirectory(CST.TEMP_DIR);

                if (!Directory.Exists(CST.IMAGE_LETTERS_DIR))
                    Directory.CreateDirectory(CST.IMAGE_LETTERS_DIR);

                if (!Directory.Exists(CST.LETTER_SET_DIR))
                    Directory.CreateDirectory(CST.LETTER_SET_DIR);

                if (!Directory.Exists(CST.CAPTCHAS_DIR))
                    Directory.CreateDirectory(CST.CAPTCHAS_DIR);

                openFileDialogImage.InitialDirectory = CST.CAPTCHAS_DIR;

                labelLetter1.Visible = false;
                labelLetter2.Visible = false;
                labelLetter3.Visible = false;
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error");
            }
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
                #region Input Validation
                if (imageBMP == null)
                    return;
                #endregion

                #region Stage 0 : Keep all the pixels with GRIDCOLOR which are near the black pixels
                //TODO: make a better algorithm
                byte[,] colorMatrix = new byte[imageBMP.Width, imageBMP.Height];

                //save the original image
                if (File.Exists(CST.TEMP_DIR + "\\original.bmp"))
                    File.Delete(CST.TEMP_DIR + "\\original.bmp");
                imageBMP.Save(CST.TEMP_DIR + "\\original.bmp", System.Drawing.Imaging.ImageFormat.Bmp);

                if (File.Exists(CST.TEMP_DIR + "\\stage0.bmp"))
                    File.Delete(CST.TEMP_DIR + "\\stage0.bmp");

                /* for (int i = 0; i < imageBMP.Width; i++)
                    for (int j = 0; j < imageBMP.Height; j++)
                        colorMatrix[i, j] = imageBMP.GetPixel(i, j).B;

                for (int i = 0; i < imageBMP.Width; i++)
                    for (int j = 0; j < imageBMP.Height; j++)
                        if (colorMatrix[i,j] < LIGHTESTBLACKCOLOR.B)
                        {
                            List<Point>  neighbours = getValidNeighbours(i, j);
                            neighbours.ForEach(p => imageBMP.SetPixel(p.X, p.Y, BLACK));
                        }

                imageBMP.Save(Application.StartupPath + "\\Temp\\stage0.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                pictureBoxCaptcha.Image = imageBMP; */
                #endregion

                #region Stage 1 : Remove grid
                if (File.Exists(CST.TEMP_DIR + "\\stage1.bmp"))
                    File.Delete(CST.TEMP_DIR + "\\stage1.bmp");

                for (int i = 0; i < imageBMP.Width; i++)
                    for (int j = 0; j < imageBMP.Height; j++)
                        if (imageBMP.GetPixel(i, j) == CST.GRIDCOLOR)
                            imageBMP.SetPixel(i, j, CST.WHITE);

                imageBMP.Save(CST.TEMP_DIR + "\\stage1.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                pictureBoxCaptcha.Image = imageBMP;
                #endregion

                #region Stage 2 : Make white background
                if (File.Exists(CST.TEMP_DIR + "\\stage2.bmp"))
                    File.Delete(CST.TEMP_DIR + "\\stage2.bmp");

                //change the light grey nuances to white
                for (int i = 0; i < imageBMP.Width; i++)
                    for (int j = 0; j < imageBMP.Height; j++)
                        if (imageBMP.GetPixel(i, j).B > Color.FromArgb(255, 108, 108, 108).B) //108, 108, 108
                            imageBMP.SetPixel(i, j, CST.WHITE);


                imageBMP.Save(CST.TEMP_DIR + "\\stage2.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                pictureBoxCaptcha.Image = imageBMP;
                #endregion

                #region Stage 3 : Make letters black
                if (File.Exists(CST.TEMP_DIR + "\\stage3.bmp"))
                    File.Delete(CST.TEMP_DIR + "\\stage3.bmp");

                for (int i = 0; i < imageBMP.Width; i++)
                    for (int j = 0; j < imageBMP.Height; j++)
                        if (imageBMP.GetPixel(i, j) != CST.WHITE)
                            imageBMP.SetPixel(i, j, CST.BLACK);

                imageBMP.Save(CST.TEMP_DIR + "\\stage3.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                pictureBoxCaptcha.Image = imageBMP;
                #endregion

                MessageBox.Show("Succesfully finished", "Message", MessageBoxButtons.OK);
                buttonSplit.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                buttonSplit.Enabled = false;
            }
        }

        private void buttonSplit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(CST.TEMP_DIR + "\\stage3.bmp"))
                {
                    MessageBox.Show("The image must be processed first", "Error");
                    buttonSplit.Enabled = false;
                    return;
                }

                imageBMP = new Bitmap(CST.TEMP_DIR + "\\stage3.bmp");
                int lenLetters = imageBMP.Width / CST.NR_LETTERS;
                Bitmap[] letters = new Bitmap[CST.NR_LETTERS];

                for (int i = 0; i < CST.NR_LETTERS - 1; i++)
                {
                    letters[i] = new Bitmap(lenLetters, imageBMP.Height);
                }

                letters[CST.NR_LETTERS - 1] = new Bitmap(lenLetters + imageBMP.Width % CST.NR_LETTERS, imageBMP.Height);

                #region Split image in letters
                for (int k = 0; k < CST.NR_LETTERS; k++)
                    for (int i = 0; i < letters[k].Width; i++)
                        for (int j = 0; j < imageBMP.Height; j++)
                            letters[k].SetPixel(i, j, imageBMP.GetPixel(i + k * lenLetters, j));
                #endregion

                #region Crop useless white regions
                Bitmap[] letters_trimed = new Bitmap[CST.NR_LETTERS];

                for (int k = 0; k < CST.NR_LETTERS; k++)
                {
                    Point leftTop = getLeftMostBlackPoint(letters[k]);
                    Point rightBottom = getRightMostBlackPoint(letters[k]);
                    letters_trimed[k] = new Bitmap(rightBottom.X - leftTop.X, rightBottom.Y - leftTop.Y);

                    for (int i = 0; i < letters_trimed[k].Width; i++)
                        for (int j = 0; j < letters_trimed[k].Height; j++)
                            letters_trimed[k].SetPixel(i, j, letters[k].GetPixel(i + leftTop.X, j + leftTop.Y));
                }
                #endregion

                #region Save the letters to images
                if (saveInLetterSet)
                {
                    for (int i = 0; i < savingLetters.Length; i++)
                    {
                        if (savingLetters[i])
                            (new FormSetLetter(letters[i])).ShowDialog();
                    }
                }
                else
                {
                    for (int k = 0; k < CST.NR_LETTERS; k++)
                    {
                        if (File.Exists(CST.IMAGE_LETTERS_DIR + "\\letter" + (k+1) + ".bmp"))
                            File.Delete(CST.IMAGE_LETTERS_DIR + "\\letter" + (k+1) + ".bmp");

                        letters_trimed[k].Save(CST.IMAGE_LETTERS_DIR + "\\letter" + (k+1) + ".bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                    }
                }
                #endregion

                imageBMP.Dispose();
                MessageBox.Show("Succesfully finished", "Message", MessageBoxButtons.OK);

                #region Open folder location
                if (showLetterFolder)
                {
                    string argument = "/select, " + CST.IMAGE_LETTERS_DIR + "\\letter1.bmp";
                    System.Diagnostics.Process.Start("explorer.exe", argument);
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        #region Useful methods
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
                    if (image.GetPixel(x, y) == CST.BLACK)
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
                    if (image.GetPixel(x, y) == CST.BLACK)
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
                    if (image.GetPixel(x, y) == CST.BLACK)
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
                    if (image.GetPixel(x, y) == CST.BLACK)
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

        //all neighbours from N-S-V-E directions which have the color lighter than the grid's color
        private List<Point> getValidNeighbours(int x, int y)
        {
            List<Point> list = new List<Point>();
            try
            {
                //from N
                if (y - 1 > 0 && imageBMP.GetPixel(x, y - 1).B == CST.GRIDCOLOR.B)
                    list.Add(new Point(x, y - 1));
                //from S
                if (y + 1 < imageBMP.Height && imageBMP.GetPixel(x, y + 1).B == CST.GRIDCOLOR.B)
                    list.Add(new Point(x, y + 1));
                //from V
                if (x - 1 > 0 && imageBMP.GetPixel(x - 1, y).B == CST.GRIDCOLOR.B)
                    list.Add(new Point(x - 1, y));
                //from E
                if (x + 1 < imageBMP.Width && imageBMP.GetPixel(x + 1, y).B == CST.GRIDCOLOR.B)
                    list.Add(new Point(x + 1, y));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            return list;
        }
        #endregion

        #region Events
        private void btnGetCaptchas_Click(object sender, EventArgs e)
        {
            new FormGetCaptchas().ShowDialog();
        }

        private void checkBoxShow_CheckedChanged(object sender, EventArgs e)
        {
            showLetterFolder = checkBoxShow.Checked;
        }

        private void checkBoxLetterSet_CheckedChanged(object sender, EventArgs e)
        {
            saveInLetterSet = checkBoxLetterSet.Checked;

            labelLetter1.Visible = saveInLetterSet;
            labelLetter2.Visible = saveInLetterSet;
            labelLetter3.Visible = saveInLetterSet;
        }

        private void labelLetter1_Click(object sender, EventArgs e)
        {
            if (labelLetter1.BorderStyle == BorderStyle.None)
            {
                labelLetter1.BorderStyle = BorderStyle.Fixed3D;
                savingLetters[0] = true;
            }
            else
            {
                labelLetter1.BorderStyle = BorderStyle.None;
                savingLetters[0] = false;
            }
        }

        private void labelLetter2_Click(object sender, EventArgs e)
        {
            if (labelLetter2.BorderStyle == BorderStyle.None)
            {
                labelLetter2.BorderStyle = BorderStyle.Fixed3D;
                savingLetters[1] = true;
            }
            else
            {
                labelLetter2.BorderStyle = BorderStyle.None;
                savingLetters[1] = false;
            }
        }

        private void labelLetter3_Click(object sender, EventArgs e)
        {
            if (labelLetter3.BorderStyle == BorderStyle.None)
            {
                labelLetter3.BorderStyle = BorderStyle.Fixed3D;
                savingLetters[2] = true;
            }
            else
            {
                labelLetter3.BorderStyle = BorderStyle.None;
                savingLetters[2] = false;
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(CST.CAPTCHAS_DIR))
                return;

            try
            {
                Array.ForEach(Directory.GetFiles(CST.CAPTCHAS_DIR), file => File.Delete(file));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        #endregion
    }
}
