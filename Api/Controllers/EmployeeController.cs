using Application.Dtos.Requst;
using Application.Dtos.Response;
using Application.Interface;
using Application.Service;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employeeService;

        public EmployeeController(IEmployee employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {


            var res = await _employeeService.Delete(id);
            return Ok(res);


        }

        [HttpPost]
        public async Task<ActionResult> PostData(EmployeeRequstDTo data)
        {
            ResponeEmployeeDto res = await _employeeService.PostData(data);
            if (res.Success == true)
            {
                return Ok(res.Massage);
            }
            else
            {
                return BadRequest(res.Massage);
            }



        }


        [HttpPut]
        public async Task<ActionResult> UpdateData(EmployeeRequstDTo data)
        {
            ResponeEmployeeDto res = await _employeeService.UpdateData(data);

            if (res.Success == true)
            {
                return Ok(res.Massage);
            }
            else
            {
                return BadRequest(res.Massage);
            }

        }
        [HttpGet]
        public async Task<IReadOnlyList<Employee>> GetAll()
        {
         
         
           var ll= await _employeeService.GetAll();

            return ll;
        }
        [HttpGet("{id}")]
        public Task<Employee> GetById(int id)
        {
            var res = _employeeService.GetEmployeeById(id);
            if (res != null)
            {
                return res;
            }
            else
            {
                return res;
            }

        }
    }
}
