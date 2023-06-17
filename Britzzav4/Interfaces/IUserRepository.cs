using Britzzav4.Models;

namespace Britzzav4.Interfaces
{
    public interface IUserRepository
    {
        void CreateUser(User user);
        User GetUserByUsernameAndPassword(string username, string password);
    }
}
