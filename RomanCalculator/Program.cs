using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RomanCalculator
{
    internal class Program
    {
        private static int[] Data = new int[2];
        private static int indexData;
        private static int dataResult;

        /// <summary>
        /// Calculating two Roman values
        /// </summary>
        static void RomanCalulate()
        {
            string answer = "yes";

            while (answer == "yes")
            {
                indexData = 0;
                Data[0] = 0;
                Data[1] = 0;
                Console.Clear();
                try
                {
                    Console.Write("Enter first Roman value: ");
                    RomanToInt();
                    indexData++;
                    Console.Write("\nEnter second Roman value: ");
                    RomanToInt();
                    Console.WriteLine("\nChoose math operaton:\n1 - plus\n2 - minus\n3 - multiply\n4 - divide (returns only int value)\n");
                    Console.Write("Enter here: ");
                    string answer1 = Console.ReadLine();
                    if (answer1 == "1")
                        dataResult = Data[0] + Data[1];
                    else if (answer1 == "2")
                        dataResult = Data[0] - Data[1];
                    else if (answer1 == "3")
                        dataResult = Data[0] * Data[1];
                    else if (answer1 == "4")
                        dataResult = Data[0] / Data[1];
                    else
                    {
                        Console.WriteLine("\nYou chose wrong option, try again");
                        Console.ReadLine();
                        Console.Clear();
                        continue;
                    }
                    Console.Write("\nYour result is : ");
                    IntToRoman();
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
        /// Converting Roman value to int
        /// </summary>
        /// <param name="romanValue"></param>
        /// <returns></returns>
        static void RomanToInt()
        {
            string romanValue = Console.ReadLine();
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
                    Data[indexData] -= currentNumber;
                }
                else
                {
                    Data[indexData] += currentNumber;
                }
            }
        }

        /// <summary>
        /// Converting int to Roman value
        /// </summary>
        /// <param name="value"></param>
        static void IntToRoman()
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
            if (dataResult == 0)
            {
                romanResult = "0";
            }
            foreach (var item in romanNumbersDictionary.Reverse())
            {
                while (dataResult > 0 && dataResult >= item.Value)
                {
                    dataResult -= item.Value;
                    romanResult += item.Key;
                }
            }
            Console.Write(romanResult);
        }

        static void Main()
        {
            RomanCalulate();
        }
    }
}
