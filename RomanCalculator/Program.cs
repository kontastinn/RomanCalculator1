using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanCalculator
{
    internal class Program
    {
        //
        //using global variables to working with them in any method
        //
        static int[] Data = { 0, 0 };
        static int indexData = 0;
        static int dataResult;
        static int curr = 0;
        static string result;
        
        static void RomanToNumber()
        {           
            //
            //This method calls twice and check your input, divide your string to pieces like "CD",
            //If  method  cannot find a similar character, it will look for a character such as "C"
            //after for every character checking this method translate your string value into int variable and will store it
            //
            string s = Console.ReadLine();

            int[] num = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] rom = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            int index = 0;

            for (int i = 0; i < rom.Length && index < s.Length; i++)
            {
                for (int d = 0; d < rom.Length && index + 1 < s.Length; d++)
                {
                    string ch1 = s[index] + s[index + 1].ToString();
                    if (ch1 == rom[d])
                    {
                        Data[indexData] += num[d];
                        index++; index++;
                        d = -1;
                    }
                }

                if (index != s.Length)
                {
                    string ch = s[index].ToString();
                    if (ch == rom[i])
                    {
                        Data[indexData] += num[i];
                        index++;
                        i = -1;
                    }
                }
            }
        }
        //
        //this math method operate your two converted strings to int numbers
        //after the chosed one of four operations your result will be stored in your new int variable
        //
        static void Math()
        {
            Console.WriteLine("\nChoose an operation:\n1 - Plus\n2 - Minus\n3 - Multiply\n4 - Divide");
            Console.Write("\nEnter: ");
            string answer = Console.ReadLine();
            Console.WriteLine();
            if (answer == "1")
                dataResult = Data[0] + Data[1];
            else if (answer == "2")
                dataResult = Data[0] - Data[1];
            else if (answer == "3")
                dataResult = Data[0] * Data[1];
            else if (answer == "4")
                dataResult = Data[0] / Data[1];
            else
            {
                Console.ReadLine();
                return;
            }
            curr++;
            //the last method for stored int variable
            NumberToRoman(dataResult);
        }
        //
        // the last method will convert your int result which is stored in your new int variable, to a string result
        //
        static void NumberToRoman(int value)
        {
            string[] units = { " ", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };
            string[] dozens = { "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
            string[] hundreds = { "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
            string[] thousands = { "M", "MM", "MMM" };

            //int value and the result  must be between between 1 and 3999
            // if you will be outside of these values the method will return nothing;
            if (value >= 1000 && value < 3999)
            {
                int Thousands = value / 1000; value %= 1000;
                string result = thousands[Thousands - 1];
                if (curr == 1) Console.Write(result);
            }

            if (value >= 100 && value < 1000)
            {
                int Hundreds = value / 100; value %= 100;
                string result = hundreds[Hundreds - 1];
                if (curr == 1) Console.Write(result);
            }

            if (value >= 10 && value < 100)
            {
                int Dozens = value / 10; value %= 10;
                string result = dozens[Dozens - 1];
                if (curr == 1) Console.Write(result);
            }

            if (value > 0 && value < 10)
            {
                string result = units[value];
                if (curr == 1) Console.Write(result);
            }
        }

        //
        //this method is the final program for calling it in Main, just summing all of these methods into one big method
        //
        static void RomanCalculator()
        {
                Console.Write("Enter first Roman value: ");
                RomanToNumber();
                indexData++;
                Console.WriteLine();
                Console.Write("Enter second Roman value: ");
                RomanToNumber();
                Math();
                Console.ReadLine();           
        }

        static void Main()
        {
            //calling method
            RomanCalculator();
            Console.WriteLine();
        }


        

    }


}
