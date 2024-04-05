using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTickets.Application.Core.Request
{
    public class ActorReq
    {
        [Required(ErrorMessage = "Profile Picutre is required")]
        public string ProfilePictureUrl { get; set; }
        [Required(ErrorMessage = "Actor Name is required")]
        [MinLength(3, ErrorMessage = "Actor Name Must be more than 3 chars")]
        [MaxLength(50, ErrorMessage = "Actor name must be less than 50 chars")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Actor bio is required")]
        public string Bio { get; set; }
    }
}
