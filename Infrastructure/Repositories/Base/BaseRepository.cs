using Application.Dtos.Response;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using static Application.Repository.Base.IRepository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infrastructure.Repositories.Base
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {

        private readonly AppDbContext _dbContext;

        public BaseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<(int, string)> PostData(T entity)
        {
            try
            {
                var result = await _dbContext.Set<T>().AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return(1, "تم الاضافه بنجاح");
            }
            catch(Exception ex) {
                return (0, "عذرا لم تتم الاضافه");
            }

        }


        public async Task<T> GetById(int id)
        {
            return await  _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<(int, string)> UpdateData(T entity)
        {
            try
            {
               


                _dbContext.Entry(entity).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return (1, "تم التعديل بنجاح");
            }
            catch (Exception ex)
            {
                return (0, "عذرا لم تتم التعديل");
            }

        }


      

      public  async Task<BaseResponse> Delete(int id)
        {
         var ww=await   GetById(id);
            if (ww != null)
            {
                var res = _dbContext.Set<T>().Remove(ww);
                await _dbContext.SaveChangesAsync();
                BaseResponse baseResponse = new()
                {
                    Success = true,
                    Massage = "تم الحذف بنجاح"
                };
            return baseResponse;
            }
            else
            {
                BaseResponse baseResponse = new()
                {
                    Success= false,
                    Massage = "عذراً لم يتم الحذف بنجاح"
                };
                return baseResponse;
            }


        }
    }
}
