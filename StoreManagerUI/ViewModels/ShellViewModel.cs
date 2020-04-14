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



      
        public ShellViewModel(AdminViewModel adminVM, CashierViewModel cashierVM, LoginViewModel loginVM)
        {
            _adminVM = adminVM;
            _cashierVM = cashierVM;
            _loginVM = loginVM;
            ActivateItem(_loginVM);

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
