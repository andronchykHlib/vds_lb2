using System;
using System.Linq;

namespace VDS___2LB
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            PrintBinaryToDecimal();
            StraightToAdditional();
        }

        static void StraightToAdditional()
        {
            Console.WriteLine("Enter binary number");
            long userInput = long.Parse(Console.ReadLine());
            string binaryNumber = $"{new String('0', 31 - Math.Abs(userInput).ToString().Length)}{Math.Abs(userInput)}";
            string symbolRank = userInput > 0 ? "0" : "1";
            string straightNumber = $"{symbolRank}{binaryNumber}";
            string additionalNumber = TranslateToAdditional(straightNumber);
            Console.WriteLine(additionalNumber);

            string TranslateToAdditional(string straight)
            {
                char[] straightNumbers = straight.ToCharArray();
                if (straight[0] == '0')
                {
                    return straight;
                }

                return PlusOne(TranslateToInversed(straightNumbers));
            }

            string PlusOne(char[] straight)
            {
                for (int i = straight.Length - 1; i > 1; i--)
                {
                    bool flag = true;
                    if (flag && (straight[i] - '0') + 1 > 1)
                    {
                        straight[i] = '0';
                        continue;
                    }

                    straight[i] = '1';
                    flag = false;
                    break;
                }

                return new string(straight);
            }

            char[] TranslateToInversed(char[] straight)
            {
                for (int i = 1; i < straight.Length; i++)
                {
                    if (straight[i] == '1')
                    {
                        straight[i] = '0';
                        continue;
                    }

                    straight[i] = '1';
                }

                return straight;
            }
        }

        static void PrintBinaryToDecimal()
        {
            string binaryNumber = Console.ReadLine();
            string[] numberParts = binaryNumber.Split(',');
            string intPart = numberParts[0];
            string floatPart = numberParts[1];
            int decimalIntPart = BinaryIntPartToDecimal(intPart);
            double decimalFloatPart = BinaryFloatPartToDecimal(floatPart);
            Console.WriteLine($"{decimalIntPart + decimalFloatPart}");
            
            int BinaryIntPartToDecimal(string part)
            {
                int result = 0;
                for (int i = part.Length - 1; i >= 0 ; i--)
                {
                    result += part[i] == '1' ? (int)Math.Pow(2, i) : 0;
                }

                return result;
            }

            double BinaryFloatPartToDecimal(string part)
            {
                double result = 0;
                for (int i = 0; i < part.Length; i++)
                {
                    result += part[i] == '1' ? Math.Pow(2, -(i + 1)) : 0;
                }

                return result;
            }
        }
    }
}