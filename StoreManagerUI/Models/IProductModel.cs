namespace StoreManagerUI.Models
{
    public interface IProductModel
    {
        /// <summary>
        /// Id of product
        /// </summary>
        int Id { get; set; }
        /// <summary>
        /// Name of product
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Price of product 
        /// </summary>
        decimal Price { get; set; }

        /// <summary>
        /// Returns name, price and quantity of product
        /// </summary>
        string ProductOverview { get; }

        /// <summary>
        /// Quantity actually stored in magazine
        /// </summary>
        int Quantity { get; set; }


        /// <summary>
        /// Returns price formated to a proper currency value
        /// </summary>
        string PriceString { get; }
    }
}