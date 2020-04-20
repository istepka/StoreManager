namespace StoreManager.Core.Models
{
    public interface ILogger
    {
        void WriteNewLog(string content);
    }
}