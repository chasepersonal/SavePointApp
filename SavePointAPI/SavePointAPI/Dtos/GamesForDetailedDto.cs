using SavePointApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SavePointAPI.Dtos
{
    public class GamesForDetailedDto
	{
		// DTO for detailed games list

		public int Id { get; set; }

		public string Title { get; set; }

		public string Console { get; set; }

		public string Genre { get; set; }

		public string Summary { get; set; }

		public string Comment { get; set; }

		public int Rating { get; set; }

		public DateTime Created { get; set; }

		public DateTime LastUpdate { get; set; }
	}
}
