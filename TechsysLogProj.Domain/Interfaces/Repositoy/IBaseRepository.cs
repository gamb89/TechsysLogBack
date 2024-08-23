using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TechsysLogProj.Domain.Interfaces.Repositoy
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task  AddAsync(TEntity entity);   

        Task<TEntity> GetByIdAsync(string id);

        Task<IEnumerable<TEntity>> GetAll();

        Task DeleteOne(Expression<Func<TEntity, bool>> filterExpression);
    }
}
