using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GettingStartedCore.DataAccess.Abstract;
using GettingStartedCore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace GettingStartedCore.DataAccess.Repositories
{
    public class EmployeeRepository : IEmployeeRespository
    {
        private readonly GettingStartedContext _ctx;
        public EmployeeRepository(GettingStartedContext ctx)
        {
            _ctx = ctx;
        }

        public void CreateEmployee(Employee emp)
        {
            _ctx.Employees.Add(emp);
            _ctx.SaveChanges();
        }

        public Employee GetEmployee(int employeeId)
        {
            return _ctx.Employees.Include(x=>x.Tasks)
                .Where(x=>x.Id==employeeId).OrderBy(x => x.Name).FirstOrDefault();
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _ctx.Employees.OrderBy(x => x.Name).ToList();
        }

        public Task GetEmployeeTask(int taskId, int EmployeeId)
        {

            return _ctx.Tasks
                .Where(x => x.Id == taskId &&  x.EmployeeId==EmployeeId).FirstOrDefault();
        }

        public IEnumerable<Task> GetEmployeeTasks(int employeeId)
        {
            return _ctx.Tasks
                 .Where(x => x.EmployeeId == employeeId).ToList();
        }
    }
}
