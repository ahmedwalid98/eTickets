using eTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicket.Domain.Specification.MovieSpecification
{
    public class GetAllMoviesSpecs: Specification<Movie>
    {
        public GetAllMoviesSpecs(string search) : base(m => m.Name.ToLower().Contains(search))
        {
            AddInclude(m => m.Cinema);
            AddInclude(m => m.Producer);

        }
        public GetAllMoviesSpecs(): base() 
        {
            AddInclude(m => m.Cinema);
            AddInclude(m => m.Producer);
            
        }
    }
}
