using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace NamLa.Models.Process
{
    public class StringProcess
    {
        public string AutoGenerateKey(string MaSanPham)
        {
            string numPart, strPart, newKey = "", newNumpart = "";
            int a;
            numPart = Regex.Match(MaSanPham, @"\d+").Value;
            strPart = Regex.Match(MaSanPham, @"\D+").Value;
            a = Convert.ToInt32(numPart) + 1;
            for (int i = 0; i < numPart.Length - a.ToString().Length; i++)
            {
                newNumpart += "0";
            }
            newNumpart += a;
            newKey = strPart + newNumpart;
            return newKey;
        }
    }
}