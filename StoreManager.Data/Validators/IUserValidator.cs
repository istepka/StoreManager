namespace StoreManager.Data.Validators
{
    public interface IUserValidator
    {
        bool ValidatePassword(string password);
        bool ValidateUsername(string username);
    }
}