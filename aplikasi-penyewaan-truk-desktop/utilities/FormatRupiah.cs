using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Text.RegularExpressions;

namespace desktop.utilities
{
    public static class FormatRupiah
    {
        public static string ToRupiah(this long angka)
        {
            return String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", angka);
        }
        /**
        * // Usage example: //
        * int angka = 10000000;
        * System.Console.WriteLine(angka.ToRupiah()); // -> Rp. 10.000.000
        */

        public static int ToAngka(this string rupiah)
        {
            return int.Parse(Regex.Replace(rupiah, @",.*|\D", ""));
        }
        /**
        * // Usage example: //
        * string rupiah = "Rp 10.000.123,00";
        * System.Console.WriteLine(rupiah.ToAngka()); // -> 10000123
        */

    }
}
