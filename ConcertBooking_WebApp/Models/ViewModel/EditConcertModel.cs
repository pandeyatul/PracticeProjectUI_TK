using ConcertBooking_Entities;

namespace ConcertBooking_WebApp.Models.ViewModel
{
    public class EditConcertModel
    {
        public int Id { get; set; }
        public string? ConcertName { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public IFormFile? ImageFile { get; set; }
        public DateTime DateTime { get; set; }
        public int VenueId { get; set; }
        public Venue? Venue { get; set; }
        public int ArtistId { get; set; }
        public Artist? Artist { get; set; }
    }
}
