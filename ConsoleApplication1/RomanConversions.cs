using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class RomanConversions
    {
        List<string> RomanList = new List<string>();
        List<char> NumeralList = new List<char>();
        int remainder;
        int romans2Add;
        int decConvertTotal;
        public void MainBuild() {
            Console.WriteLine("Would you like to check a 1) Roman Numeral or 2) a regular Integer?");
            int numDefinition = int.Parse(Console.ReadLine());
            if (numDefinition == 2)
            {
                Console.WriteLine("Please input your Number.");
                int Number = int.Parse(Console.ReadLine());
                decConvertTotal = 0;
                SwitchtoStart(Number);
            }else if (numDefinition == 1)
            {
                Console.WriteLine("Please input your Number.");
                string RomeNumber = Console.ReadLine();
                decConvertTotal = 0;
                ConvertFromRome(ListCreator(RomeNumber));
            }
        }
        public void RomanAssigner(int Num2Convert, int Divisor, int SecondaryDivisor, string Letter2Add, string SecondaryOpp)
        {
            if (Num2Convert < Divisor)
            {
                RomanList.Add(SecondaryOpp);
                RomanList.Add(Letter2Add);
                remainder = Num2Convert % SecondaryDivisor;
                SwitchtoStart(remainder);
            }
            else if (Num2Convert >= Divisor)
            {
                romans2Add = Num2Convert / Divisor;
                remainder = Num2Convert % Divisor;
                for (int i = 0; i < romans2Add; i++)
                {
                    RomanList.Add(Letter2Add);
                }
                SwitchtoStart(remainder);
            }
        }
        public void SwitchtoStart(int Num2Convert)
        {
            if (Num2Convert >= 900)
            {
                RomanAssigner(Num2Convert, 1000, 900, "M", "C");
            }
            else if (Num2Convert >= 400)
            {
                RomanAssigner(Num2Convert, 500, 400, "D", "C");
            }
            else if (Num2Convert >= 90)
            {
                RomanAssigner(Num2Convert, 100, 90, "C", "X");
            }
            else if (Num2Convert >= 40)
            {
                RomanAssigner(Num2Convert, 50, 40, "L", "X");
            }
            else if (Num2Convert >= 9)
            {
                RomanAssigner(Num2Convert, 10, 9, "X", "I");
            }
            else if (Num2Convert >= 4)
            {
                RomanAssigner(Num2Convert, 5, 4, "V", "I");
            }
            else if (Num2Convert >= 1)
            {
                RomanAssigner(Num2Convert, 1, 0, "I", "I");
            }
            else {
                ListConverter();
                RomanList.Clear();
            }
        }
        public int RomeConverter(char RomeDig)
        {
            int number;
            switch (RomeDig)
            {
                case 'M':
                    number = 1000;
                    return number;
                case 'D':
                    number = 500;
                    return number;
                case 'C':
                    number = 100;
                    return number;
                case 'L':
                    number = 50;
                    return number;
                case 'X':
                    number = 10;
                    return number;
                case 'V':
                    number = 5;
                    return number;
                case 'I':
                    number = 1;
                    return number;
                default:
                    number = 0;
                    return number;
            }
        }
        public void ListConverter()
        {
            string JoinedNumber = string.Join("", RomanList);
            Console.WriteLine(JoinedNumber);
            MainBuild();
        }
        public string ListCreator(string UserInput)
        {
            int WordLength = UserInput.Count();
            String InputConverted = UserInput.ToUpper();
            NumeralList.Add('P');
            for (int i = 0; i <= WordLength - 1; i++)
            {
                NumeralList.Add(InputConverted.ElementAt(i));
            }
            NumeralList.Add('P');
            return InputConverted;
        }
        public void ConvertFromRome(string UserInput)
        {
            int listSize = NumeralList.Count();
            for (int i = 1; i < listSize - 1; i++)
            {
                char inRome = NumeralList.ElementAt(i);
                char inRomeNext = NumeralList.ElementAt(i + 1);
                char inRomeBefore = NumeralList.ElementAt(i - 1);
                if (i == 1)
                {
                    if (inRome == inRomeNext)
                    {
                        decConvertTotal = decConvertTotal + RomeConverter(inRome);
                    }
                    else if (i+2 == listSize)
                    {
                        decConvertTotal = decConvertTotal + RomeConverter(inRome);
                    }
                    else if (inRome != inRomeNext)
                    {
                        if (RomeConverter(inRomeNext) > RomeConverter(inRome))
                        {
                            decConvertTotal = decConvertTotal + (RomeConverter(inRomeNext) - RomeConverter(inRome));
                            i = i + 1;
                        }
                        else
                        {
                            decConvertTotal = decConvertTotal + RomeConverter(inRome);
                        }
                    }
                }
                else if (inRome == inRomeBefore)
                {
                    decConvertTotal = decConvertTotal + RomeConverter(inRome);
                }
                else if (inRome != inRomeBefore && inRome != inRomeNext)
                {
                    if (RomeConverter(inRomeNext) > RomeConverter(inRome))
                    {
                        decConvertTotal = decConvertTotal + (RomeConverter(inRomeNext) - RomeConverter(inRome));
                        i = i + 1;
                    }
                    else
                    {
                        decConvertTotal = decConvertTotal + RomeConverter(inRome);
                    }
                }
            }
            Console.WriteLine("The Roman Numeral " + UserInput + " is equal to a decimal value of " + decConvertTotal);
            NumeralList.Clear();
            MainBuild();
        }
    }
}
