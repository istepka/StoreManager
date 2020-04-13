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
        //public void LoadAdminPage()
        //{
        //    ActivateItem(new AdminOperationsViewModel(new DataAcesserModel()));
        //}

        //public void LoadCashierPage()
        //{
        //    ActivateItem(new CashierOperationsViewModel());

        //}

        private BindableCollection<ProductModel> _productModels = new BindableCollection<ProductModel>();
        private ProductModel _selectedProduct;
        IDataAcesserModel _dataAcesserModel;

        public ShellViewModel(IDataAcesserModel dataAcesserModel)
        {
            _dataAcesserModel = dataAcesserModel;
            _productModels = new BindableCollection<ProductModel>(_dataAcesserModel.LoadProducts());
        }


        public BindableCollection<ProductModel> ProductsList
        {
            get { return _productModels; }
            set { _productModels = value; }
        }
        public ProductModel SelectedPerson
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
            }
        }
    }
}
