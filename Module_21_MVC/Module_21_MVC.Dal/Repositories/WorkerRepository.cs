using Microsoft.EntityFrameworkCore;
using Module_21_MVC.Dal.Interfaces;
using Module_21_MVC_Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_21_MVC.Dal.Repositories
{
    public class WorkerRepository : IBaseRepository<Worker>
    {
        private readonly ApplicationDbContext dbContext;

        public WorkerRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Task<List<Worker>> Select()
        {
            return dbContext.Worker.ToListAsync();
        }

        public  async Task<bool> Create(Worker entity)
        {
            await dbContext.Worker.AddAsync(entity);
            dbContext.SaveChanges();
            return true;
        }

        public async Task<bool> Delete(Worker entity)
        {
            dbContext.Worker.Remove(entity);
            dbContext.SaveChanges();
            return true;
        }

        public async Task<Worker> Get(int id)
        {
            var worker = await dbContext.Worker.FirstOrDefaultAsync(w => w.Id == id);
            return worker;
        }

        public async Task<Worker> GetByName(string name)
        {
            return await dbContext.Worker.FirstOrDefaultAsync(w => w.Name == name);

        }

        public async Task<Worker> Update(Worker entity)
        {
            dbContext.Worker.Update(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
