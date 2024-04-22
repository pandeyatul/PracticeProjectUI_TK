using Entities_TK;
using Entities_TK.Interface;
using Microsoft.EntityFrameworkCore;
using PracticeProjectUI_TK.Data;

namespace TK_Repository
{
    public class StateRepository : IState
    {
        private readonly ApplicationDbContext _context;

        public StateRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateState(State state)
        {
            _context?.stateTbl?.Add(state);
            _context?.SaveChanges();
        }

        public void DeleteState(int id)
        {
            var state = _context?.stateTbl?.ToList().FirstOrDefault(x => x.Id == id);
            if (state != null)
            {
                _context?.stateTbl?.Remove(state);
                _context?.SaveChanges();
            }
        }

        public List<State>? GetAllState()
        {
            var states = _context?.stateTbl?.Include(x => x.Countries).ToList();
            return states;
        }

        public void UpdateState(State state)
        {
            _context?.stateTbl?.Update(state);
            _context?.SaveChanges();
        }
    }
}