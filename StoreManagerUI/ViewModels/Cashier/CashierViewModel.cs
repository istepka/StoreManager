using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using StoreManagerUI.Models;
using StoreManagerUI.ViewModels.Controls;

namespace StoreManagerUI.ViewModels
{
    public class CashierViewModel : Screen
    {
        private BindableCollection<IProductModel> _productsList = new BindableCollection<IProductModel>();
        private IProductModel _selectedProduct;
        private IProductDBHelper _productDBHelper;
        private string _searchedProduct;
        private BindableCollection<IProductModel> _cart = new BindableCollection<IProductModel>();
        private decimal _total;
        private int _buyQuantity;
        private string _errorText;
     
        public CashierViewModel(IProductDBHelper productDBHelper, IProductModel product)
        {
            _selectedProduct = product;
            _productDBHelper = productDBHelper;
            _productsList = new BindableCollection<IProductModel>(_productDBHelper.LoadProducts());
       
        }

    
        public BindableCollection<IProductModel> ProductsList
        {
            get
            {
                if (SearchedProduct != null)
                    return GetFilteredList();
                else
                    return _productsList;
            }
            set
            {
                _productsList = value;
                NotifyOfPropertyChange(() => ProductsList);
            }
        }

        public IProductModel SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                NotifyOfPropertyChange(() => SelectedProduct);
                NotifyOfPropertyChange(() => CanBuyProduct);

            }
        }
        
        public string SearchedProduct
        {
            get { return _searchedProduct; }
            set
            {
                _searchedProduct = value;
                NotifyOfPropertyChange(() => SearchedProduct);
                NotifyOfPropertyChange(() => ProductsList);
            }
        }

        public BindableCollection<IProductModel> Cart
        {
            get { return _cart; }
            set
            {
                _cart = value;
                NotifyOfPropertyChange(() => Cart);
               

               
            }
        }

        public decimal Total
        {
            get { return _total; }
            set
            {
                _total = value;
                NotifyOfPropertyChange(() => Total);
                NotifyOfPropertyChange(() => TotalUI);
            }
        }

        public string TotalUI 
        {
            get
            {
                return Total.ToString("C2");
            }
        }

        public string ErrorText
        {
            get { return _errorText; }
            set { _errorText = value;
                NotifyOfPropertyChange(()=>ErrorText);
            }
        }

        public int BuyQuantity
        {
            get { return _buyQuantity; }
            set { _buyQuantity = value;
                NotifyOfPropertyChange(() => BuyQuantity);
                NotifyOfPropertyChange(() => CanBuyProduct);
            }
        }

        public bool CanBuyProduct
        {


            get
            {
                if (BuyQuantity > 0 && SelectedProduct != null)
                {

                    if (BuyQuantity > SelectedProduct.Quantity)
                    {
                        ErrorText = "Not enough in stock";
                        return false;
                    }
                    else
                    {
                        ErrorText = "";
                        return true;
                    }


                }
                else
                {
                    ErrorText = "";
                    return false;
                }
            }
        }


       


        public void BuyButton()
        {
            Cart.Clear();
            Total = default;
        }
        public void BuyProduct()
        {
            ErrorText = "Product Bought";
            if (BuyQuantity == SelectedProduct.Quantity)
            {
                _productDBHelper.RemoveExistingProduct(SelectedProduct.Id);
            }
            else
                _productDBHelper.ChangeQuantityOfProduct(SelectedProduct, -BuyQuantity);


            AddToCart(SelectedProduct, BuyQuantity);
            BuyQuantity = 0;
            RefreshList();
            
        }
        private decimal CartTotal()
        {
            decimal t = 0;
            foreach (var product in Cart)
            {
                t += product.Price*product.Quantity;
            }
            return t;
        }
        private void AddToCart(IProductModel product, int quantity )
        {
            product.Quantity = quantity;
            Cart.Add(product);
            Total = CartTotal();
            NotifyOfPropertyChange(()=>Cart);
            NotifyOfPropertyChange(()=>Total);
        }
        private BindableCollection<IProductModel> GetFilteredList()
        {
            var list = new BindableCollection<IProductModel>(_productsList.Where(x => x.Name.ToUpper().Contains(SearchedProduct.ToUpper())).ToList());


            return list;
        }
        public void RefreshList()
        {
            _productsList = new BindableCollection<IProductModel>(_productDBHelper.LoadProducts());
            NotifyOfPropertyChange(() => ProductsList);
        }

    }
}
