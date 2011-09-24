using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using BrokeReality.Properties;

namespace BrokeReality
{
    public partial class FormGetCaptchas : Form
    {
        private Regex regexValidAddress = new Regex(@"(http|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?");
        private Regex regexValidNumber = new Regex("[0-9]*");

        public FormGetCaptchas()
        {
            InitializeComponent();
        }

        #region Events
        private void FormGetCaptchas_Load(object sender, EventArgs e)
        {
            if (Settings.Default["Address"] != null && Settings.Default["Address"].ToString() != "")
                textBoxAddress.Text = Settings.Default["Address"].ToString();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                int nrImages = 0;

                #region Data Validations
                if (String.IsNullOrEmpty(textBoxAddress.Text) || !regexValidAddress.IsMatch(textBoxAddress.Text))
                    throw new Exception("Invalid address");
                if (String.IsNullOrEmpty(textBoxNrImages.Text) || !int.TryParse(textBoxNrImages.Text, out nrImages))
                    throw new Exception("Invalid number");
                #endregion

                //save last address as default
                Settings.Default["Address"] = textBoxAddress.Text;
                Settings.Default.Save();

                //download captchas
                progressBarCaptchas.Maximum = nrImages;
                progressBarCaptchas.Minimum = 0;
                for (int i = 0; i < nrImages; i++)
                {
                    Image captcha = DownloadImage(textBoxAddress.Text);

                    if(captcha != null)
                        captcha.Save(CST.CAPTCHAS_DIR + "\\captcha" + nextNumber(CST.CAPTCHAS_DIR).ToString() + ".bmp");
                    progressBarCaptchas.Value++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            this.Dispose();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Function to download Image from website
        /// http://www.digitalcoding.com/Code-Snippets/C-Sharp/C-Code-Snippet-Download-Image-from-URL.html
        /// </summary>
        /// <param name="_URL">URL address to download image</param>
        /// <returns>Image</returns>
        public Image DownloadImage(string _URL)
        {
            Image _tmpImage = null;

            try
            {
                // Open a connection
                System.Net.HttpWebRequest _HttpWebRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(_URL);

                _HttpWebRequest.AllowWriteStreamBuffering = true;

                // set timeout for 20 seconds (Optional)
                _HttpWebRequest.Timeout = 20000;

                // Request response:
                System.Net.WebResponse _WebResponse = _HttpWebRequest.GetResponse();

                // Open data stream:
                System.IO.Stream _WebStream = _WebResponse.GetResponseStream();

                // convert webstream to image
                if (!_WebResponse.ContentType.Contains("text/html"))
                    _tmpImage = Image.FromStream(_WebStream);

                // Cleanup
                _WebResponse.Close();
                _WebResponse.Close();
            }
            catch (Exception ex)
            {
                // Error
                MessageBox.Show(ex.Message, "Error");
                return null;
            }

            return _tmpImage;
        }

        //function used to calculate the next valid number for a captcha's file name (captcha<X>.bmp)
        private int nextNumber(string folder)
        {
            int nr = -1, tmp;

            try
            {
                string[] files = Directory.GetFiles(CST.CAPTCHAS_DIR, "*.bmp", SearchOption.TopDirectoryOnly);

                if (files.Length == 0)
                    return 1;

                for (int i = 0; i < files.Length; i++)
                {
                    files[i] = files[i].Replace(CST.CAPTCHAS_DIR + "\\", null);

                    if (!files[i].StartsWith("captcha") || files[i].Length < 12 || files[i].IndexOf('.', 7) == -1)
                        continue;

                    string strNr = files[i].Substring(7, files[i].IndexOf('.', 7) - 7);

                    if (int.TryParse(strNr, out tmp) && tmp > nr)
                        nr = tmp;
                }

                return ++nr;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return -1;
            }
        }
    }
        #endregion
}
