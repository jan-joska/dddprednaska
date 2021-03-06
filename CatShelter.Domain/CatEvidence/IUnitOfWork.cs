﻿using System;
using System.Linq;

namespace CatShelter.Domain.CatEvidence
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        T Get<T>(long id)
            where T : class;

        void SaveOrUpdate<T>(T entity);
        void Delete<T>(T entity);
        IQueryable<T> Query<T>();
        object CreateSQLQuery(string q);
        void Flush();
    }
}