
using System.ComponentModel.DataAnnotations.Schema;
using eTickets.Domain.Enums;


namespace eTicket.Domain.Entities
{
	public class Movie : BaseEntity
	{
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCategory MovieCategory { get; set; }
        [ForeignKey(nameof(Cinema))]
        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }
        [ForeignKey(nameof(Producer))]
        public int ProducerId { get; set; }
        public Producer Producer { get; set; }

        public ICollection<MovieActor> MoviesActors { get; set; }
    }
}
