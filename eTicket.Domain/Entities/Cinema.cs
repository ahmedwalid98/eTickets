using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace eTicket.Domain.Entities
{
	public class Cinema: BaseEntity
	{
        [Required]
        public string CinemaLogo { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
