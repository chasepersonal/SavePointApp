using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SavePointAPI.Dtos
{
    public class UserForListDto
    {
        [Key]
        public int Id { get; set; }

        public string Username { get; set; }

        public string KnownAs { get; set; }

        public string Gender { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastActive { get; set; }

        public string FavoriteGenres { get; set; }

        public string FavoriteGames { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string ProfilePhotoUrl { get; set; }
    }
}