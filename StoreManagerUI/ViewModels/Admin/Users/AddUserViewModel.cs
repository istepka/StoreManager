using Caliburn.Micro;
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


        public AddUserViewModel(IUserDBHelper  userDBHelper)
        {
            _userDBHelper = userDBHelper;
        }




        public List<RolesModel.UserRoles> RolesList { get; set; } = Enum.GetValues(typeof(RolesModel.UserRoles)).Cast<RolesModel.UserRoles>().ToList();

       

        public RolesModel.UserRoles SelectedRole
        {
            get { return _selectedRole; }
            set { _selectedRole = value;
                NotifyOfPropertyChange(()=>SelectedRole);
                NotifyOfPropertyChange(()=>CanAddUser);
            }
        }
        private string _username;

        public string Username
        {
            get { return _username; }
            set { _username = value;
                NotifyOfPropertyChange(() => Username);
                NotifyOfPropertyChange(() => CanAddUser);
            }
        }
        private string _password;

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
                if (Password?.Length > 0 && Username?.Length > 0)
                    return true;
                else
                    return false;
            }
        }

        public void AddUser()
        {
            _userDBHelper.AddNewUser(Username, Password, SelectedRole);
        }






    }
}
