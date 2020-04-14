using Dapper;
using StoreManagerUI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagerUI.Helpers
{
    public class UserDBHelper
    {
        public UserModel GetUser(string username, string password)
        {
            UserModel loggedUser = new UserModel();

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<UserModel>($"SELECT * FROM Users WHERE EXISTS(SELECT 1 FROM Users WHERE Username = @username)", new { username}).ToList();
                //output = output.ToList();
                foreach (var user in output)
                {
                    if (username == user.Username && password == user.Password)
                    {
                        loggedUser = user;
                    }
                }

            }
                return loggedUser;
        }

        public void AddNewUser()
        {

        }

        public string LoadConnectionString(string id = "Users")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }


    }
}
