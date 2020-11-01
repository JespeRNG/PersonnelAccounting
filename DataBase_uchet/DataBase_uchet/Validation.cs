using Microsoft.SqlServer.Server;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;

namespace DataBase_uchet
{
    class Validation
    {
        public bool isNumeric(string inp, string exp = @"^([+38][0-9]{12})$") => Regex.IsMatch(inp, exp) ? true : false;
        public bool isMailCorrect(string inp, string exp = @"^[A-Za-z0-9._-]+@[A-Za-z0-9]+\.[A-Za-z]{2,5}$") => Regex.IsMatch(inp, exp) ? true : false;
        public bool isCombined(string inp, int min, int max, string exp = @"^[a-zA-Z0-9.,-]") => (Regex.IsMatch(inp, exp) && inp.Length >= min && inp.Length <= max) ? true : false;
        public bool isSymbolic(string inp, int min, int max, string exp = @"[A-Za-z]") => (Regex.IsMatch(inp, exp) && inp.Length >= min && inp.Length <= max) ? true : false;

        public PictureBox CreateImg(bool status, int posX, int posY)
        {
            PictureBox pb = new PictureBox();
            pb.Left = posX;
            pb.Top = posY;

            pb.Image = Image.FromFile(@"..\..\imgs\crossPNG.png");

            pb.BringToFront();
            pb.Visible = true;
            pb.Width = 20;
            pb.Height = 20;
            pb.SizeMode = PictureBoxSizeMode.StretchImage;

            return pb;
        }
    }
}