using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTicket.Domain.Entities;

namespace eTicket.Domain.Entities
{
	public class Actor: BaseEntity
	{
		[Required]
        public string ProfilePictureUrl { get; set; } = string.Empty;
		[Required]
		[MinLength(3)]
		[MaxLength(50)]
		public string FullName { get; set; }
		[Required]
        public string Bio { get; set; }
		public ICollection<MovieActor> MoviesActors { get; set; }
	}
}
