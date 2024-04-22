using CleanArchitectureStudentData.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureStudentData.UnitOfWork
{
    public interface IUnitofWork
    {
        IGenericRepo<T> genericRepo<T>() where T:class;
        void Save();

    }
}
