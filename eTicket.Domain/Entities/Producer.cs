using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace eTicket.Domain.Entities
{
	public class Producer : BaseEntity
	{
		public string ProfilePictureUrl { get; set; } = string.Empty;
		public string FullName { get; set; }
		public string Bio { get; set; }
		public ICollection<Movie> Movies { get; set; }
	}
}
