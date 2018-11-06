using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GettingStartedCore.core.Abstract;
using GettingStartedCore.DataAccess.Entities;
using GettingStartedCore.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GettingStartedCore.Controllers
{
    [Route("api/Account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public AccountController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        [Route("Register")]
        public async Task<string> Register()
        {
            
            var Response = string.Empty;
            var Emp = AutoMapper.Mapper.Map<Employee>(new EmployeeDTO { Name = "Matsumu Monday", Age = "30" });
            _employeeService.CreateEmployee(Emp);
            Response = "succesfull";
            return Response;
        }
    }
}