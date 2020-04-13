using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagerUI.Models
{
    public class DataAcesserModel : IDataAcesserModel
    {
        // private List<Product> products;
        public List<ProductModel> LoadProducts()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ProductModel>("select * from Products", new DynamicParameters());
                System.Diagnostics.Debug.WriteLine("DataLoadedSuccesfully");
                return output.ToList();
            }
        }

        public void AddNewProduct(string name, float price, int quantity)
        {
            var product = new ProductModel() { Name = name, Price = price, Quantity = quantity };

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("INSERT INTO Products (Name, Price, Quantity) values (@Name, @Price, @Quantity)", product);


            }
        }

        public void RemoveExistingProduct(ProductModel product)
        {

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute($"DELETE FROM Products WHERE Id = {product.Id}");


            }
        }

        public void ChangeQuantityOfProduct(ProductModel product)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute($"UPDATE Products SET Quantity = {product.Quantity} WHERE Id = {product.Id}");
            }
        }

        public string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

    }
}
