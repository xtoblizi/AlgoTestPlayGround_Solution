using Dapper;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LoadSqlToMongoDb
{
    class Program
    {
        static bool loadFromOnecollectionToAnother = true;
        static string mongoColelectionPath1 = "mongodb://10.0.0.80:27017";
        static string mongoColelection1DatabaseName = "Coure_Delivery_Sms_Db";
        static string mongoColelection1CollectionName = "tblSenderIdRequestModel";
        
        static string mongoCollectionPath2 = "mongodb://10.0.0.80:27017";
        static string mongoCollection2DatabaseName = "Dnd_ContentProcesing_Coure";
        static string mongoCollection2CollectionName = "SenderIdRequest";

        #region Use this to load record from Sql to MongoDb
        static string mongopath = "mongodb://192.168.1.33:27017";
        static string sqlDbPath = "Data Source=192.168.1.85;Initial Catalog=Coure.Anq.ContentProcessDb;Persist Security Info=True;User ID=sa;Password=coure202*";
        #endregion

        async static Task Main(string[] args)
        {
            //var sqlLoad = new SqlLoad(sqlDbPath);
            //var contents = await sqlLoad.LoadSqlData();

            //var mongoload = new MongoLoad(mongopath);

            //foreach (var item in contents)
            //{
            //    await mongoload.InsertRecord<dynamic>("CurrentPortState", item);
            //}

            await loadFromCollectionToAnother();

            Console.WriteLine("Hello World!");
            var check = new PortData();
           
            Console.ReadLine();
        }

        /// <summary>
        /// This method would load from one database collection to another relating mongo collection of similar schema
        /// </summary>
        /// <returns></returns>
       async static Task loadFromCollectionToAnother()
       {
            if (loadFromOnecollectionToAnother == true)
            {
                var mongoPath1Load = new MongoLoad(mongoColelectionPath1,mongoColelection1DatabaseName);
                var mongoPath2Load = new MongoLoad(mongoCollectionPath2,mongoCollection2DatabaseName);

                var collection1 = await mongoPath1Load.LoadCollectionDocs<dynamic>(mongoColelection1CollectionName);

                foreach (var item in collection1)
                {
                    await mongoPath2Load.InsertRecord<dynamic>(mongoCollection2CollectionName, item);
                }
            }        
       } 

       
    }

    public class SqlLoad
    {
        private string conn = string.Empty;
        public SqlLoad(string connectionString)
        {
            conn = connectionString;
        }
        public async Task<List<PortData>> LoadSqlData(int skip = 0 , long take = 1000000)
        {
            string sql = "spGetAllCurrentPortStateSkipTake @skip, @take";
            List<PortData> portedNumbers = new List<PortData>();

            using (var connection = new SqlConnection(conn))
            {      
                portedNumbers = connection.Query<PortData>(sql, new { skip, take }).ToList();          
            }

            return await Task.FromResult(portedNumbers);

        }
    }

    public class MongoLoad
    {
        public IMongoDatabase db;
        public MongoLoad(string databasePath,string databaseName = null)
        {
            var client = new MongoClient(databasePath);
            databaseName = string.IsNullOrEmpty(databaseName) ? "CoureContentProcessDb" : databaseName;
            db = client.GetDatabase(databaseName);
        }
        public async Task<T> InsertRecord<T>(string tableName, T record)
        {
            try
            {
                var collection = db.GetCollection<T>(tableName);
                await collection.InsertOneAsync(record, new InsertOneOptions { BypassDocumentValidation = true });

                return await Task.FromResult(record);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public async Task<IEnumerable<T>> LoadCollectionDocs<T>(string tableName)
        {
            try
            {
                var collection = db.GetCollection<T>(tableName);
                var result = await collection.FindSync(new BsonDocument()).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }

    public class PortData
    {
        public Guid MyProperty { get; set; }
        public long Id { get; set; }
        public string Number { get; set; }

        public DateTime DatePorted { get; set; }
        public int EntityStatus { get; set; }

        public string Locale { get; set; }
    }
}
