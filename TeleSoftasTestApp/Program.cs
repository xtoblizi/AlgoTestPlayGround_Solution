using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TeleSoftasTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // retrieve idNumbers
            var numbers = new List<string>();
            
            foreach (var number in numbers)
            {
                // pre-processings
                bool validationResult = NationalId.PreProcessIdNumber(number) && NationalId.Validate(number);
                
                Console.WriteLine("The NationId Number Validation Result is ==> {0}" , validationResult.ToString());
            }
        }
    }
    public class NationalId
    {
        public static bool Validate(string idNumber)
        {
            var isValidNumber =  long.TryParse(idNumber, out _);
             var controlDigit = 0;
             if (!isValidNumber)
                 return false;

             controlDigit = idNumber[^1];
             var factor = 1;
             long sum = 0;
            
             sum = GetSum(idNumber, factor);

             var d = sum % 11;
             if (d < 10)
                 return d == controlDigit;
             
             // recursive process;
             factor = 3;
             sum = GetSum(idNumber, factor);
             d = sum % 11;
             if (d < 10)
                 return d == controlDigit;
             
             return controlDigit == 0;
        }

        public async Task<List<string>> ReadIdsOverHttp(string url)
        {
            var client = new HttpClient();
            var httpTask = await client.GetAsync(url);
            
            if (!httpTask.IsSuccessStatusCode) return null;
            
            // perform deserialization 
            var content = await httpTask.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<string>>(content);
        }
        public static bool PreProcessIdNumber(string idNumber)
        {
            if (idNumber.Length != 11)
                return false;

            return true;
        }

        private static long GetSum(string idNumber, int factor)
        {
            var sum = 0;
            var counter = 0;
            while (counter < idNumber.Length -1)
            {
                if (factor == 10)
                    factor = 1;
                    
                int number = idNumber[counter];
                sum += (number * factor);

                counter++;
                factor++;
            }

            return sum;
        }
    }
}