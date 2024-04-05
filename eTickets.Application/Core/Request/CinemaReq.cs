using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTickets.Application.Core.Request
{
    public class CinemaReq
    {
        [Required(ErrorMessage = "Cinema logo is required")]
        public string CinemaLogo { get; set; }
        [Required(ErrorMessage = "Cinema Name is required")]
        [MinLength(3, ErrorMessage = "Cinema Name Must be more than 3 chars")]
        [MaxLength(50, ErrorMessage = "Cinema name must be less than 50 chars")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Cinema description is required")]
        public string Description { get; set; }
    }
}
