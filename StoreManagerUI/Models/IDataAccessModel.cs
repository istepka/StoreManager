using System.Collections.Generic;

namespace StoreManagerUI.Models
{
    public interface IDataAccessModel
    {
        /// <summary>
        /// Adds new product to db
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="quantity"></param>
        void AddNewProduct(string name, decimal price, int quantity);
        /// <summary>
        /// Adds new product to db
        /// </summary>
        /// <param name="product"></param>
        void AddNewProduct(ProductModel product);
        
        void ChangeQuantityOfProduct(int actualQuantity, int quantity, int id);
        string LoadConnectionString(string id = "Default");
        /// <summary>
        /// Returns List<ProductModel> stored in database
        /// </summary>
        /// <returns>List<ProductModel></returns>
        List<ProductModel> LoadProducts();
        /// <summary>
        /// Removes record from database based on passed id
        /// </summary>
        /// <param name="id"></param>
        void RemoveExistingProduct(int id);

        /// <summary>
        /// Change price of existing product
        /// </summary>
        /// <param name="productModel"></param>
        void ChangeProductPrice(IProductModel productModel);
    }
}