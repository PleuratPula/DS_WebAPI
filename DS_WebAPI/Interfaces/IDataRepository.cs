﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace DS_WebAPI.Interfaces
{
    public interface IDataRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Add(T t);
        Task<T> Get(int id);
        Task<T> Remove(int id);
        Task<T> Update(int id, T newT);
    }
}
