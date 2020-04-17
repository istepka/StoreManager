using StoreManagerUI.Models;

namespace StoreManagerUI.Helpers
{
    public interface IUserDBHelper
    {
        void AddNewUser(string username, string password, string role = "default");
        UserModel GetUser(string username, string password);
        string LoadConnectionString(string id = "Users");
    }
}