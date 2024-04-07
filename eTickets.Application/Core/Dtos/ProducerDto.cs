using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTickets.Application.Core.Dtos
{
    public class ProducerDto
    {
        public int Id { get; set; }
        public string ProfilePictureUrl { get; set; }

        public string FullName { get; set; }

        public string Bio { get; set; }
        public List<string> MoviesName { get; set; }
    }
}
