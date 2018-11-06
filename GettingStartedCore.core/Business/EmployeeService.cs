using GettingStartedCore.core.Abstract;
using GettingStartedCore.DataAccess.Abstract;
using GettingStartedCore.DataAccess.Entities;
using GettingStartedCore.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace GettingStartedCore.core.Business
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IEmployeeRespository  _employeeRepo;

        public EmployeeService(IEmployeeRespository emp)
        {
            _employeeRepo = emp;
        }

        public void CreateEmployee(Employee emp)
        {
            _employeeRepo.CreateEmployee(emp);
        }

        public IList<Employee> GetEmployee()
        {
            IList<Employee> Result = null;
            try
            {
                _employeeRepo.GetEmployees();
            }
            catch (Exception ex)
            {

                //TODO always logg using sirilog or nlogger
            }


            return Result;
        }
    }
}
