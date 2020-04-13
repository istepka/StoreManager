namespace StoreManagerUI.Models
{
    public interface IProductModel
    {
        int Id { get; set; }
        string Name { get; set; }
        float Price { get; set; }
        string ProductOverview { get; }
        int Quantity { get; set; }
    }
}