using System.Data;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using Lost_In_Woods.Models;
using Dapper;
using System.Linq;

namespace Lost_In_Woods
{
    public class UserFactory
    {
        private IOptions<MySqlOptions> _options;
        public UserFactory(IOptions<MySqlOptions> options)
        {
            _options = options;
        }
        internal IDbConnection Connection{
            get{
                return new MySqlConnection(_options.Value.ConnectionString);
            }
        }

        public List<Trail> GetAll()
        {
            using(IDbConnection db = Connection)
            {
                return db.Query<Trail>("SELECT * FROM trails").ToList();
            }
        }
        public void Add(Trail trail)
        {
            using(IDbConnection db = Connection)
            {
                string sql = @"INSERT INTO trails ( name, length, description, elevation) 
                                    VALUES( @name, @length, @description, @elevation)";
                db.Execute(sql,trail);
            }
        }
        public Trail GetTrailById(int id)
        {
            using(IDbConnection db = Connection)
            {
                return db.Query<Trail>("SELECT * FROM trails WHERE id = @id", new{id = id}).SingleOrDefault();
            }
        }
    }
    
}