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
    public class DashboardAdminViewModel : Conductor<object>
    {
        private IDataAccessModel _dataAccessModel;
        private IProductModel _productModel;
        private IUserDBHelper _userDBHelper;

        public DashboardAdminViewModel(IUserDBHelper userDBHelper, IDataAccessModel dataAccessModel, IProductModel productModel)
        {
            _dataAccessModel = dataAccessModel;
            _productModel = productModel;
            _userDBHelper = userDBHelper;
        }

        public void ProductManager()
        {
            ActivateItem(new AdminViewModel(_dataAccessModel, _productModel));
        }

        //public void NewProduct()
        //{
        //    ActivateItem(new AddProductViewModel(_dataAccessModel));
        //}

        public void UsersManager()
        {
            ActivateItem(new AddUserViewModel(_userDBHelper));
        }
    }
}
