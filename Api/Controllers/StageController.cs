﻿using Application.Dtos.Requst;
using Application.Dtos.Response;
using Application.Interface;
using Application.Service;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StageController : ControllerBase
    {
        private readonly IStage _stageService;
       

   
        public StageController(IStage stageService)
        {
           this._stageService = stageService;
          
          
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            
           
             var res=await    _stageService.Delete(id);
            return Ok(res);
           

        }

        [HttpPost]
        public async Task<ActionResult> PostData(StageRequstDTo data)
        {
           
            ResponeStageDto res= await _stageService.PostData(data);
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
        public async Task<ActionResult> UpdateData(StageRequstDTo data)
        {
            ResponeStageDto res = await _stageService.UpdateData(data);

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
        public async Task<IReadOnlyList<Stage>> GetAll()
        {


            var ll = await _stageService.GetAll();

            return ll;
        }


        [HttpGet("{id}")]
        public Task<Stage> GetById(int id)
        {
            var res = _stageService.GetStageById(id);
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

