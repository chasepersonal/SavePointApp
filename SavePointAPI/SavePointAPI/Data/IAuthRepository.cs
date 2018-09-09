using SavePointApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavePointApp.Data
{
    // Interface for Authorization Repository
    public interface IAuthRepository
    {
    Task<User> Register(User user, string password);

    Task<User> Login(string username, string password);

    Task<bool> UserExists(string username);
    }
}
