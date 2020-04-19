using StoreManagerUI.Models;
using System.Collections.Generic;

namespace StoreManagerUI.Helpers
{
    public interface IUserDBHelper
    {
        /// <summary>
        /// Creates new user and adds to database file
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="role">{admin, cashier, default}</param>
        void AddNewUser(string username, string password, RolesModel.UserRoles role);
        /// <summary>
        /// Checks if user exists in database and returns it's props
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        UserModel GetUser(string username, string password);
        List<UserModel> GetUsersList();
        string LoadConnectionString(string id = "Users");
        
        /// <summary>
        /// Modify role of user
        /// </summary>
        /// <param name="user"></param>
        //void ModifyRole(UserModel user);
        void ModifyRole(IUserModel user);
        void RemoveUser(IUserModel user);
    }
}