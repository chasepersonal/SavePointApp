using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SavePointApp.Models
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }

        public string Url { get; set; }

        public DateTime DateAdded { get; set; }

        public bool IsCurrent { get; set; }

        // User and UserId variable used to define relationship to User table
        // Association will allow database to cascade changes between the Photo and User tables
        public User User { get; set; }

        public int UserId { get; set; }
    }
}
