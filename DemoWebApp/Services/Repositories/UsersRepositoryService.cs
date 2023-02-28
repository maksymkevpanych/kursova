using DemoWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoWebApp.Services.Repositories
{
    public class UsersRepositoryService : IRepository<User>
    {
        private readonly ApplicationDbContext context;

        public UsersRepositoryService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public User Create(User entity)
        {
            var entityEntry = context.Users.Add(entity);
            context.SaveChanges();

            return entityEntry.Entity;
        }

        public void Delete(int id)
        {
            var entity = context.Users.FirstOrDefault(user => user.Id == id);
            context.Remove(entity);
            context.SaveChanges();
        }

        public List<User> Read()
        {
            return context.Users.ToList();
        }

        public User Read(int id)
        {
            return context.Users.FirstOrDefault(user => user.Id == id);
        }

        public void Update(User entity)
        {
            context.Users.Update(entity);
            context.SaveChanges();
        }
    }
}
