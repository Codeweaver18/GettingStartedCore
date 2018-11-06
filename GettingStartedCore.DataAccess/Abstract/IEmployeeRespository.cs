using GettingStartedCore.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GettingStartedCore.DataAccess.Abstract
{
  public  interface IEmployeeRespository
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployee(int employeeId);
        IEnumerable<Task> GetEmployeeTasks(int employeeId);
        Task GetEmployeeTask(int taskId, int EmployeeId);
        void CreateEmployee(Employee emp);
    }
}
