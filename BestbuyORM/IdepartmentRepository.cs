using System;
using System.Collections.Generic;
using System.Text;

namespace BestbuyORM
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAllDepartments(); //Stubbed out method

    }
}
