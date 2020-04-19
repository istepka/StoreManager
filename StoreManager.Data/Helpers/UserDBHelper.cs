using Dapper;
using StoreManagerUI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagerUI.Helpers
{
    public class UserDBHelper : IUserDBHelper
    {
        public UserModel GetUser(string username, string password)
        {
            UserModel loggedUser = new UserModel();

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<UserModel>($"SELECT * FROM Users WHERE EXISTS(SELECT 1 FROM Users WHERE Username = @username)", new { username }).ToList();
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

        public void AddNewUser(string username, string password, RolesModel.UserRoles role = RolesModel.UserRoles.random)
        {
            UserModel user = new UserModel() { Password = password, Role = role.ToString(), Username = username };
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute($"INSERT INTO Users (Username, Password, Role) values (@Username, @Password, @Role)", user);
                
            }
        }

        public void ModifyRole(IUserModel user)
        {
            using(IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute($"UPDATE Users SET Role = @Role WHERE Id = @Id", user);
            }
        }


        public List<UserModel> GetUsersList()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<UserModel>("select * from Users", new DynamicParameters());
                System.Diagnostics.Debug.WriteLine("DataLoadedSuccesfully");
                return output.ToList();
            }
        }

        public void RemoveUser(IUserModel user)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute($"DELETE FROM Users WHERE Id = {user.Id}");
            }
        }

        public string LoadConnectionString(string id = "Users")
        {
            string cnn = ConfigurationManager.ConnectionStrings[id].ConnectionString;
            string path = Directory.GetCurrentDirectory();
            int i = path.IndexOf("StoreManagerUI");
            path = path.Substring(0, path.Length - (path.Length - i)) + "StoreManager.Data\\";

            string fixedConnectionString = cnn.Replace("{AppDir}", path);
            return fixedConnectionString;
        }


    }
}
