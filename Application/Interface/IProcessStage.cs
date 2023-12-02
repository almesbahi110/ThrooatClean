using Application.Dtos.Requst;
using Application.Dtos.Response;
using Domain.Entities;
namespace Application.Interface
{
    public interface IProcessStage
    {
        Task<ResponeProcessStageDto> PostData(ProcessStagesRequstDTo stageRequst);
        Task<ResponeProcessStageDto> UpdateData(ProcessStagesRequstDTo stageRequst);
        Task<IReadOnlyList<ProcessStages>> GetAll();
        Task<ProcessStages> GetProcessStageById(int id);
        Task<ResponeProcessStageDto> Delete(int id);
    }
}
