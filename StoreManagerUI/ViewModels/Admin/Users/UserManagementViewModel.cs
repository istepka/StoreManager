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
    public class UserManagementViewModel : Conductor<object>
    {
        private IUserDBHelper _userDBHelper;
        private IUserModel _selectedUser;
        private BindableCollection<IUserModel> _usersList;
        private BindableCollection<IUserModel> _usersListFiltered;
        private RolesModel.UserRoles _selectedRole;
        private IUserValidator _userValidator;
        private string _searchedUser;

        public UserManagementViewModel(IUserDBHelper userDBHelper, IUserValidator userValidator)
        {
            _userDBHelper = userDBHelper;
            _userValidator = userValidator;
            UsersList = new BindableCollection<IUserModel>(_userDBHelper.GetUsersList());

        }


        

        public IUserModel SelectedUser
        {
            get { return _selectedUser; }
            set { _selectedUser = value; 
                NotifyOfPropertyChange(()=>SelectedUser); 
                NotifyOfPropertyChange(()=>CanRemoveSelectedUser); 
                NotifyOfPropertyChange(()=>CanApplyChanges); 
            }
        }

      

        public BindableCollection<IUserModel> UsersList
        {
            get 
            {
                if (SearchedUser != null)
                    return FilteredList();
                else
                    return _usersList;       
            }
            set 
            {          
                _usersList = value;
                NotifyOfPropertyChange(() => UsersList);
            }
        }
       
        public RolesModel.UserRoles SelectedRole
        {
            get { return _selectedRole; }
            set
            {
                _selectedRole = value;
                NotifyOfPropertyChange(() => SelectedRole);
                NotifyOfPropertyChange(() => CanApplyChanges);
            }
        }

        public List<RolesModel.UserRoles> Roles { get; set; } = Enum.GetValues(typeof(RolesModel.UserRoles)).Cast<RolesModel.UserRoles>().ToList();


       

        public string SearchedUser
        {
            get { return _searchedUser; }
            set { _searchedUser = value; 
                NotifyOfPropertyChange(()=> SearchedUser);
                NotifyOfPropertyChange(()=> UsersList);

            
                          
            }
        }


        public BindableCollection<IUserModel> FilteredList()
        {
            var list =  new BindableCollection<IUserModel>(_usersList.Where(x => x.Username.Contains(SearchedUser)).ToList());


            return list;
        }





        public bool CanApplyChanges
        {
            get
            {
                if (SelectedUser?.Role != SelectedRole.ToString())
                {
                    if (SelectedUser?.Role != null)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
        }

        public void ApplyChanges()
        {
            SelectedUser.Role = SelectedRole.ToString();
            IUserModel userModel = SelectedUser;   
            
            _userDBHelper.ModifyRole(userModel);
            RefreshList();
        }

        private AddUserViewModel _addUserVM;
         public void AddNewUser()
        {
            _addUserVM = new AddUserViewModel(_userDBHelper, _userValidator);
            ActivateItem(_addUserVM);
            _addUserVM.CloseAddUserTab += AddUserVM_CloseAddUserTab;
        }

        private void AddUserVM_CloseAddUserTab(object sender, bool e)
        {
            if (e == true)
                DeactivateItem(_addUserVM, true);
            RefreshList();
                
        }



        public bool CanRemoveSelectedUser
        {
            get
            {
                if (SelectedUser != null)
                    return true;
                else
                    return false;
            }
        }

        public void RemoveSelectedUser()
        {
            _userDBHelper.RemoveUser(SelectedUser);
            RefreshList();
        }








        public void RefreshList()
        {
            UsersList = new BindableCollection<IUserModel>(_userDBHelper.GetUsersList());
            NotifyOfPropertyChange(() => UsersList);
        }

    }
}
