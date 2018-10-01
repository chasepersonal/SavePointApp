using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SavePointAPI.Models
{
    public class Games
    {
        // Initialize values for game information
        // Also establish getters and setters

        // Make primary key for this table
        [Key]
        public int Id { get; set; }
		// Tie to User table by making this a foreign key
		// Will tie to primary key in User table to identify game ownership
		[ForeignKey("User")]
		public int UserId { get; set; }

		public virtual User User { get; set; }

        public string Title { get; set; }

        public string Console { get; set; }

        public string Genre { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int Rating { get; set; }

        public string Comment { get; set; }
    }
}