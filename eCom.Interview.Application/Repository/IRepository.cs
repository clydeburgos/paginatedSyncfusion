using eCom.Interview.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eCom.Interview.Application.Repository
{
    public interface IRepository<T>
    {
        Task<T> Single(Guid id);

        Task<IQueryable<T>> Where(Expression<Func<T, bool>> selector);

        Task<IQueryable<EmailTemplate>> Where(Expression<Func<EmailTemplate, bool>> selector,
                                              Expression<Func<IQueryable<EmailTemplate>, IQueryable<EmailTemplate>>> orderBy);
    }
}
