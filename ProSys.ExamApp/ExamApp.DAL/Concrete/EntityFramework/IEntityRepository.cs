using ExamApp.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.DAL.Concrete.EntityFramework
{
    public interface IEntityRepository<T> where T : class, IEntity,new()
    {
        Task<T> Get(Expression<Func<T, bool>> filter);
        Task<List<T>> GetAll(Expression<Func<T,bool>> filter = null);

        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
