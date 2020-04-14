using Caliburn.Micro;
using StoreManagerUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagerUI.ViewModels
{
    public class AdminViewModel : Screen
    {
        private BindableCollection<IProductModel> _productModels = new BindableCollection<IProductModel>();
        private IProductModel _selectedProduct;
        private IDataAccessModel _dataAcesserModel;
        private int _quantityToAdd;



        public AdminViewModel(IDataAccessModel dataAcesserModel, IProductModel product)
        {
            _selectedProduct = product;
            _dataAcesserModel = dataAcesserModel;
            _productModels = new BindableCollection<IProductModel>(_dataAcesserModel.LoadProducts());
            

        }
        public BindableCollection<IProductModel> ProductsList
        {
            get { return _productModels; }
            set { _productModels = value; }
        }
        public IProductModel SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                NotifyOfPropertyChange(() => SelectedProduct);
            }
        }
        public void RemoveProduct()
        {
            //TODO REMOVE FROM LIST
            _dataAcesserModel.RemoveExistingProduct(_selectedProduct.Id);
            RefreshList();
        }
        public void SubmitQuantityChange(int quantityToAdd, IProductModel selectedProduct)
        {
            _dataAcesserModel.ChangeQuantityOfProduct(_selectedProduct.Quantity, quantityToAdd, _selectedProduct.Id);
            QuantityToAdd = 0;
            RefreshList();
        }
        public bool CanSubmitQuantityChange(int quantityToAdd, IProductModel selectedProduct)
        {
            //TODO if any product selected
            if (quantityToAdd != 0 && _selectedProduct != null)
                return true;
            else
                return false;
        }

        public int QuantityToAdd
        {
            get
            {
                return _quantityToAdd;
            }
            set
            {
                _quantityToAdd = value;
                NotifyOfPropertyChange(() => QuantityToAdd);
            }
        }













        public void RefreshList()
        {
            _productModels = new BindableCollection<IProductModel>(_dataAcesserModel.LoadProducts());
            NotifyOfPropertyChange(() => ProductsList);
        }

    }
}
