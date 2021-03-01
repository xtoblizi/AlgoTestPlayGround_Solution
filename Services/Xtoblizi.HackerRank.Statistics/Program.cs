using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Xtoblizi.HackerRank.Statistics
{
    class Program
    {
        public static void fizzBuzz(int k)
        {
            if (k >= 1)
            {
                for (int n = 1; n <= k; n++)
                {
                    if (n % 3 == 0 && n % 5 == 0)
                        Console.WriteLine("FizzBuzz");
                    else if (n % 3 == 0 && n % 5 != 0)
                        Console.WriteLine("Fizz");
                    else if (n % 5 == 0 && n % 3 != 0)
                        Console.WriteLine("Buzz");
                    else if (n % 3 != 0 && n % 5 != 0)
                        Console.WriteLine(n);
                    else
                        Console.WriteLine("Not Implemented,coming soon");
                }
            }
            else
            {
                Console.WriteLine("You have entered an invalid number in the allowed range");
            }
        }

        public async static Task<int> getTotalGoals(string team, int year)
        {
            var page = 1;
            var totalPages = 1;
            var totalGoals = 0;
            do
            {
                using (var client = new HttpClient())
                {
                    var url = $"https://jsonmock.hackerrank.com/api/football_matches?year={year}&team1={team}&page={page}";
                    var url2 = $"http://10.0.0.46:5116/api/SmsClient/GetAllSmsClient?startIndex=0&count=2147483647";
                    var response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var stringResponse = await response.Content.ReadAsStringAsync();
                        var deserialized = JsonSerializer.Deserialize<HttpUserResponse>(stringResponse);
                        if (deserialized != null)
                        {
                            //totalPages = deserialized.total_pages;
                            //totalGoals += deserialized.data.team1goals;
                        }
                    }
                }
            } while (page <= totalPages);

            return totalGoals;
        }

        #region Test JsonObject field value extraction
        public async static Task<List<string>> getUserNameskeyValue(int threshold)
        {
            var pagenumber = 1;
            var totalPage = 1;
            var result = new List<string>();
            do
            {
                using (var client = new HttpClient())
                {
                    var url = $"https://jsonmock.hackerrank.com/api/article_users?page={pagenumber}";
                    var response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var stringResponse = await response.Content.ReadAsStringAsync();
                        var deserialiedResponse = DeserializeJson(stringResponse, User.UserListFiedlValuePair());

                        //totalPage = deserialiedResponse.total_pages;
                        //pagenumber++;
                        //result.AddRange(ReturnThreshingUsers(deserialiedResponse, threshold));
                    }
                }


            } while (pagenumber <= totalPage);

            return result;
        }
        #endregion

        public async static Task<List<string>> getUserNames(int threshold)
        {
            var pagenumber = 1;
            var totalPage = 1;
            var result =new List<string>();
            do
            {
                using (var client = new HttpClient())
                {
                    var url = $"https://jsonmock.hackerrank.com/api/article_users?page={pagenumber}";
                    var response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var stringResponse = await response.Content.ReadAsStringAsync();
                        var deserialiedResponse = DeserializeJson<HttpUserResponse>(stringResponse);
                        totalPage = deserialiedResponse.total_pages;
                        pagenumber++;
                        result.AddRange(ReturnThreshingUsers(deserialiedResponse, threshold));
                    }
                }


            } while (pagenumber <= totalPage);

            return result;
        }

      

        private static IEnumerable<string> ReturnThreshingUsers(HttpUserResponse webresponse, int threshold)
        {
            if(webresponse != null)
            {
                var filteredResponse = webresponse.data.Where(x => x.submission_count > threshold).Select(x => x.username);
                return filteredResponse;
            }
            return null;
        }
        public static T DeserializeJson<T>(string Json)
        {
            return JsonSerializer.Deserialize<T>(Json);
        } 
        
        public static List<ApiResponse> DeserializeJson(string Json, List<ApiResponse> apiResponses)
        {
            return JsonSerializer.DeserializeToKeyValuePair(Json,apiResponses);
        }


        public async  static Task<List<string>> getUserNamesWebREsponse(int threshold)
        {
            var pagenumber = 1;
            var url = $"https://jsonmock.hackerrank.com/api/article_users?page={pagenumber}";
            WebRequest request = WebRequest.Create(url);  
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string str = reader.ReadLine();
            while (str != null)
            {
                Console.WriteLine(str);
                str = reader.ReadLine();
            }

            return null;
        }


        /// <summary>
        /// Strictly fitting the STD out and STD input pattern for the hackerank test
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            #region Practice LinkedList

            var llist = new LinkedListBase<int>(new Node<int>(16));

            llist.AddToEnd(13);
            llist.AddToEnd(7);
            // llist.AddToEnd(13);
            llist.AddToNthPosition(1, 2, llist.head);

            llist.Print();

            #endregion

           // var totoalGoals = getTotalGoals("Barcelona", 2011).Result;


            var resultUsersRemoveLater = getUserNameskeyValue(34).Result;

        //    var resultUsersCorrect = getUserNames(34).Result;

            #region Mean Median and Mode
            /* Note : Uncomment to test . Also note testing requires input from the console being 
             * Input of the array size eg 10. and the elements of the array all at once but separated by space.
             */
            //Console.Write("\n Enter the size of the series . NOTE The must be a valid numeric value ranging from 10 - 2500 ");
            // int arraysize = 0;
            // bool validateArraySize = false;

            // do
            // {
            //     var nstring = Console.ReadLine();
            //     validateArraySize = Int32.TryParse(nstring, out arraysize);


            // } while (validateArraySize == false || arraysize < 3 || arraysize > 2500);

            //var arraystring = Console.ReadLine();
            //var splitted = arraystring.Split(' ').ToArray();

            //int[] arr = Array.ConvertAll(splitted, s => int.Parse(s));
            // if (arr.Count() != arraysize)
            //     throw new ArgumentOutOfRangeException("The passed array size does not correspond to the number of elements in the array");



            // var stats = new MeanMedianMode();
            // var result = stats.ReturnStats(arraysize, arr);

            // Console.WriteLine(result.mean);
            // Console.WriteLine(result.median);
            // Console.WriteLine(result.mode);
            #endregion

            // Rotate a given sized matrix 
            // Test Case 1 4*4 Matrix
            #region Rotate Matrix
            int[,] a = { {1, 2, 3, 4},
                    {5, 6, 7, 8},
                    {9, 10, 11, 12},
                    {13, 14, 15, 16} };

             int R = 4;
             int C = 4;

            Matrix.rotatematrix(R, C, a);
            #endregion

            #region LinkedList
            var linkedList = new LinkedListBase<int>();
            linkedList.AddToEnd(2);
            linkedList.AddToEnd(3);
            linkedList.AddToEnd(1);
            linkedList.AddToEnd(4);
            linkedList.AddToEnd(6);
            linkedList.AddToEnd(0);
            linkedList.AddToEnd(12);
            linkedList.AddToBegining(23);
            linkedList.AddToBegining(25);
            linkedList.AddToBegining(35);
            linkedList.AddToBegining(35);

            linkedList.Print();
            #endregion

          //  Console.ReadLine();

            #region Recursive call Functions
            /* That is calculate the value of 5 raised to the power of 3 
             */
            Console.WriteLine("The value of the number n raised to the power p is => {0}",RecursionBase.power(5, 4));
            var strg = "HOT";
            Console.WriteLine("The reversed value of the string is => {0}",RecursionBase.ReverseAString(strg,strg.Length));
            #endregion

        }


    }

    public class User
    {
        public long Id { get; set; }
        public string  username { get; set; }
        public string about { get; set; }
        public int submitted { get; set; }
        public DateTime updated_at { get; set; }
        public int submission_count { get; set; }
        public int comment_count { get; set; }
        public dynamic Cceated_at { get; set; }

        public static List<ApiResponse> UserListFiedlValuePair()
        {
            List<ApiResponse> apiresponseStructure = new List<ApiResponse>{
                new ApiResponse { Key = "username" },
                new ApiResponse { Key = "about" }                                                                                                                                                                                    
            };

            return apiresponseStructure;
        }
    }

    

    public class HttpUserResponse
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public long total { get; set; }
        public int total_pages { get; set; }
        public List<User> data { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class SmsClient
    {
        public string id { get; set; }
        public int anqClientId { get; set; }
        public int anqUserId { get; set; }
        public string creatorId { get; set; }
        public string email { get; set; }
        public string fullname { get; set; }
        public int userChannelType { get; set; }
        public string systemId { get; set; }
        public string password { get; set; }
        public string defaultRouteName { get; set; }
        public string firstName { get; set; }
        public bool isTelco { get; set; }
        public string lastName { get; set; }
        public string username { get; set; }
        public string apiKey { get; set; }
        public int entityStatus { get; set; }
        public string dateCreated { get; set; }
        public string countryName { get; set; }
        public string countryCode { get; set; }
        public string addressLocation { get; set; }
        public bool isLocal { get; set; }
    }


}
