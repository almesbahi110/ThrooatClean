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
    public class ProcessRequstController : ControllerBase
    {
        private readonly IProcessRequst _ProcessRequstService;
   
        public ProcessRequstController(IProcessRequst ProcessRequstService)
        {
           this._ProcessRequstService = ProcessRequstService;   
          
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _ProcessRequstService.Delete(id);
            return Ok(res);


        }

        [HttpPost]
        public async Task<ActionResult> PostData(ProcessRequstRequstDTo data)
        {
            ResponeProcessRequstDto res = await _ProcessRequstService.PostData(data);
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
        public async Task<ActionResult> UpdateData(ProcessRequstRequstDTo data)
        {
            ResponeProcessRequstDto res = await _ProcessRequstService.UpdateData(data);

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
        public async Task<IReadOnlyList<ProcessRequest>> GetAll()
        {


            var ll = await _ProcessRequstService.GetAll();

            return ll;
        }


        [HttpGet("{id}")]
        public async Task<ProcessRequest> GetById(int id)
        {
            var res =await  _ProcessRequstService.GetProcessRequstById(id);
          
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

