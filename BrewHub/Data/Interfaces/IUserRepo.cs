namespace BrewHub.Data.Interfaces
{
    public interface IUserRepo
    {
        public void AddNewUser(string username, string password, string email);
        
    }
}
