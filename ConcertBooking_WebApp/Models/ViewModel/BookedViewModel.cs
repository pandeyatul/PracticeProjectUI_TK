namespace ConcertBooking_WebApp.Models.ViewModel
{
    public class BookedViewModel
    {
        public int BookingId { get; set; }
        public DateTime BookingDate { get; set; }
        public string? ConcertName { get; set; }
        public List<MyTicketViewModel> mytickets { get; set; } = new List<MyTicketViewModel>();
    }
}
