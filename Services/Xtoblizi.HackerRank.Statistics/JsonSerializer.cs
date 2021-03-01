using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Xtoblizi.HackerRank.Statistics
{
    public class ApiResponse
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
    public class JsonSerializer
    {
        /// <summary>
        /// This would deseriablize json string into an ienumerable of keyvalue pairs (field and value) each.
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public static List<ApiResponse> DeserializeToKeyValuePair(string body,List<ApiResponse> expectedResultFields)
        {
            JObject result = JsonConvert.DeserializeObject<JObject>(body);
            List<ApiResponse> response = new List<ApiResponse>(); 

            foreach (var item in expectedResultFields)
            {
                Newtonsoft.Json.Linq.JObject  jsonObject = JObject.Parse(body);
              
                // var exist = jsonObject[0].Children<JProperty>().Any(p=>p.Name=="data");
                //string json = (dynamic)jsonObject;
                //string username = (string)jsonObject["data"][0][$"{item.Key}"];
                //if (exist)
                //{
                //    var val = jsonObject[0].Value<string>(item.Key);
                //}



                var content = "username";
                string[] splittedcontent = content.Split(':');
                string resultvalue = string.Empty;

                if(splittedcontent != null)
                {
                    //for (int i = 0; i < splittedcontent.Length; i++)
                    //{                       
                    //    resultvalue = resultantJObject != null ? resultantJObject.ToString() : null;
                    //}

                }

                var resultLinq = result.SelectToken("data");
                var inner = resultLinq.SelectToken("username");
                var query = resultLinq.FirstOrDefault(x => x.Contains("data"));

                var value1 = result.SelectToken("data").SelectToken("usern");
                //response.Add(new ApiResponse
                //{
                //    Key = item.Key,
                //    Value = value.ToString()
                //});
            }

            return response;
        }

        /// <summary>
        /// Deserialize an from json string
        /// </summary>
        public static T  Deserialize<T>(string body)
        {
            try
            {
                using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(body)))
                {
                    stream.Position = 0;
                    var dataContract = new DataContractJsonSerializer(typeof(T));
                    var result = (T)dataContract.ReadObject(stream);
                    stream.Close();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static T jsDeserialize<T>(string jsStr)
        {
            DataContractJsonSerializer serJs = new DataContractJsonSerializer(typeof(T));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsStr));
            T obj = (T)serJs.ReadObject(stream);
            stream.Close();
            return obj;
        }

        /// <summary>
        /// Serialize an object to json
        /// </summary>
        public static string Serialize<T>(T item)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                new DataContractJsonSerializer(typeof(T)).WriteObject(ms, item);

                return Encoding.Default.GetString(ms.ToArray());
            }
        }
    }

    public class Book
    {
        public string Name { get; set; }
        public List<Book> Related { get; set; }
    }
}
