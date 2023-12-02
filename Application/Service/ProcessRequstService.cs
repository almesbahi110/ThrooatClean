using Application.Dtos.Requst;
using Application.Dtos.Response;
using Application.Interface;
using Application.Repository;
using AutoMapper;
using Domain.Entities;


namespace Application.Service
{
    public class ProcessRequstService : IProcessRequst
    {
        private readonly IProcessRequstRepository _processRequstRepository;
        private readonly IMapper _mapper;
        public ProcessRequstService(IProcessRequstRepository processRequstRepository, IMapper mapper)
        {
       this._processRequstRepository = processRequstRepository;
            this._mapper = mapper;
        }

     
        public async Task<ResponeProcessRequstDto> PostData(ProcessRequstRequstDTo data)
        {
            ResponeProcessRequstDto responeProcessRequstDto = new ResponeProcessRequstDto();
            try
            {

                var (state, Massage) = data.ValidteProcessRequest();
                if (state == 1)
                {
                    var qs = new ProcessRequest()
                    {
                      RequestDescraption= data.RequestDescraption,
                      DateBegin= DateTime.Now,
                      DateEnd= DateTime.Now,
                      EmployeeId= data.EmployeeId,
                      Note = data.Note,
                      ProcessRequestState = data.ProcessRequestState,
                      ProcessStagesId= data.ProcessStagesId,
                     
                         
                    };
                    
                    var (sss, Msg) = await _processRequstRepository.PostData(qs);
                    if (sss == 1)
                    {

                        responeProcessRequstDto.Success = true;
                        responeProcessRequstDto.Massage = "تم اضافه طلب العملية  بنجاح";
                        return responeProcessRequstDto;
                    }
                    else
                    {
                        responeProcessRequstDto.Success = false;
                        responeProcessRequstDto.Massage = "لم يتم اضافه  طلب العملية بنجاح";
                        return responeProcessRequstDto;
                    }
                }
                else
                {
                    responeProcessRequstDto.Success = false;
                    responeProcessRequstDto.Massage = Massage;
                    return responeProcessRequstDto;
                }

            }
            catch (Exception ex)
            {
                responeProcessRequstDto.Success = false;
                responeProcessRequstDto.Massage = "لم يتم اضافه طلب العملية بنجاح"+ex.Message;
                return responeProcessRequstDto;
            }
        }

        public async Task<ResponeProcessRequstDto> UpdateData(ProcessRequstRequstDTo processRequst)
        {
            var (state, Massage) = processRequst.ValidteProcessRequest();
            ResponeProcessRequstDto responeProcessRequstDto = new ResponeProcessRequstDto();
            try
            {

                if (state == 1)
                {
                    var q = new ProcessRequest()
                    {
                      ProcessRequestId= processRequst.ProcessRequestId,
                      RequestDescraption= processRequst.RequestDescraption,
                      ProcessStagesId= processRequst.ProcessStagesId,
                      ProcessRequestState = processRequst.ProcessRequestState,
                      DateBegin = processRequst.DateBegin,
                      DateEnd = processRequst.DateEnd,
                      EmployeeId= processRequst.EmployeeId,
                      Note = processRequst.Note,
                     
                     
                    };

                    var (ss, Msg) = await _processRequstRepository.UpdateData(q);
                    if (ss == 1)
                    {

                        responeProcessRequstDto.Success = true;
                        responeProcessRequstDto.Massage = "تم تعديل طلب العملية بنجاح";
                        return responeProcessRequstDto;
                    }
                    else
                    {
                        responeProcessRequstDto.Success = false;
                        responeProcessRequstDto.Massage = "لم يتم تعديل طلب العملية بنجاح";
                        return responeProcessRequstDto;
                    }
                }
                else
                {
                    responeProcessRequstDto.Success = false;
                    responeProcessRequstDto.Massage = Massage;
                    return responeProcessRequstDto;
                }
            }
            catch (Exception ex)
            {
                responeProcessRequstDto.Success = false;
                responeProcessRequstDto.Massage = "لم يتم تعديل طلب العملية بنجاح" + ex.Message;
                return responeProcessRequstDto;
            }
        }

        public async Task<IReadOnlyList<ProcessRequest>> GetAll()
        {
            var process = await _processRequstRepository.GetAll();
            return process;


        }
        public async Task<ResponeProcessRequstDto> Delete(int id)
        {

            var res = await _processRequstRepository.Delete(id);
            ResponeProcessRequstDto processRequstDto = new ResponeProcessRequstDto();
            processRequstDto.Success = res.Success;
            processRequstDto.Massage = res.Massage;
            return processRequstDto;

        }
        public async Task<ProcessRequest> GetProcessRequstById(int id)
        {
            var res = await _processRequstRepository.GetById(id);
            return res;
        }
    }
}
