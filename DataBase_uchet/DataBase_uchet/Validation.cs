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
        public bool isNumeric(string inp, string exp = @"^([+]380)[0-9]{9}$") => Regex.IsMatch(inp, exp) ? true : false;
        public bool isMailCorrect(string inp)
        {
            string exp = @"^[A-Za-z0-9._-]+@[A-Za-z0-9]+\.[A-Za-z]{2,5}$";
            bool check = false;
            string newStr = "";

            if (!Regex.IsMatch(inp, exp))
                return false;
            for (int i = 0; i < inp.Length; i++)
                if (inp[i] != '@')
                    newStr += inp[i];
                else
                    break;
            MatchCollection matchesNum = Regex.Matches(newStr, @"[0-9]");
            MatchCollection matchesSym = Regex.Matches(newStr, @"[A-Za-z]");
            if (matchesNum.Count >= 1 && matchesSym.Count >= 1 && newStr.Length >= 6 && newStr.Length <= 30)
                check = true;

            return check;
        }
        public bool isNickname(string inp)
        {
            string exp = @"[a-zA-Z0-9.-_]";
            bool check = false;

            if (!Regex.IsMatch(inp, exp) && !(inp.Length >= 4 && inp.Length <= 16))
                return false;
            MatchCollection matchesNum = Regex.Matches(inp, @"[0-9]");
            MatchCollection matchesSym = Regex.Matches(inp, @"[A-Za-z]");
            if(matchesNum.Count >= 1 && matchesSym.Count >= 1 && inp.Length >= 4 || 
                (matchesNum.Count == 0 && matchesSym.Count == inp.Length && inp.Length >=4))
                check = true;

            return check;
        }
        public bool isCombined(string inp, int min, int max, string exp = @"[a-zA-Z0-9.,-]") => (Regex.IsMatch(inp, exp) && inp.Length >= min && inp.Length <= max) ? true : false;
        public bool isValidAddres(string inp)
        {
            string exp = @"[a-zA-Z0-9.,-/]";
            bool check = false;

            if (!Regex.IsMatch(inp, exp) && !(inp.Length >= 6 && inp.Length <= 56))
                return false;
            MatchCollection matchesNum = Regex.Matches(inp, @"[0-9]");
            MatchCollection matchesSym = Regex.Matches(inp, @"[A-Za-z]");
            if (matchesNum.Count >= 1 && matchesSym.Count >= 3)
                check = true;
            return check;
        }
        public bool isSymbolic(string inp, int min, int max, string exp = @"^[a-zA-Z]{3,16}$") => (Regex.IsMatch(inp, exp) && inp.Length >= min && inp.Length <= max) ? true : false;
        public bool isSymbolicInput(string inp, string exp = @"^[a-zA-Z]{3,16}$") => (Regex.IsMatch(inp, exp)) ? true : false;
        public bool isCombinedPress(char ch)
        {
            string exp = @"[a-zA-Z0-9.,-/]";

            if (Regex.IsMatch(ch.ToString(), exp))
                return true;

            return false;
        }
        public bool isNumericPress(char ch, string str)
        {
            string exp = @"[0-9]";

            if (str.StartsWith("+") || Convert.ToInt32(ch) == 43)
            {
                if (Regex.Matches(str, @"[+]").Count == 0 && Convert.ToInt32(ch) == 43)
                    return true;
                if (str.Length < 13 && Regex.IsMatch(ch.ToString(), exp) && Regex.Matches(str, @"[+]").Count == 1 
                    || Convert.ToInt32(ch) == 8)
                    return true;
            }

            return false;
        }
        public bool isSymbolicPress(char ch)
        {
            string exp = @"^[a-zA-Z]$";

            if (Regex.IsMatch(ch.ToString(), exp))
                return true;
            return false;
        }
        public bool checkDate(string s, string obj)
        {
            if (Regex.IsMatch(s, "[0-9.]{10}") && s.Length == 10)
            {
                int gotDay, gotMonth, gotYear;
                string[] dates = s.Split('.');
                gotDay = Convert.ToInt32(dates[0]);
                gotMonth = Convert.ToInt32(dates[1]);
                gotYear = Convert.ToInt32(dates[2]);

                if (obj == "dob")
                {
                    if (gotDay < 32 && gotMonth < 13 && gotYear < 2002 && gotDay > 0 && gotMonth > 0 && gotYear > 1969)
                        return true;
                    else
                        MessageBox.Show("Dates aren't available!");
                }
                if (obj == "dupd")
                {
                    if (gotDay > 0 && gotMonth > 0 && gotYear > 1999 && gotYear < 2020)
                        return true;
                    else
                        MessageBox.Show("Dates aren't available!");
                }
                if (obj == "hd")
                {
                    if (gotDay > 0 && gotMonth > 0 && gotYear == 2020)
                        return true;
                    else
                        MessageBox.Show("Dates aren't available!");
                }    
            }
            else
                MessageBox.Show("Check the size or correctness of the field");
            return false;
        }
        public PictureBox CreateImg(int posX, int posY, string Name)
        {
            PictureBox pb = new PictureBox();
            pb.Left = posX;
            pb.Top = posY;

            pb.Name = Name;
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