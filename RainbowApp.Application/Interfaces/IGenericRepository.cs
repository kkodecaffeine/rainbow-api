﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace RainbowApp.Application.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(string mgtNo);
        Task<IEnumerable<T>> GetAll();
        //Task<int> Add(T entity);
        //Task<int> Delete(int id);
        //Task<int> Update(T entity);
    }
}
