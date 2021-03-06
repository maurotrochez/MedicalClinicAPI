﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.DataAccess
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);
        T GetById(long id);
        Task<T> GetByIdAsync(long id);
        void Add(T entity);
        void AddRange(T[] entities);
        void Update(T entity);
        void Delete(T entity);
        void Delete(long id);
        bool Save();
        Task<bool> SaveAsync();

    }
}
