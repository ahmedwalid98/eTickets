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
        [Required]
        public string ProfilePictureUrl { get; set; } = string.Empty;
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string FullName { get; set; }
        [Required]
        public string Bio { get; set; }
        public ICollection<Movie> Movies { get; set; }
	}
}
