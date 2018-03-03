using System.Collections.Generic;
using System.Data;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;

namespace Bank
{
    public class DbConnector
    {
        
        private IOptions<MySqlOptions> _options;
        public DbConnector(IOptions<MySqlOptions> options)
        {
            _options = options;
        }
        internal  IDbConnection Connection {
            get {
                return new MySqlConnection(_options.Value.connectionstring);
            }
        }

        //This method runs a query and stores the response in a list of dictionary records
        public  List<Dictionary<string, object>> Query(string queryString) //not static any more, it could be a connection objects
        {
            using(IDbConnection dbConnection = Connection)
            {
                using(IDbCommand command = dbConnection.CreateCommand())
                {
                   command.CommandText = queryString;
                   dbConnection.Open();
                   var result = new List<Dictionary<string, object>>();
                   using(IDataReader rdr = command.ExecuteReader())
                   {
                      while(rdr.Read())
                      {
                          var dict = new Dictionary<string, object>();
                          for( int i = 0; i < rdr.FieldCount; i++ ) {
                              dict.Add(rdr.GetName(i), rdr.GetValue(i));
                          }
                          result.Add(dict);
                      }
                      return result;
                                      }
                }
            }
        }
        //This method run a query and returns no values
        public  void Execute(string queryString) //not static any more, it could be a connection objects
        {
            using (IDbConnection dbConnection = Connection)
            {
                using(IDbCommand command = dbConnection.CreateCommand())
                {
                    command.CommandText = queryString;
                    dbConnection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}