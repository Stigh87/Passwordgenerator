using System;
using System.Collections.Generic;

namespace WeekOne
{
    class Program
    {
        static readonly Random Random = new Random();
        static void Main(string[] args)
        {
            if (!IsValid(args))
            {
                PrintMenu();
                return;
            }else
            { 

                var passord = "lLssdd";
                List<string> newPassword = new List<string>();
                string tempPasword = passord.PadLeft(Convert.ToInt32(args[0]), 'l');
                int lastIndex = tempPasword.Length - 1;
              
                GeneratePassword(newPassword, ref tempPasword, ref lastIndex);

              
            
                Console.WriteLine("Ur pasword is: ");
                foreach (var letter in newPassword)
                {
                    Console.Write(letter);
                }

                Console.WriteLine("");

            }

        }

        private static void GeneratePassword(List<string> newPassword, ref string tempPasword, ref int lastIndex)
        {
            while (tempPasword.Length > 0)
            {
                var randomIndex = Random.Next(0, lastIndex);
               
                if (tempPasword[randomIndex] == 'd')
                {
                    string tempDigit = WriteRandomDigit();
                    newPassword.Insert(0, tempDigit);
                    tempPasword = tempPasword.Remove(randomIndex, 1);
                    lastIndex--;

                }
                else if (tempPasword[randomIndex] == 'L')
                {
                    string tempCapLetter = WriteRandomUpperCaseLetter(65, 91);
                    newPassword.Insert(0, tempCapLetter);
                    tempPasword = tempPasword.Remove(randomIndex, 1);
                    lastIndex--;

                }
                else if (tempPasword[randomIndex] == 'l')
                {
                    string tempLetter = WriteRandomLowerCaseLetter(97, 123);
                    newPassword.Insert(0, tempLetter);
                    tempPasword = tempPasword.Remove(randomIndex, 1);
                    lastIndex--;

                }
                else if (tempPasword[randomIndex] == 's')
                {
                    string tempSymbol = WriteRandomSpecialCharacter();
                    newPassword.Insert(0, tempSymbol);
                    tempPasword = tempPasword.Remove(randomIndex, 1);
                    lastIndex--;

                }

            }
        }

        private static string WriteRandomSpecialCharacter()
        {
            var randomNr = GetRandomLetter((char)0, (char)13);
            string spesialTegn = "(!#¤%&/(){}[]";
            return spesialTegn[randomNr].ToString();
        }

        private static string WriteRandomUpperCaseLetter(int v1, int v2)
        {
            var randomLetter = GetRandomLetter((char)v1, (char)v2);
            return randomLetter.ToString();
        }

        private static string WriteRandomLowerCaseLetter(int v1, int v2)
        {  
           var randomLetter = GetRandomLetter((char)v1, (char)v2);
            return randomLetter.ToString();
        }

        private static string WriteRandomDigit()
        {
            int tempNr = Random.Next(0, 10);
            return tempNr.ToString();
        }

        static char GetRandomLetter(char min, char max)
        {
            return (char)Random.Next(min, max);
        }

        private static bool IsValid(string[] args)
        {
            if (args.Length == 0)
            {
                return false;
            }
            if (args.Length == 2)
            {
                var argumentOne = args[0];
                foreach (var character in argumentOne)
                {
                    var isDigit = char.IsDigit(character);
                    if (isDigit == false)
                    {
                        return false;
                    }
                    else continue;
                }

                var argumentTwo = args[1];
                if ((argumentTwo.Contains('l')) &&
                    (argumentTwo.Contains('L')) &&
                    (argumentTwo.Contains('s')) &&
                    (argumentTwo.Contains('d')))
                {
                    return true;
                }
            }
            return true;

        }
        private static void PrintMenu()
        {
            string optionsText = @" PasswordGenerator
            Options:
              - l = lower case letter
              - L = upper case letter
              - d = digit
            - s = special character (!""#¤%&/(){}[]
            Example: PasswordGenerator 14 lLssdd
             Min. 1 lower case
             Min. 1 upper case
             Min. 2 special characters
             Min. 2 digits";
            Console.WriteLine(optionsText);
        }
    }

}
