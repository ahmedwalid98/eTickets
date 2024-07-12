﻿using eTicket.Domain.Entities;
using eTicket.Domain.Specification;
using eTickets.Application.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eTickets.Application.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<MoviesDto>> GetAllMovies();
        Task<MoviesDto> GetMovieDetail(int id);
    }
}
