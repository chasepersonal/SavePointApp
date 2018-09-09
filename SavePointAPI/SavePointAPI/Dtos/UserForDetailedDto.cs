using SavePointApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SavePointApp.Dtos
{
    public class UserForDetailedDto
    {
        [Key]
        public int Id { get; set; }

        public string Username { get; set; }

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

        public string ProfilePhotoUrl { get; set; }

        public ICollection<PhotosForDetailedDto> ProfilePhotos { get; set; }
    }
}
