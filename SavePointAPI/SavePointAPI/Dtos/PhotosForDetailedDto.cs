using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavePointApp.Dtos
{
    public class PhotosForDetailedDto
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public DateTime DateAdded { get; set; }

        public bool IsCurrent { get; set; }
    }
}
