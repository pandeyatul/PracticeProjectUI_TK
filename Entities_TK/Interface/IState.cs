using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_TK.Interface
{
    public interface IState
    {
        public List<State>? GetAllState();
        public void CreateState(State state);
        public void UpdateState(State state);
        public void DeleteState(int id);
    }
}
