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
    public class ProcessStageController : ControllerBase
    {
        private readonly IProcessStage _ProcessstageService;
   
        public ProcessStageController(IProcessStage processStageService)
        {
           this._ProcessstageService = processStageService;   
          
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            
           
             var res=await _ProcessstageService.Delete(id);
            return Ok(res);
           

        }

        [HttpPost]
        public async Task<ActionResult> PostData(ProcessStagesRequstDTo data)
        {
            ResponeProcessStageDto res= await _ProcessstageService.PostData(data);
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
        public async Task<ActionResult> UpdateData(ProcessStagesRequstDTo data)
        {
            ResponeProcessStageDto res = await _ProcessstageService.UpdateData(data);

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
        public async Task<IReadOnlyList<ProcessStages>> GetAll()
        {


            var ll = await _ProcessstageService.GetAll();

            return ll;
        }


        [HttpGet("{id}")]
        public Task<ProcessStages> GetById(int id)
        {
            var res = _ProcessstageService.GetProcessStageById(id);
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

