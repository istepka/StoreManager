using Caliburn.Micro;
using StoreManagerUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagerUI.ViewModels
{
    /// <summary>
    /// Form for adding new products VM
    /// </summary>
    public class AddProductViewModel : Screen
    {
        public event EventHandler<bool> ProductListChangedEvent;

        private IDataAccessModel _dataAcesserModel;
        private string _newProductName = "";
        private int _newProductPrice = 0;
        private int _newProductQuantity = 0;

        public AddProductViewModel(IDataAccessModel dataAccessModel)
        {
            _dataAcesserModel = dataAccessModel;
        }

        public string NewProductName
        {
            get { return _newProductName; }
            set { _newProductName = value; NotifyOfPropertyChange(() => NewProductName); NotifyOfPropertyChange(() => CanSubmitNewProduct); }
        }


        public int NewProductPrice
        {
            get { return _newProductPrice; }
            set { _newProductPrice = value; NotifyOfPropertyChange(() => NewProductPrice); NotifyOfPropertyChange(() => CanSubmitNewProduct); }
        }



        public int NewProductQuantity
        {
            get { return _newProductQuantity; }
            set { _newProductQuantity = value; NotifyOfPropertyChange(() => NewProductQuantity); NotifyOfPropertyChange(() => CanSubmitNewProduct); }
        }


      
        public bool CanSubmitNewProduct
        {
            get
            {
                if (NewProductName?.Length > 0 && NewProductPrice > 0 && NewProductQuantity >= 0)
                    return true;
                else
                    return false;
            }
        }
        public void SubmitNewProduct()
        {
            _dataAcesserModel.AddNewProduct(NewProductName, NewProductPrice, NewProductQuantity);
            NewProductName = "";
            NewProductPrice = 0;
            NewProductQuantity = 0;
            ProductListChangedEvent?.Invoke(this, true);
        }

        //public void CloseForm()
        //{
        //    this.Views.Clear();
        //}

    }
}
