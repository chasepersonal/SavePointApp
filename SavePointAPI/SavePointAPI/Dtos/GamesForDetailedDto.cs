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
		// Make primary key for this table
		// Tie to User table by making this a foreign key
		// Will tie to primary key in User table to identify game ownership
		[Key]
		[ForeignKey("User")]
		public int UserID { get; set; }

		public virtual User User { get; set; }

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
