using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTicket.Domain.Entities;
using eTickets.Domain.Entities;

namespace eTickets.Domain.Models
{
	public class Cinema: BaseEntity
	{
        public string CinemaLogo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
