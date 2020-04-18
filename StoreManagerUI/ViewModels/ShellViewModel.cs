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
    public class ShellViewModel : Conductor<object>.Collection.OneActive
    {
        private DashboardAdminViewModel _dashboardVM;
        private CashierViewModel _cashierVM;
        private LoginViewModel _loginVM;
        private BlankScreenViewModel _blankVM;


        private UserModel _activeLoggedUser;

        public UserModel ActiveLoggedUser
        {
            get { return _activeLoggedUser; }
            set { _activeLoggedUser = value; 
                NotifyOfPropertyChange(() => ActiveLoggedUser); 
                NotifyOfPropertyChange(() => CanAdminScreen); 
                NotifyOfPropertyChange(() => CanCashierScreen); }
        }




        public ShellViewModel(DashboardAdminViewModel dashboardVM, CashierViewModel cashierVM, LoginViewModel loginVM, BlankScreenViewModel blankVM)
        {
            _dashboardVM = dashboardVM;
            _cashierVM = cashierVM;
            _loginVM = loginVM;
            _blankVM = blankVM;
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
            else
                BlankScreen();
            
            if(e.LoggedInSuccesfully == true)
            {
                DeactivateItem(_loginVM, true);
            }
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
            ActivateItem(_dashboardVM);
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
        public void BlankScreen()
        {
            ActivateItem(_blankVM);
        }















    }
}
