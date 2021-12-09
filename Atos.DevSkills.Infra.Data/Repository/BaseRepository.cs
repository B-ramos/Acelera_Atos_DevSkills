﻿using Atos.DevSkills.Domain.IRepository;
using Atos.DevSkills.Domain.Model;
using Atos.DevSkills.Infra.Data.Context;

namespace Atos.DevSkills.Infra.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : ModelBase
    {
        protected readonly DevSkillsContext _context;

        public BaseRepository(DevSkillsContext context)
        {
            _context = context;
        }

        public async Task<T> Add(T model)
        {
            _context.Set<T>().Add(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public Task Delete(T model)
        {
            throw new NotImplementedException();
        }

        public Task<T> FindById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> ListAllActive()
        {
            throw new NotImplementedException();
        }

        public Task<T> Update(T model)
        {
            throw new NotImplementedException();
        }
    }
}