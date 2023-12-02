using Application.Dtos.Requst;
using Application.Dtos.Response;
using Application.Interface;
using Application.Repository;
using AutoMapper;
using Domain.Entities;


namespace Application.Service
{
    public class ProcessService : IProcess
    {
        private readonly IProcessRepository _processRepository;
        private readonly IMapper _mapper;
        public ProcessService(IProcessRepository processRepository, IMapper mapper)
        {
       this._processRepository = processRepository;
            this._mapper = mapper;
        }

     
        public async Task<ResponeProcessDto> PostData(ProcessRequstDTo data)
        {
            ResponeProcessDto responeProcessDto = new ResponeProcessDto();
            try
            {

                var (state, Massage) = data.ValidteProcess();
                if (state == 1)
                {
                    var qs = new Process()
                    {
                      Instructions= data.Instructions,
                      ProcessName= data.ProcessName,
                      ProcessState= data.ProcessState,
                         
                    };
                    
                    var (sss, Msg) = await _processRepository.PostData(qs);
                    if (sss == 1)
                    {

                        responeProcessDto.Success = true;
                        responeProcessDto.Massage = "تم اضافه العملية  بنجاح";
                        return responeProcessDto;
                    }
                    else
                    {
                        responeProcessDto.Success = false;
                        responeProcessDto.Massage = "لم يتم اضافه العملية بنجاح";
                        return responeProcessDto;
                    }
                }
                else
                {
                    responeProcessDto.Success = false;
                    responeProcessDto.Massage = Massage;
                    return responeProcessDto;
                }

            }
            catch (Exception ex)
            {
                responeProcessDto.Success = false;
                responeProcessDto.Massage = "لم يتم اضافه العملية بنجاح"+ex.Message;
                return responeProcessDto;
            }
        }

        public async Task<ResponeProcessDto> UpdateData(ProcessRequstDTo processRequst)
        {
            var (state, Massage) = processRequst.ValidteProcess();
            ResponeProcessDto responeProcessDto = new ResponeProcessDto();
            try
            {

                if (state == 1)
                {
                    var q = new Process()
                    {
                      
                        ProcessState=processRequst.ProcessState,
                        ProcessName=processRequst.ProcessName,
                        Instructions               =processRequst.Instructions,
                        ProcessId=processRequst.Id
                    };

                    var (ss, Msg) = await _processRepository.UpdateData(q);
                    if (ss == 1)
                    {

                        responeProcessDto.Success = true;
                        responeProcessDto.Massage = "تم تعديل العملية بنجاح";
                        return responeProcessDto;
                    }
                    else
                    {
                        responeProcessDto.Success = false;
                        responeProcessDto.Massage = "لم يتم تعديل العملية بنجاح";
                        return responeProcessDto;
                    }
                }
                else
                {
                    responeProcessDto.Success = false;
                    responeProcessDto.Massage = Massage;
                    return responeProcessDto;
                }
            }
            catch (Exception ex)
            {
                responeProcessDto.Success = false;
                responeProcessDto.Massage = "لم يتم تعديل العملية بنجاح" + ex.Message;
                return responeProcessDto;
            }
        }

        public async Task<IReadOnlyList<Process>> GetAll()
        {
            var process = await _processRepository.GetAll();
            return process;


        }
        public async Task<ResponeProcessDto> Delete(int id)
        {

            var res = await _processRepository.Delete(id);
            ResponeProcessDto processDto = new ResponeProcessDto();
            processDto.Success = res.Success;
            processDto.Massage = res.Massage;
            return processDto;

        }
        public async Task<Process> GetProcessById(int id)
        {
            var res = await _processRepository.GetById(id);
            return res;
        }
    }
}
