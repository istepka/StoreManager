using Caliburn.Micro;
using StoreManagerUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagerUI.ViewModels
{
    public class AdminOperationsViewModel
    {
        private BindableCollection<ProductModel> _productModels = new BindableCollection<ProductModel>();
        private ProductModel _selectedProduct;

        public AdminOperationsViewModel(DataAccessModel dataAcesser)
        {
            _productModels = new BindableCollection<ProductModel>(dataAcesser.LoadProducts());
        }
        public BindableCollection<ProductModel> ProductsList
        {
            get { return _productModels;  }
            set { _productModels = value;}
        }
        public ProductModel SelectedPerson
        {
            get { return _selectedProduct;  }
            set 
            {
                _selectedProduct = value;
            }
        }


     

    }
}
