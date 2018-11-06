using GettingStartedCore.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GettingStartedCore.core.Abstract
{
    public interface IEmployeeService
    {
        IList<Employee> GetEmployee();
        void CreateEmployee(Employee emp);
    }
}
