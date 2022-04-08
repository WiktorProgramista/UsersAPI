using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAPI.Application.Interfaces;
using UserAPI.Application.Models;

namespace UserAPI.Application.Implementations
{
    public class UserService : IUserService
    {
        private readonly IDbConnector DbConnector;

        public UserService(IDbConnector dbConnector)
        {
            DbConnector = dbConnector;
        }

        public void AddUser(User user)
        {
            var query = $"INSERT INTO tableinfo (UserName, EmailAddress, FirstName, SureName, BirthDate, NumberOfChilds) VALUES('{user.UserName}', '{user.EmailAddres}', '{user.FirstName}', '{user.SureName}', '{user.BirthDay}', '{user.NumberOfChilds}')";
            if (!DbConnector.OpenConnection())
            {
                throw new Exception("Nie mozna sie polaczyc");
            }
            var result = DbConnector.ExecuteQuery(query);
            DbConnector.CloseConnection();
        }

        public void Delete(int id)
        {
            var query = $"DELETE FROM users WHERE Id = '{id}'";
            if(DbConnector.OpenConnection()==false)
            {
                throw new Exception("Unable to opem connection");
            }
            var result = DbConnector.ExecuteQuery(query);
            DbConnector.CloseConnection();
        }

        public List<User> GetAll()
        {
            var query = "SELECT * FROM users";
            if (!DbConnector.OpenConnection())
            {
                throw new Exception("Nie mozna sie polaczyc");
            }
            var result = DbConnector.ExecuteQuery(query);
            DbConnector.CloseConnection();
            return null;
        }

        public User GetById(int id)
        {
            var query = $"SELECT * FROM users WHERE id='{id}'";
            if (!DbConnector.OpenConnection())
            {
                throw new Exception("Nie mozna sie polaczyc");
            }
            var result = DbConnector.ExecuteQuery(query);
            DbConnector.CloseConnection();
            return null;
        }

        public void Update(User user)
        {
            var query = $"UPDATE users SET UserName='{user.UserName}', EmailAddress='{user.EmailAddres}', FirstName='{user.FirstName}', Surname='{user.SureName}', BirthDate='{user.BirthDay}', NumberOfChilds='{user.NumberOfChilds}'";
            if (!DbConnector.OpenConnection())
            {
                throw new Exception("Nie mozna sie polaczyc");
            }
            var result = DbConnector.ExecuteQuery(query);
            DbConnector.CloseConnection();
        }
    }
}
