using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagerUI.Models
{
    public class ProductModel
    {
        /// <summary>
        /// Id of product
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name of product
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Price of product 
        /// </summary>
        public float Price { get; set; }
        /// <summary>
        /// Quantity actually stored in magazine
        /// </summary>
        public int Quantity { get; set; } = 0;

        /// <summary>
        /// Returns name, price and quantity of product
        /// </summary>
        public string ProductOverview
        {
            get
            {
                return $"{Name} | {Price.ToString("C")} | {Quantity}";
            }

        }

    }
}
