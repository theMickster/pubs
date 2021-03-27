using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Pubs.Application.Common.Interfaces;
using Pubs.SharedKernel.Entities;

namespace Pubs.Infrastructure
{
    public class SpecificationEvaluator<T> where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> specification)
        {
            var query = inputQuery;

            // modify the IQueryable using the specification's criteria expression
            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }

            // Includes all expression-based includes
            query = Enumerable.Aggregate<Expression<Func<T, object>>, IQueryable<T>>(specification.Includes, query,
                (current, include) => EntityFrameworkQueryableExtensions.Include<T, object>(current, include));

            // Include any string-based include statements
            query = Enumerable.Aggregate<string, IQueryable<T>>(specification.IncludeStrings, query,
                (current, include) => EntityFrameworkQueryableExtensions.Include<T>(current, include));

            // Apply ordering if expressions are set
            if (specification.OrderBy != null)
            {
                query = Queryable.OrderBy<T, object>(query, specification.OrderBy);
            }
            else if (specification.OrderByDescending != null)
            {
                query = Queryable.OrderByDescending<T, object>(query, specification.OrderByDescending);
            }

            if (specification.GroupBy != null)
            {
                query = Queryable.GroupBy<T, object>(query, specification.GroupBy).SelectMany(x => x);
            }

            // Apply paging if enabled
            if (specification.IsPagingEnabled)
            {
                query = query.Skip(specification.Skip)
                    .Take(specification.Take);
            }

            return query;
        }
    }
}