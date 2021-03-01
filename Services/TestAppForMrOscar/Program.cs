using System;

namespace TestAppForMrOscar
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("########################");
            var result = ReverseString("Developers are awesome");
            Console.WriteLine(result);
            Console.ReadLine();


        }

        private static string ReverseString(string input){

            var splittedString = input.Split(" ");
            var result = string.Empty;
            int count = splittedString.Length -1;

            for (int i = splittedString.Length - 1; i >=0; i--)
            {
                //var addspace = string.Empty;
                if (i < splittedString.Length)
                {
                    result += $"{splittedString[i]} ";
                }
                else
                {
                    result += $"{splittedString[i]}";
                }
            }

            return result;
        }
            


    }
}
