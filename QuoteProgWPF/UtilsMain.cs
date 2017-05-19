using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Windows;
using System.Windows.Controls;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;

namespace QuoteProgWPF
{
    public static class UtilsMain
    {

        public static string ValidateTextInt(string text)
        {
            string nString = "";
            foreach (Char c in text.ToCharArray())
            {
                if (Char.IsDigit(c) || Char.IsControl(c))
                {
                    nString += c;
                }
            }

            return nString;
        }

        public static string ValidateTextDecimal(string text)
        {
            string nString = "";
            int count = 0;
            foreach (Char c in text.ToCharArray())
            {
                if (Char.IsDigit(c) || Char.IsControl(c) || (c == '.' && count == 0))
                {
                    nString += c;
                    if (c == '.')
                        count += 1;
                }
            }

            return nString;
        }

        public static void ParseCurrency(TextBox textBox)
        {
            Int32 selectionStart = textBox.SelectionStart;
            Int32 selectionLength = textBox.SelectionLength;

            string newText = "";
            //string newText = textBox.Text;
            decimal val = 0.00m;
            newText = ValidateTextDecimal(textBox.Text);
            decimal.TryParse(newText, out val);
            textBox.Text = "$" + string.Format("{0:N2}", val);
            textBox.SelectionStart = selectionStart <= textBox.Text.Length ? selectionStart + 1 : textBox.Text.Length;
        }

        public static void ParsePercent(TextBox textBox)
        {
            Int32 selectionStart = textBox.SelectionStart;
            Int32 selectionLength = textBox.SelectionLength;

            string newText = "";
            //string newText = textBox.Text;
            decimal val = 0.00m;
            newText = ValidateTextDecimal(textBox.Text);
            decimal.TryParse(newText, out val);
            
            textBox.Text = string.Format("{0:N2}" + "%", val);
            textBox.SelectionStart = selectionStart <= textBox.Text.Length ? selectionStart + 1 : textBox.Text.Length;
        }


    }
}
