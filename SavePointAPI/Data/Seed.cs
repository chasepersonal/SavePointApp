using Newtonsoft.Json;
using SavePointAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavePointAPI.Data
{
    public class Seed
    {
        // Set database context variable
        private readonly GamesDbContext _context;

        // Initalize contructor to set database context
        public Seed(GamesDbContext context)
        {
            _context = context;
        }

        public void SeedUsers()
        {
            // Will delete useres table if it isn't null already
            _context.Users.RemoveRange(_context.Users);
            _context.SaveChanges();

            // Seed user data
            // Call the System IO to read all the text from the json file with user data
            var userData = System.IO.File.ReadAllText("Data/UserSeedData.json");

            // Convert Json data from user data file so it can be read
            var users = JsonConvert.DeserializeObject<List<User>>(userData);

            // Loop through users in order to generate password hashs and salts
            // Needed to store information to database
            foreach(var user in users)
            {
                // Create the password hash
                byte[] passwordHash, passwordSalt;

                // Need to pass in the password to create the hash
                // Specifying a type, so password can't be accessed
                // All passwords are "password", so can be hardcoded
                CreatePasswordHash("password", out passwordHash, out passwordSalt);

                // Set password hash and salt for the user
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                // Convert username to lower case
                user.Username = user.Username.ToLower();

                // Add user to user table
                _context.Users.Add(user);
            }

            // Save changes to the database
            _context.SaveChanges();
        }

        // Create password hash and salt
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
    }
}
