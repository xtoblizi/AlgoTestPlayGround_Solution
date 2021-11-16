using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CoderByte.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var result = getUserNamesWebREsponse(10)?.Result;
            var i = 0;
            foreach (var item in result)
            {
                Console.WriteLine($"{i} => {item}");
                i++;
            }
        }
        private static string CleanJson(string strigifiedJson)
        {
            var splittedJson = strigifiedJson.Split(',').ToList();
            var processed = splittedJson.RemoveAll((x => x.Contains("N/A") || x.Contains('-') || x.Contains(' ')));
            var result = string.Empty;
            result = string.Join(',', splittedJson);

            foreach (var x in splittedJson)
            {
                if( x.Contains("N/A") || x.Contains('-') || x.Contains(' '))
                {
                    splittedJson.Remove(x);
                }
            }

            result = string.Join(',', splittedJson);
            return result;           
        }

        public async static Task<List<string>> getUserNamesWebREsponse(int threshold)
        {
            var pagenumber = 1;
            var url = $"https://jsonmock.hackerrank.com/api/article_users?page={pagenumber}";
            var url2 = $"https://coderbyte.com/api/challenges/json/json-cleaning";
            WebRequest request = WebRequest.Create(url2);
            WebResponse response = (HttpWebResponse)request.GetResponse();
            Console.WriteLine($"The content Length of request is {response.ContentLength}");
           
            using (StreamReader streamreader = new StreamReader(response.GetResponseStream()))
            {
                string stringifiedResult = streamreader.ReadLine();

                Console.WriteLine($"This is the value of the response using a stream reader = >{ stringifiedResult}");

                var cleanedUp = CleanJson(stringifiedResult);
            }

            //using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            //{
            //    string str =  reader.ReadLine();

            //    Console.WriteLine($"First reader value {str}");
            //    Console.WriteLine($"Status Code => {response.ToString()}");
            //    //return str.Split(':').ToList();
            //};
            
            return null;
        }

    }
}
