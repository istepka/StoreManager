using Caliburn.Micro;
using StoreManager.Core.Models;
using StoreManager.Core.Validators;
using StoreManagerUI.Events;
using StoreManagerUI.Helpers;
using StoreManagerUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagerUI.ViewModels
{
    public class ShellViewModel : Conductor<object>.Collection.OneActive
    {
        private DashboardAdminViewModel _dashboardVM;
        private CashierViewModel _cashierVM;
        private LoginViewModel _loginVM;
        private BlankScreenViewModel _blankVM;
        IUserDBHelper _userDBHelper;
        IUserValidator _userValidator;
        private UserModel _activeLoggedUser;



       

        public ShellViewModel(DashboardAdminViewModel dashboardVM, CashierViewModel cashierVM, LoginViewModel loginVM, BlankScreenViewModel blankVM,
            IUserDBHelper userDBHelper, IUserValidator userValidator)
        {
            _dashboardVM = dashboardVM;
            _cashierVM = cashierVM;
            _loginVM = loginVM;
            _blankVM = blankVM;
            _userDBHelper = userDBHelper;
            _userValidator = userValidator;
            ActivateItem(_loginVM);
            ActiveLoggedUser = new UserModel() { Username = "No user"};
            _loginVM.LogInEvent += _loginVM_LogInEvent;

       
        }

        public UserModel ActiveLoggedUser
        {
            get { return _activeLoggedUser; }
            set { _activeLoggedUser = value;
                ActiveUserOnBar = "User: " + value?.Username;
                NotifyOfPropertyChange(() => ActiveLoggedUser); 
                NotifyOfPropertyChange(() => CanAdminScreen); 
                NotifyOfPropertyChange(() => CanCashierScreen); 
                NotifyOfPropertyChange(() => ActiveUserOnBar); 
            }
        }

        public string ActiveUserOnBar
        {
            get;
            set;
        }




        public bool CanAdminScreen
        {
            get
            {
                if (ActiveLoggedUser?.Role == "admin")
                    return true;
                else
                    return false;
            }
        }
        public bool CanCashierScreen
        {
            get
            {
                if (ActiveLoggedUser?.Role == "cashier" || ActiveLoggedUser?.Role == "admin")
                    return true;
                else
                    return false;
            }
        }

        private void _loginVM_LogInEvent(object sender, LogInEventArgs e)
        {
            if (e.LoggedInSuccesfully == true)
                _loginVM.LogInEvent -= _loginVM_LogInEvent;


            ActiveLoggedUser =  e.ActiveUser;
            if (e.ActiveUser?.Role == "admin")
            {
                DeactivateItem(_loginVM, true);
                AdminScreen();
            }
            else if (e.ActiveUser?.Role == "cashier")
            {
                DeactivateItem(_loginVM, true);
                CashierScreen();

            }
            else
            {
                DeactivateItem(_loginVM, true);
                BlankScreen();
            }
            //if(e.LoggedInSuccesfully == true)
            //{
            //    DeactivateItem(_loginVM, true);
            //}
        }

        public void AdminScreen()
        {
            ActivateItem(_dashboardVM);
        } 
        public void CashierScreen()
        {
            ActivateItem(_cashierVM);
        }

        public void LoginScreen()
        {
            _loginVM = new LoginViewModel(_userDBHelper, _userValidator);
            ActiveLoggedUser = new UserModel() { Username = "No user"};
            _loginVM.LogInEvent += _loginVM_LogInEvent;
            ActivateItem(_loginVM);
        }
        public void BlankScreen()
        {
            ActivateItem(_blankVM);
        }















    }
}
