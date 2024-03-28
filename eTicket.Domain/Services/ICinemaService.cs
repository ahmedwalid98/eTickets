using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTicket.Domain.Entities;

namespace eTicket.Domain.Services
{
    public interface ICinemaService
    {
        Task<IEnumerable<Cinema>> GetAllCinemas();
    }
}
