using Caliburn.Micro;
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
            set { _activeLoggedUser = value; NotifyOfPropertyChange(() => ActiveLoggedUser); }
        }




        public ShellViewModel(AdminViewModel adminVM, CashierViewModel cashierVM, LoginViewModel loginVM)
        {
            _adminVM = adminVM;
            _cashierVM = cashierVM;
            _loginVM = loginVM;
            ActivateItem(_loginVM);
        }
      
        public bool CanAdminScreen()
        {
            if (ActiveLoggedUser?.Role == "admin")
                return true;
            else
                return false;
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
            ActivateItem(_loginVM);
        }















    }
}
