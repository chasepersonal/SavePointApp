using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SavePointAPI.Models;

namespace SavePointAPI.Data
{
    public class GamesRepository : IGamesRepository
    {
        private readonly GamesDbContext _context;

        public GamesRepository(GamesDbContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Games> GetGame(int id)
        {
            var game = await _context.Games.FirstOrDefaultAsync(g => g.Id == id);

            return game;

        }

        public async Task<IEnumerable<Games>> GetGames()
        {
            var games = await _context.Games.ToListAsync();

            return games;
        }

        public async Task<User> GetUser(int id)
        {
            // Include single user with specific profile pic
            var user = await _context.Users.Include(p => p.ProfilePhotos).FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            // Include all users with their profile photo
            var users = await _context.Users.Include(p => p.ProfilePhotos).ToListAsync();

            return users;

        }

        public async Task<bool> SaveAll()
        {
            // Save the changes to the database if there are more than zero changes
            // Otherwise, don't save to the database

            return await _context.SaveChangesAsync() > 0;
        }
    }
}