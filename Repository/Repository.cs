namespace Repository
{
    abstract public class Repository<T> : IRepository<T> where T : class
    {
        protected ProductManagementDBContext ctx;

        public Repository(ProductManagementDBContext ctx)
        {
            this.ctx = ctx;
        }

        public IQueryable<T> GetAll()
        {
            return ctx.Set<T>();
        }

        public void Create(T entity)
        {
            ctx.Set<T>().Add(entity);
            ctx.SaveChanges();
        }

        public void Delete(T entity)
        {
            ctx.Set<T>().Remove(entity);
            ctx.SaveChanges();
        }

        public abstract T GetOne(int Id);
    }
}
