﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Malabarista.Infra.Repositories
{
    public interface IRepository<T>
        {
            IQueryable<T> Get();
            T GetById(Expression<Func<T, bool>> predicate);
            void Add(T entity);
            void Update(T entity);
            void Delete(T entity);

        }
}
