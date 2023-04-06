﻿using ModelAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ContactAPIRepository
{
    public interface  IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null,string? includeProperties = null,int pageSize = 0, int pageNumber = 1);
        Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true, string? includeProperties = null);
        Task CreateAsync(T entity);
        Task<IEnumerable<Contact>> SearchContactAsync(string Name);
        Task RemoveAsync(T entity);
        Task SaveAsync();

       
    }
}
 