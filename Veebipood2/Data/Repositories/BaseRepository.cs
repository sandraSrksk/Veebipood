namespace Veebipood2.Data.Repositories
{
    public abstract class BaseRepository<T> where T : Entity
    {
        protected Veebipood2Context Context { get; private set; }

        public BaseRepository(Veebipood2Context context)
        {
            Context = context;
        }

        /*
         *   C R U D
         */
        public virtual async Task<PagedResult<T>> List(int page, int pageSize)
        {
            var result = await Context.Set<T>().GetPagedAsync(page, pageSize);

            return result;
        }

        public virtual async Task<T> GetById(int id)
        {
            var result = await Context.Set<T>().FindAsync(id);

            return result;
        }

        public virtual async Task Save(T list)
        {
            if (list.Id == 0)
            {
                await Context.AddAsync(list);
            }
            else
            {
                Context.Update(list);
            }
        }

        public virtual async Task Delete(int id)
        {
            var productType = await Context.Set<T>().FindAsync(id);
            if (productType != null)
            {
                Context.Set<T>().Remove(productType);
            }
        }
    }
}