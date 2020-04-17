using Caliburn.Micro;
using StoreManagerUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace StoreManagerUI.ViewModels
{
    public class AdminViewModel : Conductor<object>
    {
        #region Private props
        private BindableCollection<IProductModel> _productModels = new BindableCollection<IProductModel>();
        private IProductModel _selectedProduct;
        private IDataAccessModel _dataAcesserModel;
        private int _quantityToAdd;
        #endregion

        public AdminViewModel(IDataAccessModel dataAcesserModel, IProductModel product)
        {
            _selectedProduct = product;
            _dataAcesserModel = dataAcesserModel;
            _productModels = new BindableCollection<IProductModel>(_dataAcesserModel.LoadProducts());
        }

        #region Public props and accesers

        public BindableCollection<IProductModel> ProductsList
        {
            get { return _productModels; }
            set { _productModels = value; NotifyOfPropertyChange(() => ProductsList); }
        }
        public IProductModel SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                NotifyOfPropertyChange(() => SelectedProduct);
                NotifyOfPropertyChange(() => CanRemoveProduct);
                NotifyOfPropertyChange(() => CanSubmitQuantityChange);
            }
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
                NotifyOfPropertyChange(() => CanSubmitQuantityChange);
            }
        }





        #endregion


        #region Can_Do_Props
        public bool CanRemoveProduct
        {
            get
            {
                if (SelectedProduct?.Name.Length > 0)
                    return true;
                else
                    return false;
            }
        }
        public bool CanSubmitQuantityChange
        {
            get
            {
                //TODO if any product selected
                if (QuantityToAdd != 0 && SelectedProduct?.Name.Length > 0)
                    return true;
                else
                    return false;
            }
        }
   

        #endregion


        #region Binded voids and interactions
        public void RemoveProduct()
        {
            //TODO REMOVE FROM LIST
            _dataAcesserModel.RemoveExistingProduct(SelectedProduct.Id);
            RefreshList();
        }
        public void SubmitQuantityChange()
        {
            _dataAcesserModel.ChangeQuantityOfProduct(SelectedProduct.Quantity, QuantityToAdd, SelectedProduct.Id);
            QuantityToAdd = 0;
            RefreshList();
        }


     

   

        #endregion

        

        #region Methods and functions
        public void RefreshList()
        {
            _productModels = new BindableCollection<IProductModel>(_dataAcesserModel.LoadProducts());
            NotifyOfPropertyChange(() => ProductsList);
        }

     

        #endregion


        public void AddNewProduct()
        {
            AddNewProductFormViewModel addForm = new AddNewProductFormViewModel(_dataAcesserModel);
            new WindowManager().ShowWindow(addForm);
            addForm.ProductListChangedEvent += AddForm_ProductListChangedEvent;
        }

        private void AddForm_ProductListChangedEvent(object sender, bool e)
        {
            RefreshList();
        }
    }
}
