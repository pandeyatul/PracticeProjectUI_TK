using ConcertBooking_Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConcertBooking_WebApp.Models.ViewModel
{
    public class CreateConcertModel
    {
        public int Id { get; set; }
        public string? ConcertName { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        public DateTime DateTime { get; set; }
        public int VenueId { get; set; }
        public int ArtistId { get; set; }
    }
}
