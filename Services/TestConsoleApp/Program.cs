using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using NCrontab;
using Quartz;
using Xtoblizi.HackerRank.Statistics;

namespace TestConsoleApp
{
    public class Table { public int Id { get; set; } public string GroupName { get; set; } public string Name { get; set; } public DateTime ExpirationTime { get; set; }}
    
    public class Test
	{
        int ReturnLowestPossibleNumber(int[] A)
		{
            HashSet<int> sortedArray = new HashSet<int>(A);
           
			for (int i = 1; i <= A.Length; i++)
			{
                if ( sortedArray.Contains(i))
                    return i;
			}

            return sortedArray.Count + 1;
		}
	}
    class Program
    {
        static int length (string str)
        {
            if (str == null || str == "")
                return 0;
            else
            {
                var k = str;
                Console.WriteLine(k);
                return length(str.Substring(1))+2;
            }               
        }
        /// <summary>
        /// return the value of xEy i.e the exponential value of x raised to power of y
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        static long pow(int x, int y)
        {
            // base case: when y is of value 1

            if (y == 0)
                return 1;
            else
            {
                return x * (pow(x, y - 1));
            }

        }
        /// <summary>
        /// function to find the highest common divisor. using Euclids principle
        /// divide the greatest by the smallest and get the reminder
        /// </summary>
        /// <param name="h"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        static long HCD(long h, long l)
        {
            if (l == 0)
                return h;

            var k = h % l;
            return HCD(l, k);
        }

        static void Main(string[] args)
        {
            Console.WriteLine($"This is the lenth of the string ==> {length("Kettle")}");
            int x = 4, y = 3; 
            Console.WriteLine($"The exponential value of x:{x} raised to power of y: {y} is {pow(x, y)} \n");
            long h = 180, l = 150;
            Console.WriteLine($"Following Euclucid Mathematical principle : HCF of the two number h: {h} and l: {l} is ===> {HCD(h, l)} ");

            #region Practice LinkedList

            //LinkedListBase llist = new LinkedListBase(new Node(16));

            //llist.AddToEnd(13);
            //llist.AddToEnd(7);
            //// llist.AddToEnd(13);

            //llist.Print();

            #endregion


            Console.WriteLine("Testing Grouping");
            //var cronstring = "00 23 16 * ? ?";
            var cronstring2 = "0 30 10 ? * MON,TUE,WED,THU,FRI,SUN * ";
            var startDate = DateTime.Now;
            var endDate = startDate.AddYears(1);

            var nextOccurence = ReturnNextOccurrenceDate(cronstring2,startDate ,endDate);
            // TestDeliveryProgramticallyToEmailWebServers();

            TestGrouping();

            Console.WriteLine("Hello World!");
            int[] A = { -1, 1, 4,3,2,6 };
            var result = ReturnSmallestMissingNumberOfAnArray(A);
            Console.WriteLine("The result is {0}", result);

            int k =529;
            var binarygap = ReturnGreatestBinaryGapOfAPositiveNumber(k);
            Console.WriteLine("The greatest binary gap of the integer is => {0}", binarygap);

            var s = "{[()()]}";
            Console.WriteLine("Note : 1 means correct while 0 means incorrect." +
               "The format of the nestable string is {0}", ReturnCorrectnessOfStringBasedOnFormat(s));

            int[] arrayfornondivisor = { 3, 1, 2, 3, 6 };
            var nondivisorsamounts = ReturnNondivisorsArrayAmounts(arrayfornondivisor);
            Console.WriteLine("The result for the amounts of non divisor elements of the array elements is {0}", nondivisorsamounts.ToString());

        }

