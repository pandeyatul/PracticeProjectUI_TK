using Entities_TK.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PracticeProjectUI_TK.ViewComponents
{
    public class CountStateViewComponent : ViewComponent
    {
        private IState _state;

        public CountStateViewComponent(IState state)
        {
            _state = state;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var states =   _state.GetAllState();
            int noOfState =  states.Count();
            return View(noOfState);
        }
    }
}
