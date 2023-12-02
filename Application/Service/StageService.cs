using Application.Dtos.Requst;
using Application.Dtos.Response;
using Application.Interface;
using Application.Repository;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class StageService : IStage
    {
        private readonly IStageRepository _stageRepository;
        private readonly IMapper _mapper;
        public StageService(IStageRepository stageRepository, IMapper mapper)
        {
       this._stageRepository = stageRepository;
            this._mapper = mapper;
        }

        public async Task<ResponeStageDto> UpdateData(StageRequstDTo data)
        {
            var (state, Massage) = data.ValidateStage();
            ResponeStageDto responeStageDto = new ResponeStageDto();
            try
            {

                if (state == true)
                {
                    var q = new Stage()
                    {
                        description=data.description,
                        Employee=data.Employee,
                        EmployeeId=data.EmployeeId,
                        Id=data.Id,
                        Name = data.Name,
                      title = data.title    
                    };

                    var (ss, Msg) = await _stageRepository.UpdateData(q);
                    if (ss == 1)
                    {

                        responeStageDto.Success = true;
                        responeStageDto.Massage = "تم تعديل المرحله بنجاح";
                        return responeStageDto;
                    }
                    else
                    {
                        responeStageDto.Success = false;
                        responeStageDto.Massage = "لم يتم تعديل المرحله بنجاح";
                        return responeStageDto;
                    }
                }
                else
                {
                    responeStageDto.Success = false;
                    responeStageDto.Massage = Massage;
                    return responeStageDto;
                }
            }
            catch (Exception ex)
            {
                responeStageDto.Success = false;
                responeStageDto.Massage = "لم يتم تعديل المرحله بنجاح" + ex.Message;
                return responeStageDto;
            }
        }
        public async Task<IReadOnlyList<Stage>> GetAll()
        {
            var stages = await _stageRepository.GetAll();
            return stages;


        }
        public async Task<Stage> GetStageById(int id)
        {
            var res = await _stageRepository.GetById(id);
            return res;
        }
        public async Task<ResponeStageDto> PostData(StageRequstDTo data)
        {
            ResponeStageDto responeStageDto = new ResponeStageDto();
            try
            {

                var (state, Massage) = data.ValidateStage();
                if (state == true)
                {
                    var qs = new Stage()
                    {
                        description=data.description,
                        Employee=data.Employee,
                        EmployeeId=data.EmployeeId,
                         Id=data.Id,
                         Name = data.Name,
                         title = data.title 
                         
                    };

                    var (sss, Msg) = await _stageRepository.PostData(qs);
                    if (sss == 1)
                    {

                        responeStageDto.Success = true;
                        responeStageDto.Massage = "تم اضافه المرحله بنجاح";
                        return responeStageDto;
                    }
                    else
                    {
                        responeStageDto.Success = false;
                        responeStageDto.Massage = "لم يتم اضافه المرحله بنجاح";
                        return responeStageDto;
                    }
                }
                else
                {
                    responeStageDto.Success = false;
                    responeStageDto.Massage = Massage;
                    return responeStageDto;
                }

            }
            catch (Exception ex)
            {
                responeStageDto.Success = false;
                responeStageDto.Massage = "لم يتم اضافه المرحله بنجاح"+ex.Message;
                return responeStageDto;
            }
        }
     public async Task<ResponeStageDto> Delete(int id)
        {

            var res = await _stageRepository.Delete(id);
            ResponeStageDto stageDto= new ResponeStageDto();
            stageDto.Success = res.Success;
            stageDto.Massage = res.Massage;
            return stageDto;

        }

    }
}
