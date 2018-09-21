using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SavePointApp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Username { get; set; }

        // Hash the password for security purposes
        public byte[] PasswordHash { get; set; }

        // Add a salt to increase password security
        public byte[] PasswordSalt { get; set; }

        // User demographic information
        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastActive { get; set; }

        public string Summary { get; set; }

        public string FavoriteGenres { get; set; }

        public string FavoriteGames { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        // One user can have many profile photos
        // To allow use of an older profile photo
        public ICollection<Photo> ProfilePhotos { get; set; }

        // Creates a collection of Games for each user
        public ICollection<Games> Games { get; set; }

        // Constructor to initialize photo collection
        public User()
        {
            ProfilePhotos = new Collection<Photo>();
            Games = new Collection<Games>();
        }

    }
}
