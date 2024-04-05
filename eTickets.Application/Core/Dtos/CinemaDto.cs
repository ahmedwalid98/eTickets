using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTickets.Application.Core.Dtos
{
    public class CinemaDto
    {
        public int Id { get; set; }
        public string CinemaLogo { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        public List<string> MoviesName { get; set; } = new List<string>();
    }
}
