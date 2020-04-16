using System.Collections.Generic;

namespace StoreManagerUI.Models
{
    public interface IDataAccessModel
    {
        void AddNewProduct(string name, float price, int quantity);
        void AddNewProduct(ProductModel product);
        void ChangeQuantityOfProduct(int actualQuantity, int quantity, int id);
        string LoadConnectionString(string id = "Default");
        List<ProductModel> LoadProducts();
        void RemoveExistingProduct(int id);
    }
}