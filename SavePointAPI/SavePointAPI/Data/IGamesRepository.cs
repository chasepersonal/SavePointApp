using SavePointApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavePointApp.Data
{
    public interface IGamesRepository
    {
        // Generic add method
        // Can use single add method instead of multiple ones
        // Constraint the use of the generics to a class

        void Add<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        // Save method
        Task<bool> SaveAll();

        // Get User methods
        Task<IEnumerable<User>> GetUsers();

        Task<User> GetUser(int id);

        // Get Games methods
        Task<IEnumerable<Games>> GetGames();

        Task<Games> GetGame(int id);

    }
}
