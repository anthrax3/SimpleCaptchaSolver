using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace BrokeReality
{
    class CST
    {
        public static string TEMP_DIR = Application.StartupPath + "\\Temp";
        public static string IMAGE_LETTERS_DIR = Application.StartupPath + "\\ImageLetters";
        public static string LETTER_SET_DIR = Application.StartupPath + "\\LetterSet";
        public static string CAPTCHAS_DIR = Application.StartupPath + "\\Captchas";
        public static Color LIGHTESTBLACKCOLOR = Color.FromArgb(255, 100, 100, 100);
        public static Color GRIDCOLOR = Color.FromArgb(255, 204, 204, 204);
        public static Color BLACK = Color.FromArgb(255, 0, 0, 0);
        public static Color WHITE = Color.FromArgb(255, 255, 255, 255);
    }
}
