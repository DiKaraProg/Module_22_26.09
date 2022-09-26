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
    public class UserRepository : IBaseRepository<User>
    {
        private readonly ApplicationDbContext dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Task<List<User>> Select()
        {
            return dbContext.User.ToListAsync();
        }

        public async Task<bool> Create(User entity)
        {
            await dbContext.User.AddAsync(entity);
            dbContext.SaveChanges();
            return true;
        }

        public async Task<bool> Delete(User entity)
        {
            dbContext.User.Remove(entity);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<User> Get(int id)
        {
            return await dbContext.User.FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task<User> GetByName(string name)
        {
            return await dbContext.User.FirstOrDefaultAsync(w => w.Name == name);

        }

        public async Task<User> Update(User entity)
        {
            dbContext.User.Update(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
