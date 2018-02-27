using MySql.Data.MySqlClient;
using Microsoft.Extensions.Options;
using System.Data;
using System.Collections.Generic;
using connection_string.Models;
using Dapper;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace connection_string
{
    public class UserFactory
    {
        private IOptions<MySqlOptions> _options;
        public UserFactory (IOptions<MySqlOptions> options)
        {
            _options = options;
        }
        internal  IDbConnection Connection {
            get {
                return new MySqlConnection(_options.Value.ConnectionString);
            }
        }
        // ///////////////////////////////////////////////////////////////////////
        // WHY NOT USE :
        //              private DbConnector _dbConnector;
        //              public UserFactory(DbConnector dbConnector)
        //              {
        //                  _dbConnector = dbConnector;
        //  
        //            }
        // //////////////////////////////////////////////////////////////////////////
        public List<User> GetUsers()
        {
            using(IDbConnection dbConnection = Connection) // once I exit this GetUsers function, the instance dbConnection would be wiped out!!!!
            {
                return dbConnection.Query<User>("SELECT * FROM users").ToList();
            }
            
        }
        public User GetUserById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                return dbConnection.Query<User>("SELECT * FROM users WHERE id = @id", new{id=id}).SingleOrDefault();
            }
        }

        public void CreateUser(User user)
        {
            using(IDbConnection dbConnection = Connection)
            {
                PasswordHasher<User> hasher = new PasswordHasher<User>();
                user.password = hasher.HashPassword(user,user.password);
                string sql = @"
                    INSERT INTO users (first_name, last_name, email, password, created_at)
                    VALUES (@first_name, @last_name, @email, @password, NOW() ); 
                ";
                dbConnection.Execute(sql,user);
            }
        }

        public bool EmailIfExist(User user)
        {
            using(IDbConnection dbConnection = Connection)
            {
                return dbConnection.Query<User>("SELECT id FROM users WHERE email = @email", new{email = user.email}).SingleOrDefault() == null;            
            }
        }
    }
}