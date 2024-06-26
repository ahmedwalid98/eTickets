﻿using eTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTickets.Application.Core.Dtos
{
    public class MoviesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string CinemaName { get; set; }
        public int CinemaId { get; set; }
        public int ProducerId { get; set; }
        public string ProducerName { get; set; }
        public string Category { get; set; }
        public List<Actor> Actors { get; set; }
        public double Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
