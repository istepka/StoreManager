using StoreManagerUI.Helpers;
using StoreManagerUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Core.Validators
{
    public class UserValidator : IUserValidator
    {
        private IUserDBHelper _userDBHelper;
        public UserValidator(IUserDBHelper userDBHelper)
        {
            _userDBHelper = userDBHelper;
        }

        public bool ValidateUsername(string username)
        {
            if (username.Length < 3)
                return false;

            List<IUserModel> users = new List<IUserModel>(_userDBHelper.GetUsersList());
            foreach (var user in users)
            {
                if (username == user.Username)
                    return false;
            }

            return true;
        }

        public bool ValidatePassword(string password)
        {
            if (password.Length > 5)
                return true;
            else
                return false;
        }





    }
}
