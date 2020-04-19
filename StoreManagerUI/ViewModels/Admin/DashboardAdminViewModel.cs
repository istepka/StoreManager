using Caliburn.Micro;
using StoreManager.Core.Validators;
using StoreManagerUI.Helpers;
using StoreManagerUI.Models;
using StoreManagerUI.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagerUI.ViewModels
{
    public class DashboardAdminViewModel : Conductor<object>.Collection.OneActive
    {
        private IProductDBHelper _dataAccessModel;
        private IProductModel _productModel;
        private IUserDBHelper _userDBHelper;
        private AdminViewModel _adminVM;
        private UserManagementViewModel _userManagementVM;
        private DashboardWelcomeViewModel _dashboardWelcomeVM;
        private IUserValidator _userValidator;

        public DashboardAdminViewModel(IUserDBHelper userDBHelper, IProductDBHelper dataAccessModel, IProductModel productModel, IUserValidator userValidator)
        {
            _dataAccessModel = dataAccessModel;
            _productModel = productModel;
            _userDBHelper = userDBHelper;
            _dashboardWelcomeVM = new DashboardWelcomeViewModel();
            _userValidator = userValidator;

            DashboardWelcome();
            _dashboardWelcomeVM.ActivateProductsTab += _dashboardWelcomeVM_ActivateProductsTab;
            _dashboardWelcomeVM.ActivateUsersTab += _dashboardWelcomeVM_ActivateUsersTab;
        }

        private void _dashboardWelcomeVM_ActivateUsersTab(object sender, bool e)
        {
            if (e == true)
                UsersManager();
            e = false;
        }

        private void _dashboardWelcomeVM_ActivateProductsTab(object sender, bool e)
        {
            if (e == true)
                ProductManager();
            e = false;
        }

        public void ProductManager()
        {
            _adminVM = new AdminViewModel(_dataAccessModel, _productModel);
            ActivateItem(_adminVM);
        }


        public void UsersManager()
        {
            _userManagementVM = new UserManagementViewModel(_userDBHelper, _userValidator);
            ActivateItem(_userManagementVM);
        }

        public void DashboardWelcome()
        {
            
            ActivateItem(_dashboardWelcomeVM);
        }
       
    }
}