        /// <summary>
        /// Understanding how to generate the 
        /// </summary>
        /// <param name="crondetailsstring"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static DateTime? ReturnNextOccurrenceDate(string crondetailsstring, DateTime startDate, DateTime endDate)
        {
            try
            {
                if (!string.IsNullOrEmpty(crondetailsstring))
                {
                    //var crontabCheck = CrontabSchedule.Parse(crondetailsstring);
                    //var nextDueTime = crontabCheck.GetNextOccurrence(startDate, endDate);
                    //var occurrences = crontabCheck.GetNextOccurrences(startDate, endDate);

                    CronExpression exp = new Quartz.CronExpression(crondetailsstring);
                    var nextFire = exp.GetNextValidTimeAfter(DateTime.Now);
                    //var quartzoccurrences = crontabCheck.GetNextOccurrences(startDate, endDate);

                    //Console.WriteLine(string.Join(Environment.NewLine, from t in quartzoccurrences
                    //    select $"{t:ddd, dd MMM yyyy HH:mm}"));

                  //  return nextDueTime;
                    return nextFire?.UtcDateTime;
                }
                else
                {
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void TestGrouping()
        {
            var tables2 = new List<Table>();
            var tables = new List<Table>(){
            new Table{Id= 1, Name = "Brown Table" , GroupName = "DinnerTable", ExpirationTime = DateTime.Now.AddDays(3)},
                new Table{Id= 1, Name = "Maroon Table" , GroupName = "Old Table", ExpirationTime = DateTime.Now.AddDays(1)},
                new Table {Id = 2 , Name = "White Table" , GroupName = "CenterTable",ExpirationTime = DateTime.Now.AddDays(2)},
                new Table{Id = 3,Name = "Reading Table", GroupName = "DinnerTable",ExpirationTime = DateTime.Now.AddDays(-1)},
                new Table{Id = 3,Name = "Sex Table", GroupName = "FlatTable",ExpirationTime = DateTime.Now.AddDays(8)},
                new Table{Id = 3,Name = "Sleep Table", GroupName = "smooth",ExpirationTime = DateTime.Now.AddDays(9)}
            };

            var results = from p in tables
                          group p by p.GroupName into g
                          select new { TableGroupName = g.Key, PriceConfigs = g.ToList() };

            var sortbychildren = results.Where(x => x.PriceConfigs.Count() > 1);
            tables2 = sortbychildren.FirstOrDefault()?.PriceConfigs;

            var tableMade = tables.Where(x => x.ExpirationTime >= DateTime.Now.AddDays(-2) && x.ExpirationTime <= DateTime.Now.AddDays(2));

            foreach (var item in tables2)
            {
                Console.WriteLine($"Table Name : {item.Name} , ExpirationDate : {item.ExpirationTime}");
            }

            foreach (var item in results)
            {
                Console.WriteLine(item.TableGroupName);
                foreach (var itemm in item?.PriceConfigs)
                {
                    Console.WriteLine("Table Name : {0} , Group Name {1}", itemm.Name, itemm.GroupName);
                }
            }

        }

        public static void TestDeliveryProgramticallyToEmailWebServers()
        {
            try
            {
                // Tested it works anyway.
                var email = new EmailTest()
                {
                    AttachmentFilesPath = null,
                    host = "smtp.gmail.com",
                    port = 587,
                    IsSSL = true,
                    Password = "password",
                    Sender = "sender email",
                    Username = "ogbosukachris@gmail.com",
                    SenderPass = "password",
                    Receipients = new List<string>() { "ogbosukachrisbiz@gmail.com" },
                    Subject = "This is test message from Visual Studio",
                };
                email.Body = @"<!DOCTYPE HTML>
                            <html>
                            <head>
                            <title>Title of the document</title>
                            </head> 
                            <body> <h2> This is test message from my App </h1><br/><br/><p>  This is working now thannks and happy sunday </p> </body>";


                EmailTest.SendMailViaDonetSmtp(email);

                // Try alternative means
                email.SendViaMailKit(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int ReturnSmallestMissingNumberOfAnArray(int[] arr)
        {
            Array.Sort(arr);
            var length = arr.Length;
            var smallestpositive = 1;
            for (int i = 0; i <= length - 1; i++)
            {
                if (smallestpositive < arr[i])
                    return smallestpositive;
                else
                {
                    if(arr[i] == Math.Abs(arr[i]))
                    {
                        smallestpositive = arr[i]+1;
                    }
                  
                }
            }
            return smallestpositive;
        }

        public static int ReturnGreatestBinaryGapOfAPositiveNumber(int num)
        {
            // get the binary value of a number
            string binary = Convert.ToString(num, 2);
            var splittedbinary = binary.Split('1');
            if(splittedbinary.Length > 1)
            {
                var newbinaryarray = splittedbinary.Take(splittedbinary.Length - 1).ToArray();
                var y = newbinaryarray.Max();
                if (y.Length > 0)
                    return y.Length;
            }

            return 0;
        }
        /// <summary>
        /// If the string is in the format "{[()()]}" : return true
        /// Else if string is in the format so other format not as above eg "([)()]": return false.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int ReturnCorrectnessOfStringBasedOnFormat(string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                var sarray = s.ToArray();
                
                Stack<char> myStack = new Stack<char>();

                if (s == string.Empty)
                    return 1;

                var sarraylength = sarray.Length;

                // if the character are not even then the format is not correct
                if (sarraylength % 2 > 0)
                    return 0;

                var midelementindex = sarraylength / 2 - 1;

                for (int i = 0; i < sarray.Length -1; i++)
                {
                    var c = sarray[i];
                    if (c == '{' || c == '(' || c == '[')
                    { 
                        // place the strings characters into a stack
                        myStack.Push(c);
                    }
                    else
                    {
                        // then its  closing braces
                        if ((i == sarray.Length - 1 && myStack.Count != 1) || (myStack.Count == 0))
                        {
                            return 0;
                        }
                        switch (c)
                        {
                            case '}':
                                if (myStack.Pop() != '{')
                                    return 0;
                                break;

                            case ')':
                                if (myStack.Pop() != '(')
                                    return 0;
                                break;

                            case ']':
                                if (myStack.Pop() != '[')
                                    return 0;
                                break;

                            default:
                                break;
                        }
                    }                 
                }
            }
            else if(s == string.Empty) { return 1; }
            else { return 0; }

            return 1;
        }

        private static int[] ReturnNondivisorsArrayAmounts(int[] arr)
        {
            int[] divisorarrtemp = new int[arr.Length];

            for (int i = 0; i <= arr.Length-1; i++)
            {
                for (int k = 0; k <= arr.Length-1; k++)
                {

                    if(k != i)
                    {
                        var parent = arr[i];
                        var child = arr[k];
                        if (parent % child != 0)
                            divisorarrtemp[i] += 1;
                    }
                }
            }

            return divisorarrtemp;
        }

        public static void preprocess(int[] p, int[] x,
                                    int[] y, int n)
        {
            for (int i = 0; i < n; i++)
                p[i] = x[i] * x[i] + y[i] * y[i];

            Array.Sort(p);
        }

        public static int query(int[] p, int n, int rad)
        {
            int init = 0, stop = n - 1;
            while ((stop - init) > 1)
            {
                int mid = (init + stop) / 2;
                double tp = Math.Sqrt(p[mid]);

                if (tp > (rad * 1.0))
                    stop = mid - 1;
                else
                    init = mid;
            }

            //for (int i = 0; i < (stop-init); i++)
            //{

            //}

            double tp1 = Math.Sqrt(p[init]);
            double tp2 = Math.Sqrt(p[stop]);

            if (tp1 > (rad * 1.0))
                return 0;
            else if (tp2 <= (rad * 1.0))
                return stop + 1;
            else
                return init + 1;
        }
    }
}
