using System.Collections.Generic;
using System.Data;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using dojo_league.Models;
using Dapper;
using System.Linq;

namespace dojo_league
{
    public class UserFactory
    {
        private IOptions<MySqlOptions> _options;
        public UserFactory(IOptions<MySqlOptions> options)
        {
            _options = options;
        }
        internal  IDbConnection Connection {
            get {
                return new MySqlConnection(_options.Value.ConnectionString);
            }
        }
        public List<Ninja> GetNinjas()
        {
            using(IDbConnection dbConnection = Connection)
            {
                string sql = @"SELECT n.name, n.id AS ninja_id, n.description,n.dojo_id,d.id ,d.name FROM ninjas AS n 
                            LEFT JOIN dojos AS d ON n.dojo_id = d.id";
                return dbConnection.Query<Ninja,Dojo,Ninja>(sql,(ninja,dojo) => {
                    ninja.dojo = dojo;
                    return ninja;
                },splitOn:"dojo_id").ToList();
            }
        }

        public void AddNinja(Ninja ninja)
        {
            using(IDbConnection dbConnection = Connection)
            {
                string sql = @"INSERT INTO  ninjas (name,level,dojo_id,description) VALUES (@name,@level,@dojo_id,@description)";
                dbConnection.Execute(sql,ninja);
            }
            
        }
        public List<Dojo> GetDojos()
        {
            using(IDbConnection dbConnection = Connection)
            {
                string sql = @"SELECT d.id AS dojo_id, d.name FROM dojos AS d";
                return dbConnection.Query<Dojo>(sql).ToList();
            }
        }
        public void AddDojo(Dojo dojo)
        {
            using(IDbConnection dbConnection = Connection)
            {
                string sql=@"INSERT INTO dojos (name,location,info) VALUES (@name,@location,@info)";
                dbConnection.Execute(sql,dojo);
            }
            
        }
        public Ninja GetNinja(int id)
        {
            using(IDbConnection dbConnection = Connection){
                string sql = $@"SELECT n.id As ninja_id, n.name,n.level,n.description,d.id AS dojo_id FROM ninjas AS n
                        LEFT JOIN dojos AS d ON n.dojo_id = d.id
                        WHERE n.id = {id}";
                return dbConnection.Query<Ninja,Dojo,Ninja>(sql,(ninja,dojo)=>
                {
                    ninja.dojo = dojo;
                    return ninja;
                },splitOn:"dojo_id").SingleOrDefault();
            }
        }
        public Dojo GetDojo(int id)
        {
            using(IDbConnection dbConnection = Connection)
            {
                string sql = $@"SELECT d.id AS dojo_id, d.name, d.location, d.info, n.id AS ninja_id, n.name,n.level,n.dojo_id FROM dojos AS d
                                right JOIN ninjas AS n ON d.id = n.dojo_id
                                WHERE d.id = {id}";
                return dbConnection.Query<Dojo,Ninja,Dojo>(sql,(dojo,ninja)=>
                {
                    dojo.ninjas.Add(ninja);
                    return dojo;
                },splitOn:"ninja_id").SingleOrDefault();
            }
        }

    }
}