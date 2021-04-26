using System;
using System.Collections.Generic;
using System.Linq;

namespace TimeZoneAndLocalTimePractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            TimeStudyWithKind();
            TimeStudy1();

            Console.ReadLine();

            List<DateTime> LocalDateList = new List<DateTime>();
            for (int i = 0; i < 5; i++)
            {
                var minute = (double)10 * i;
               

                if(i % 2 == 0)
                {
                    LocalDateList.Add(DateTime.UtcNow.AddMinutes(minute));
                }else
                {
                    minute =(double) minute / i;
                    LocalDateList.Add(DateTime.UtcNow.AddMinutes(minute));
                }
            }
            
            List<DateTime> LocalDateList2 = new List<DateTime>();
            for (int i = 0; i < 5; i++)
            {
                var minute = (double)10 * i;
               

                if(i % 2 == 0)
                {
                    LocalDateList2.Add(DateTime.UtcNow.AddMinutes(minute));
                }else
                {
                    minute =(double) minute / i;
                    LocalDateList2.Add(DateTime.UtcNow.AddMinutes(minute));
                }
            }


            var now = DateTime.Now.ToLocalTime() ;
            DateTime startDate = now.AddSeconds(-5);
            DateTime endDate = now.AddMinutes(12);

            // get all date from current time to about 2 minute ahead
            var result = LocalDateList.Where(x => x >= startDate && x <= endDate);
            var result2 = LocalDateList2.Where(x => x >= startDate && x <= endDate);

            foreach (var item in result)
            {
                Console.WriteLine(item.ToString());
            }
            
            foreach (var item in result2)
            {
                Console.WriteLine(item.ToString());
            }


            Console.ReadLine();
        }

        static void TimeStudy1()
        {
            DateTime localDatelTime, universalDateTime;
            Console.WriteLine("Enter a date and time");
            string strDateTime = Console.ReadLine();

            try
            {
                localDatelTime = DateTime.Parse(strDateTime);
                universalDateTime = localDatelTime.ToUniversalTime();

                Console.WriteLine("Case 1");
                Console.WriteLine("This is the localtime = {0} \n This is the universal time {1}", localDatelTime, universalDateTime);

            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid date time format");
                throw;
            }

            Console.WriteLine("Enter a date time in universal format");
            strDateTime = Console.ReadLine();

            try
            {
                universalDateTime = DateTime.Parse(strDateTime);
                localDatelTime = universalDateTime.ToLocalTime();


                Console.WriteLine("Case 2");
                Console.WriteLine("This is the localtime = {0} \n This is the universal time {1}", localDatelTime, universalDateTime);
            }
            catch (FormatException)
            {

                throw;
            }
        }

        static void TimeStudyWithKind()
        {
            DateTime saveNow = DateTime.Now;

            DateTime saveUtcNow = DateTime.UtcNow;
            DateTime myDt;

            Console.WriteLine("Saved DateTime.Now => {0} ............ while Saved DateTime.UtcNow => {1}", saveNow, saveUtcNow);

            myDt = DateTime.SpecifyKind(saveNow, DateTimeKind.Utc);
            Console.WriteLine("The real utc by kind => {0}", myDt);

            myDt = DateTime.SpecifyKind(saveNow, DateTimeKind.Local);
            Console.WriteLine("THiis is the local time => {0}", myDt);
        }
    }
}
