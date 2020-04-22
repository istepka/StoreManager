using StoreManagerUI.Models;
using System;
using System.Collections.Generic;
using Caliburn.Micro;
using System.Text;

namespace StoreManagerUI.ViewModels.Controls
{
    public class CartViewModel : Screen
    {
        


        public void AddProductToCart(IProductModel product, int quantity)
        {
            product.Quantity = quantity;
            Cart.Add(product);
        }


        private List<IProductModel> _cart = new List<IProductModel>();
        public List<IProductModel> Cart
        {
            get { return _cart; }
            set { _cart = value;
                NotifyOfPropertyChange(() => Cart);
            }
        }

        private decimal _total;

        public decimal Total
        {
            get { return _total; }
            set { _total = value;
                NotifyOfPropertyChange(()=>Total);
            }
        }





    }
}
