using ConcertBooking_Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConcertBooking_WebApp.Models.ViewModel
{
    public class ConcertViewModel
    {
        public int Id { get; set; }
        public string? Concert_Name { get; set; }
        public string? VenueName { get; set; }
        public string? Description { get; set; }
        public DateTime DateTime { get; set; }
        public string? ImageUrl { get; set; }
        public string? ArtistName { get; set; }
        public string? VenueAddress { get; set; }
        public string? ArtistImageUrl { get; set; }
    }
}
