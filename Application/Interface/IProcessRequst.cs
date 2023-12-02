using Application.Dtos.Requst;
using Application.Dtos.Response;
using Domain.Entities;
namespace Application.Interface
{
    public interface IProcessRequst
    {
        Task<ResponeProcessRequstDto> PostData(ProcessRequstRequstDTo procesRequst);
        Task<ResponeProcessRequstDto> UpdateData(ProcessRequstRequstDTo procesRequst);
        Task<IReadOnlyList<ProcessRequest>> GetAll();
        Task<ProcessRequest> GetProcessRequstById(int id);
        Task<ResponeProcessRequstDto> Delete(int id);
    }
}
