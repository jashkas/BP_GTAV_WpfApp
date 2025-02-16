using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BP_GTAV_WpfApp
{
    internal class NumberFormater
    {
        internal static string FormatNumberWithMask(string input)
        {
            // Форматируем строки по заданной маске
            if (input.Length == 4) // 0 000
            {
                return Regex.Replace(input, @"(\d)(\d{3})?", "$1 $2").Trim();
            }
            else if (input.Length <= 6) // 00 000
            {
                return Regex.Replace(input, @"(\d{2})(\d{3})?", "$1 $2").Trim();
            }
            else if (input.Length <= 7) // 0 000 000
            {
                return Regex.Replace(input, @"(\d)(\d{3})(\d{3})?", "$1 $2 $3").Trim();
            }
            else // Максимальные значения
            {
                return Regex.Replace(input, @"(\d{3})(\d{3})(\d+)", "$1 $2 $3").Trim();
            }
        }
    }
}
