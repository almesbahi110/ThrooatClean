using Application.Dtos.Requst;
using Application.Dtos.Response;
using Domain.Entities;
namespace Application.Interface
{
    public interface IProcess
    {
        Task<ResponeProcessDto> PostData(ProcessRequstDTo processRequst);
        Task<ResponeProcessDto> UpdateData(ProcessRequstDTo processRequst);
        Task<IReadOnlyList<Process>> GetAll();
        Task<Process> GetProcessById(int id);
        Task<ResponeProcessDto> Delete(int id);
    }
}
