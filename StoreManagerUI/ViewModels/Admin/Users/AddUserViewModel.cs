using Caliburn.Micro;
using StoreManager.Core.Validators;
using StoreManagerUI.Helpers;
using StoreManagerUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagerUI.ViewModels
{
    public class AddUserViewModel : Screen
    {
        private IUserDBHelper _userDBHelper;
        private RolesModel.UserRoles _selectedRole;
        public event EventHandler<bool> CloseAddUserTab;
        private IUserValidator _userValidator;
        private string _password;
        private string _username;
        public AddUserViewModel(IUserDBHelper  userDBHelper, IUserValidator userValidator)
        {
            _userDBHelper = userDBHelper;
            _userValidator = userValidator;
        }


        public string AddError { get; set; } = "";

        public List<RolesModel.UserRoles> RolesList { get; set; } = Enum.GetValues(typeof(RolesModel.UserRoles)).Cast<RolesModel.UserRoles>().ToList();

        public RolesModel.UserRoles SelectedRole
        {
            get { return _selectedRole; }
            set { _selectedRole = value;
                NotifyOfPropertyChange(()=>SelectedRole);
                NotifyOfPropertyChange(()=>CanAddUser);
            }
        }
     
        public string Username
        {
            get { return _username; }
            set { _username = value;
                NotifyOfPropertyChange(() => Username);
                NotifyOfPropertyChange(() => CanAddUser);
            }
        }
  
        public string Password
        {
            get { return _password; }
            set { _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanAddUser);
            }
        }




        public bool CanAddUser
        {
            get
            {
                if (Password?.Length > 0 && Username?.Length > 0 && SelectedRole.ToString() != null)
                    return true;
                else
                    return false;
            }
        }




        public void AddUser()
        {
            if (ValidateUser(Username, Password) == true)
            {
                _userDBHelper.AddNewUser(Username, Password, SelectedRole);
                Username = "";
                Password = "";
                SelectedRole = default;
                AddError = "User added";
                NotifyOfPropertyChange(() => AddError);
            }
        }

        public bool ValidateUser(string username, string password)
        {
            if (_userValidator.ValidatePassword(password) == false)
            {
                AddError = "Password length\nshould have\nminimum 6 letters";
                NotifyOfPropertyChange(() => AddError);
                return false;
            }
            if (_userValidator.ValidateUsername(username) == false)
            {
                AddError = "Username taken or\ntoo short\n(min 3 letters)";
                NotifyOfPropertyChange(() => AddError);
                return false;
            }
            else
                return true;


        }

        public void Close()
        {
            CloseAddUserTab.Invoke(null, true);
        }


    }
}
