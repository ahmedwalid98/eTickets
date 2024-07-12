using eTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicket.Domain.Specification.MovieSpecification
{
    public class MovieSpecs: Specification<Movie>
    {
        public MovieSpecs(): base() 
        {
            AddInclude(m => m.Cinema);
            AddInclude(m => m.Producer);
            AddIncludes($"{nameof(Movie.MoviesActors)}.{nameof(MovieActor.Actor)}");
        }
    }
}
