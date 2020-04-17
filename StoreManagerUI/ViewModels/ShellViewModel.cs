using Caliburn.Micro;
using StoreManagerUI.Events;
using StoreManagerUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagerUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private AdminViewModel _adminVM;
        private CashierViewModel _cashierVM;
        private LoginViewModel _loginVM;


        private UserModel _activeLoggedUser;

        public UserModel ActiveLoggedUser
        {
            get { return _activeLoggedUser; }
            set { _activeLoggedUser = value; 
                NotifyOfPropertyChange(() => ActiveLoggedUser); 
                NotifyOfPropertyChange(() => CanAdminScreen); 
                NotifyOfPropertyChange(() => CanCashierScreen); }
        }




        public ShellViewModel(AdminViewModel adminVM, CashierViewModel cashierVM, LoginViewModel loginVM)
        {
            _adminVM = adminVM;
            _cashierVM = cashierVM;
            _loginVM = loginVM;
            ActivateItem(_loginVM);
            ActiveLoggedUser = new UserModel() { Username = "No user"};
            _loginVM.LogInEvent += _loginVM_LogInEvent;
        }

        /// <summary>
        /// Automatically logs into right dashoard
        /// </summary>
        private void _loginVM_LogInEvent(object sender, LogInEventArgs e)
        {
            ActiveLoggedUser =  e.ActiveUser;
            if (e.ActiveUser?.Role == "admin")
                AdminScreen();
            else if (e.ActiveUser?.Role == "cashier")
                CashierScreen();
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

        public void AdminScreen()
        {
            ActivateItem(_adminVM);
        } 
        public void CashierScreen()
        {
            ActivateItem(_cashierVM);
        }

        public void LoginScreen()
        {
            
            ActiveLoggedUser = new UserModel() { Username = "No user"};

            ActivateItem(_loginVM);
        }















    }
}
