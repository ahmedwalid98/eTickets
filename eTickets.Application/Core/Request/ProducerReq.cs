using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTickets.Application.Core.Request
{
    public class ProducerReq
    {
        [Required(ErrorMessage = "Profile Picutre is required")]
        public string ProfilePictureUrl { get; set; }
        [Required(ErrorMessage = "Producer Name is required")]
        [MinLength(3, ErrorMessage = "Producer Name Must be more than 3 chars")]
        [MaxLength(50, ErrorMessage = "Producer name must be less than 50 chars")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Producer bio is required")]
        public string Bio { get; set; }
    }
}
