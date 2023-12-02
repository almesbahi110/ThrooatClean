using Application.Dtos.Requst;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Repository.Base.IRepository;

namespace Application.Repository
{
    public interface IProcessRepository : IRepository<Process>
    {

    }
}
