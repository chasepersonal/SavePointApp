using System;
using System.ComponentModel.DataAnnotations;

namespace SavePointApp.Models
{
    public class Games
    {
        // Initialize values for game information
        // Also establish getters and setters

        [Key]
		public int Id { get; set; }

        public string Title { get; set; }

        public string Console { get; set; }

        public string Genre { get; set; }

        public int ReleaseYear { get; set; }

        public int Rating { get; set; }

        public string Comment { get; set; }

        // User and UserId variable used to define relationship to User table
        // Association will allow database to cascade changes between the Games and User tables
        public User User { get; set; }

        public int UserId { get; set; }

    }
}
