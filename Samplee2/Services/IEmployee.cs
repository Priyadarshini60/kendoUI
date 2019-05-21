using Samplee2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samplee2.DAL
{
    public interface IEmployee
    {
        IEnumerable<EmployeeViewModel> GetEmployee();
        Employee_tbl GetEmployeeById(int id);
        Employee_tbl PostEmployee(EmployeeViewModel emp);
        Employee_tbl PutEmployee(int id, EmployeeViewModel emp);
        List<Employee_tbl> DeleteEmployee(int id);
    }
}
