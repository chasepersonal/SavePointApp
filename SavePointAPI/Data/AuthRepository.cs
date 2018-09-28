using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SavePointAPI.Models;

namespace SavePointAPI.Data
{
    public class AuthRepository : IAuthRepository
    {
        // Database context variable
        private readonly GamesDbContext _context;

        // Constructor to inject data context into the repository
        public AuthRepository(GamesDbContext context)
        {
            _context = context;
        }
        public async Task<User> Login(string username, string password)
        {
            // First first user that matches on the username or return a default value
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);

            // Return null value if user is not found
            if (user == null)
                return null;

            // If password is not verified, return null
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // Auth successful if reached this point
            return user;
        }

        // Verify users password
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            // Pass in the salt to confirm
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                // Compare hash for user against values in the database
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for(int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            }

            return true;

        }

        public async Task<User> Register(User user, string password)
        {
            // Create byte arrays for password hash and salt
            byte[] passwordHash, passwordSalt;
            // Pass a reference for hash and salt so they can be updated
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            // Set password hash and salt for user
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            // Add user and save user information to database
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        // Pass a reference for hash and salt so they can be updated
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            // Hash password using HMACSHA512 scurity standard to generate a random key
            // Use using to help manage resources associated with hasing a password
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                // Provides a key for the salt
                passwordSalt = hmac.Key;
                // Computes a randomly generated hash for the password
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }

        public async Task<bool> UserExists(string username)
        {
            // Check all users in the database to see if the current user matches with one in the database
            if (await _context.Users.AnyAsync(x => x.Username == username))
                return true;

            return false;
        }
    }
}
