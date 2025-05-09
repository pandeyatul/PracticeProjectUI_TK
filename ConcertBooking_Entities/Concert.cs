﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertBooking_Entities
{
    public class Concert
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        public DateTime DateTime { get; set; }
        public int VenueId { get; set; }
        public Venue? Venue { get; set; }
        public int ArtistId { get; set; }
        public Artist? Artist { get; set; }
    }
}
