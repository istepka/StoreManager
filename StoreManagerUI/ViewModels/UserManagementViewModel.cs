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
    public class UserManagementViewModel : Screen
    {
        private IUserDBHelper _userDBHelper;
        private IUserModel _selectedUser;
        private BindableCollection<IUserModel> _usersList;
        private Roles.UserRoles _selectedRole;

        public UserManagementViewModel(IUserDBHelper userDBHelper)
        {
            _userDBHelper = userDBHelper;
           


        }


        

        public IUserModel SelectedUser
        {
            get { return _selectedUser; }
            set { _selectedUser = value;  }
        }

      

        public BindableCollection<IUserModel> UsersList
        {
            get { return _usersList; }
            set { _usersList = value; }
        }
       
        public Roles.UserRoles SelectedRole
        {
            get { return _selectedRole; }
            set
            {
                _selectedRole = value;
                NotifyOfPropertyChange(() => SelectedRole);
            }
        }

        public List<Roles.UserRoles> Roles { get; set; } = Enum.GetValues(typeof(Roles.UserRoles)).Cast<Roles.UserRoles>().ToList();


        public void ApplyChanges()
        {

        }




    }
}
