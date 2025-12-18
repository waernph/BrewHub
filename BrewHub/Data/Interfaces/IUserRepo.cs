namespace BrewHub.Data.Interfaces
{
    public interface IUserRepo
    {
        public void AddNewUser(string username, string password, string email);
        public void UpdateUser(string oldUsername, string oldPassword, string newUsername, string newPassword, string newEmail);
    }
}
