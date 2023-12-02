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
    public class ProcessStageService : IProcessStage
    {
        private readonly IProcessStageRepository _processStageRepository;
        private readonly IMapper _mapper;
        public ProcessStageService(IProcessStageRepository processStageRepository, IMapper mapper)
        {
       this._processStageRepository = processStageRepository;
            this._mapper = mapper;
        }

        public async Task<ResponeProcessStageDto> UpdateData(ProcessStagesRequstDTo data)
        {
            var (state, Massage) = data.ValidteProcessStages();
            ResponeProcessStageDto responeprocessStageDto = new ResponeProcessStageDto();
            try
            {

                if (state == true)
                {
                    var q = new ProcessStages()
                    {
                       Next=data.Next,
                       Order=data.Order,
                      ProcessId=data.ProcessId,
                      ProcessStagesId=data.ProcessStagesId,
                      StageId=data.StageId,
                    };

                    var (ss, Msg) = await _processStageRepository.UpdateData(q);
                    if (ss == 1)
                    {

                        responeprocessStageDto.Success = true;
                        responeprocessStageDto.Massage = "تم تعديل عملية المرحله بنجاح";
                        return responeprocessStageDto;
                    }
                    else
                    {
                        responeprocessStageDto.Success = false;
                        responeprocessStageDto.Massage = "لم يتم تعديل عملية المرحله بنجاح";
                        return responeprocessStageDto;
                    }
                }
                else
                {
                    responeprocessStageDto.Success = false;
                    responeprocessStageDto.Massage = Massage;
                    return responeprocessStageDto;
                }
            }
            catch (Exception ex)
            {
                responeprocessStageDto.Success = false;
                responeprocessStageDto.Massage = "لم يتم تعديل  عملية المرحله بنجاح" + ex.Message;
                return responeprocessStageDto;
            }
        }
        public async Task<IReadOnlyList<ProcessStages>> GetAll()
        {
            var stages = await _processStageRepository.GetAll();
            return stages;
        }
        public async Task<ProcessStages> GetProcessStageById(int id)
        {
            var res = await _processStageRepository.GetById(id);
            return res;
        }
        public async Task<ResponeProcessStageDto> PostData(ProcessStagesRequstDTo data)
        {
            ResponeProcessStageDto responeProcessStageDto = new ResponeProcessStageDto();
            try
            {

                var (state, Massage) = data.ValidteProcessStages();
                if (state == true)
                {
                    var qs = new ProcessStages()
                    {
                       StageId= data.StageId,
                       ProcessId= data.ProcessId,
                       Order= data.Order,
                       Next = data.Next

                         
                    };

                    var (sss, Msg) = await _processStageRepository.PostData(qs);
                    if (sss == 1)
                    {

                        responeProcessStageDto.Success = true;
                        responeProcessStageDto.Massage = "تم اضافه عملية المرحله بنجاح";
                        return responeProcessStageDto;
                    }
                    else
                    {
                        responeProcessStageDto.Success = false;
                        responeProcessStageDto.Massage = "لم يتم اضافه عملية المرحله بنجاح";
                        return responeProcessStageDto;
                    }
                }
                else
                {
                    responeProcessStageDto.Success = false;
                    responeProcessStageDto.Massage = Massage;
                    return responeProcessStageDto;
                }

            }
            catch (Exception ex)
            {
                responeProcessStageDto.Success = false;
                responeProcessStageDto.Massage = "لم يتم اضافه المرحله بنجاح"+ex.Message;
                return responeProcessStageDto;
            }
        }
     public async Task<ResponeProcessStageDto> Delete(int id)
        {

            var res = await _processStageRepository.Delete(id);
            ResponeProcessStageDto processstageResponseDto = new ResponeProcessStageDto();
            processstageResponseDto.Success = res.Success;
            processstageResponseDto.Massage = res.Massage;
            return processstageResponseDto;

        }

       
    }
}
