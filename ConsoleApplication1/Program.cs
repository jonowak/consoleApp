using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckDigit
{
    class CheckDigit
    {
        static void Main(string args)
        {
            string cDigit;
            cDigit = GenerateCheckDigit(args);
        }

        public static string GenerateCheckDigit(string cusip)
        {
            int sum = 0;
            char[] digits = cusip.ToUpper().ToCharArray();
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ*@#";

            for (int i = 0; i < digits.Length; i++)
            {
                int val;
                if (!int.TryParse(digits[i].ToString(), out val))
                    val = alphabet.IndexOf(digits[i]) + 10;

                if ((i % 2) != 0)
                    val *= 2;

                val = (val % 10) + (val / 10);

                sum += val;
            }

            int check = (10 - (sum % 10)) % 10;

            return check.ToString();
        }
    }
}
