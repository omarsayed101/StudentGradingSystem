using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using StudentGradingSystem.Context;

namespace StudentGradingSystem.Repository
{
    public abstract class CommonRepository<T> : ICommonRepository<T> where T : class
    {
        private readonly ApplicationContext dbcontext;

        public CommonRepository(ApplicationContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task<T> Add(T Entity)
        {
           await dbcontext.AddAsync(Entity);
          int result =   dbcontext.SaveChanges();
            return result>0?Entity:null;
        }

        public async Task<bool> Delete(int Id)
        {
            var Entity  = await dbcontext.Set<T>().FindAsync(Id);
            dbcontext.Remove(Entity);
          int res =   dbcontext.SaveChanges();

            return res>0 ;

        }

        public async  Task<IQueryable<T>> GetAllAsync()
        {
            return dbcontext.Set<T>();
        }

        public  async Task<IQueryable<T>> GetAllWithFilterAndIncludesAsync(List<Expression<Func<T, object>>> includes, Expression<Func<T, bool>>? filter = null)
        {
           var query = (IQueryable<T>) dbcontext.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }

            }
            return query;
        }

        public async Task<IQueryable<T>> GetAllWithFilterAsync(Expression<Func<T, bool>> filter = null)
        {
            var query = (IQueryable<T>) dbcontext.Set<T>();

            if (filter != null)
                query = query.Where(filter);
             
            return query;
        }

  

        public async Task<T> GetByIdAsync(int Id)
        {
            return await  dbcontext.Set<T>().FindAsync(Id);
        }

        public async Task<IQueryable<T>> OrderBy(IQueryable<T> Entities, Expression<Func<T, object>> orderby, bool isAscending = true)
        {
            if (!isAscending)
                return Entities.OrderByDescending(orderby);

            return Entities.OrderBy(orderby);
        }

        public  async Task<T> Update(T Entity)
        {
            dbcontext.Update(Entity);
          int result =  dbcontext.SaveChanges();

            return result>0?Entity : null ;
        }


    }
}
