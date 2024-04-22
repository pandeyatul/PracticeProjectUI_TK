using Microsoft.AspNetCore.Mvc.Rendering;

namespace PracticeProjectUI_TK.Models.ViewModels
{
    public class StateViewModel
    {
        public int StateId { get; set; }
        public int Country_ID { get; set; }
        public string? State_Name { get; set; }
        public string? Country_Name { get; set; }
        public IEnumerable<SelectListItem> Countrys { get; set; } = default!;
    }
}
