using System.Collections.Generic;

namespace StoreManagerUI.Models
{
    public interface IDataAcesserModel
    {
        void AddNewProduct(string name, float price, int quantity);
        void ChangeQuantityOfProduct(ProductModel product);
        string LoadConnectionString(string id = "Default");
        List<ProductModel> LoadProducts();
        void RemoveExistingProduct(ProductModel product);
    }
}