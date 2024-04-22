using Entities_TK;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PracticeProjectUI_TK.Models.ViewModels
{
    public class CityViewModel
    {
        public int City_id { get; set; }
        public int Countryid { get; set; }
        public int state_id { get; set; }
        public string? City_name { get; set; }
        public string? StateName { get; set; }
        public string? Country_Name { get; set; }
        public IEnumerable<SelectListItem> countries { get; set; } = default!;
        public IEnumerable<SelectListItem> States { get; set; } = default!;
    }
}
