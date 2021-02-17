using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace F1Encyclopedia.Data
{
    public static class DbSetExtensionMethods
    {
        public static EntityEntry<T> AddIfNotExists<T>(this DbSet<T> dbSet, T entity, Expression<Func<T, bool>> predicate = null) where T : class, new()
        {
            var exists = predicate != null ? dbSet.Any(predicate) : dbSet.Any();
            if (exists)
            {
                Console.WriteLine($"Entity already exists: {entity.ToString()}");
            }
            return !exists ? dbSet.Add(entity) : null;
        }
    }
}
