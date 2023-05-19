using System;

namespace ConsoleApp2
{
    static class Roman
    {
        static void NumberToRoman(int value)
        {
            string[] units = { " ", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };
            string[] dozens = { "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
            string[] hundreds = { "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
            string[] thousands = { "M", "MM", "MMM" };

            if (value >= 1000 && value < 3999)
            {
                int Thousands = value / 1000; value %= 1000;
                string result = thousands[Thousands - 1];
            }

            if (value >= 100 && value < 1000)
            {
                int Hundreds = value / 100; value %= 100;
                string result = hundreds[Hundreds - 1];
            }

            if (value >= 10 && value < 100)
            {
                int Dozens = value / 10; value %= 10;
                string result = dozens[Dozens - 1];
            }

            if (value > 0 && value < 10)
            {
                string result = units[value];
            }
        }
    }
}


