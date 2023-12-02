using Application.Dtos.Requst;
using AutoMapper;
using Domain.Entities;
namespace Application.Mapper
{
    public class LibraryProfile : Profile
    {
        public LibraryProfile()
        {
            CreateMap<Stage, StageRequstDTo>().ReverseMap();
            
        }
    }
}
