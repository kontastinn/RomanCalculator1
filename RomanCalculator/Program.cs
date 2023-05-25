using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RomanCalculator
{

    class RomanCalculator
    {
        /// <summary>
        /// Calculates Roman Numbers
        /// </summary>
        public void RomanCalculate() 
        {
            string answer = "yes";
            while (answer == "yes")
            {
                string romanNumber;
                int[] arabicData = new int[2];
                int arabicDataIndex = 0;
                int arabicResult = 0;
                try
                {
                    Console.Clear();
                    Console.Write("Enter first Roman value: ");
                    romanNumber = Console.ReadLine();
                    arabicData[arabicDataIndex] = RomanToInt(romanNumber);
                    arabicDataIndex++;

                    Console.Write("Enter second Roman value: ");
                    romanNumber = Console.ReadLine();
                    arabicData[arabicDataIndex] = RomanToInt(romanNumber);

                    Console.WriteLine("\nChoose math operaton:\n1 - plus\n2 - minus\n3 - multiply\n4 - divide (returns only int value)\n");
                    Console.Write("Enter here: ");
                    string answer1 = Console.ReadLine();
                    if (answer1 == "1")
                        arabicResult = arabicData[0] + arabicData[1];
                    else if (answer1 == "2")
                        arabicResult = arabicData[0] - arabicData[1];
                    else if (answer1 == "3")
                        arabicResult = arabicData[0] * arabicData[1];
                    else if (answer1 == "4")
                        arabicResult = arabicData[0] / arabicData[1];
                    else
                    {
                        Console.WriteLine("\nYou chose wrong option, try again");
                        Console.ReadLine();
                        Console.Clear();
                        continue;
                    }
                    Console.Write("\nYour result is " + IntToRoman(arabicResult));
                    Console.Write("\n\nIf you wanna try again enter \"yes\": ");
                    answer = (Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("\nyou entered wrong value, try again");
                    Console.ReadLine();
                    Console.Clear();
                }
                Console.WriteLine();



            }


        }

        /// <summary>
        /// Converting Roman number to int
        /// </summary>
        /// <param name="romanValue"></param>
        /// <returns></returns>
        public int RomanToInt(string romanValue)
        {
            int arabicNumber = 0;
            Dictionary<char, int> romanNumbersDictionary = new()
            {
                {'I', 1  },
                {'V', 5  },
                {'X', 10  },
                {'L', 50  },
                {'C', 100 },
                {'D', 500 },
                {'M', 1000}
            };
            for (int i = 0; i < romanValue.Length; i++)
            {
                char currentRomanChar = romanValue[i];
                romanNumbersDictionary.TryGetValue(currentRomanChar, out int currentNumber);

                if (i + 1 < romanValue.Length && romanNumbersDictionary[romanValue[i + 1]] > romanNumbersDictionary[currentRomanChar])
                {
                    arabicNumber -= currentNumber;
                }
                else
                {
                    arabicNumber += currentNumber;
                }

            }
            return arabicNumber;
        }

        /// <summary>
        /// Converting int to Roman number
        /// </summary>
        /// <param name="value"></param>
        static string IntToRoman(int arabicNumber)
        {
            string romanResult = string.Empty;
            Dictionary<string, int> romanNumbersDictionary = new()
            {
                {"I", 1  },
                {"IV",4  },
                {"V", 5  },
                {"IX",9  },
                {"X", 10  },
                {"XL",40  },
                {"L", 50  },
                {"XC",90  },
                {"C", 100 },
                {"CD",400 },
                {"D", 500 },
                {"CM",900 },
                {"M", 1000}
            };
            if (arabicNumber == 0)
            {
                romanResult = "0";
            }
            foreach (var item in romanNumbersDictionary.Reverse())
            {
                while (arabicNumber > 0 && arabicNumber >= item.Value)
                {
                    arabicNumber -= item.Value;
                    romanResult += item.Key;
                }
            }
            return romanResult;
        }
    }
    internal class Program
    {       
        static void Main()
        {
            RomanCalculator romanCalculator = new RomanCalculator();
            romanCalculator.RomanCalculate();
        }
    }
}
