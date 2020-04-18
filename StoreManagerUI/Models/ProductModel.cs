using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagerUI.Models
{
    public class ProductModel : IProductModel
    {
       
        public int Id { get; set; }
   
        public string Name { get; set; }
       
        public decimal Price { get; set; }
        
        public int Quantity { get; set; } = 0;

       
        public string ProductOverview
        {
            get
            {
                return $"{Name} | {Price.ToString("C2")} | {Quantity}";
            }

        }

        public string PriceString
        {
            get
            {
                return $"{Price.ToString("C2")}";
            }
        }

    }
}
