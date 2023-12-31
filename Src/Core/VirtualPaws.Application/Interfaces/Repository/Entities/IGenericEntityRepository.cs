﻿using VirtualPaws.Domain.Common;

namespace VirtualPaws.Application.Interfaces.Repository.Entities
{
    public interface IGenericEntityRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(UInt16 id);
        void Delete(T entity);
        void Update(T entity);
        void Create(T entity);

    }
}
