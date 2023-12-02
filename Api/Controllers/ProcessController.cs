using Application.Dtos.Requst;
using Application.Dtos.Response;
using Application.Interface;
using Application.Service;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessController : ControllerBase
    {
        private readonly IProcess _ProcessService;
   
        public ProcessController(IProcess ProcessService)
        {
           this._ProcessService = ProcessService;   
          
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _ProcessService.Delete(id);
            return Ok(res);


        }

        [HttpPost]
        public async Task<ActionResult> PostData(ProcessRequstDTo data)
        {
            ResponeProcessDto res = await _ProcessService.PostData(data);
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
        public async Task<ActionResult> UpdateData(ProcessRequstDTo data)
        {
            ResponeProcessDto res = await _ProcessService.UpdateData(data);

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
        public async Task<IReadOnlyList<Process>> GetAll()
        {


            var ll = await _ProcessService.GetAll();

            return ll;
        }


        [HttpGet("{id}")]
        public async Task<Process> GetById(int id)
        {
            var res =await _ProcessService.GetProcessById(id);
          
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

