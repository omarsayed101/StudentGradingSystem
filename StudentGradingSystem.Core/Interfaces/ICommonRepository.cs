using System.Linq.Expressions;

namespace StudentGradingSystem.Application.Interfaces
{
    public interface ICommonRepository<T> where T : class
    {
        Task<IQueryable<T>> GetAllWithFilterAsync(Expression<Func<T, bool>>? filter = null);
        Task<IQueryable<T>> GetAllWithFilterAndIncludesAsync(List<Expression<Func<T, object>>> includes, Expression<Func<T, bool>>? filter = null);

        Task<T> GetByIdAsync(int Id);
        Task<IQueryable<T>> OrderBy(IQueryable<T> Entities, Expression<Func<T, object>> orderby, bool isAscending = true);
        Task<IQueryable<T>> GetAllAsync();

        Task<T> Add(T Entity);
        Task<T> Update(T Entity);
        Task<bool> Delete(int Id);

        //Task<int> SaveChanges();

    }
}
