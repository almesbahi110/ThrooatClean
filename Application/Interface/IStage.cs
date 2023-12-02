using Application.Dtos.Requst;
using Application.Dtos.Response;
using Domain.Entities;
namespace Application.Interface
{
    public interface IStage
    {
        Task<ResponeStageDto> PostData(StageRequstDTo stageRequst);
        Task<ResponeStageDto> UpdateData(StageRequstDTo stageRequst);
        Task<IReadOnlyList<Stage>> GetAll();
        Task<Stage> GetStageById(int id);
        Task<ResponeStageDto> Delete(int id);
    }
}
