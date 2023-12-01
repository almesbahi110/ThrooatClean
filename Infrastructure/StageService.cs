using Application;
using Domain;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class StageService : IStage
    {
        private readonly AppDbContext _context;

        public StageService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> AddAsync(Stage entity)
        {
            await _context.Stages.AddAsync(entity);
            await _context.SaveChangesAsync();
            return "تم الاضافه بنجاح ";
        }
    }
}
