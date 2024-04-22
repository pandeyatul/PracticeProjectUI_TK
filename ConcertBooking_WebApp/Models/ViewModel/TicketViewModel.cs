namespace ConcertBooking_WebApp.Models.ViewModel
{
    public class TicketViewModel
    {
        public int ConcertId { get; set; }
        public string? ConcertName { get; set; }
        public List<int>? AvailableSeats { get; set; }
    }
}
