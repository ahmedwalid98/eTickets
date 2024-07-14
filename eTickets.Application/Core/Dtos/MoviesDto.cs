using eTicket.Domain.Entities;
using eTickets.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTickets.Application.Core.Dtos
{
    public class MoviesDto
    {
        public int Id { get; set; }
        [Display(Name = "Movie name")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "Movie poster URL")]
        public string ImageUrl { get; set; }
        public string CinemaName { get; set; }
        [Display(Name = "Select cinema")]
        public int CinemaId { get; set; }
        [Display(Name = "Select producer")]
        public int ProducerId { get; set; }
        public string ProducerName { get; set; }
        public MovieCategory MovieCategory {  get; set; }
        public string Category { get; set; }
        [Display(Name = "Select actor(s)")]
        public List<int> ActorIds { get; set; }

        public List<Actor> Actors { get; set; }
        [Display(Name = "Movie price in $")]
        public double Price { get; set; }
        [Display(Name = "Movie start date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Movie end date")]
        public DateTime EndDate { get; set; }
    }
}
