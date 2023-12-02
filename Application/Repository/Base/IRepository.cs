using Application.Dtos.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.Base
{
    public interface IRepository
    {
        public interface IRepository<T> where T : class
        {

            Task<(int, String)>  PostData(T entity);
            Task<(int, String)> UpdateData(T entity);
            Task<IReadOnlyList<T>> GetAll();
            Task<T> GetById(int id);
           Task<BaseResponse>  Delete(int id);


        }
    }
}
