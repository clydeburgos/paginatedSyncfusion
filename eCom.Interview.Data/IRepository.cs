using eCom.Interview.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eComEngine.Interview.Data
{
    public interface IRepository<T>
    {
        Task<T> Single(Guid id);
        

        Task<IQueryable<T>> Where(Expression<Func<T, bool>> selector);

        Task<IQueryable<EmailTemplate>> Where(Expression<Func<EmailTemplate, bool>> selector,
                                              Expression<Func<IQueryable<EmailTemplate>, IQueryable<EmailTemplate>>> orderBy);
    }
}
