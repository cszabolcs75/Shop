using Models;

namespace Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ProductManagementDBContext ctx) : base(ctx)
        {

        }

        public void CreateProduct(Product product)
        {
            Product tmp = new Product() { Id = product.Id, Name = product.Name, Price = product.Price };
            Create(tmp);
            ctx.SaveChanges();
        }

        public void DeleteProduct(int Id)
        {
            Delete(GetOne(Id));
            ctx.SaveChanges();
        }

        public override Product GetOne(int Id)
        {
            return GetAll().SingleOrDefault(x => x.Id == Id);
        }

        public  IQueryable<Product> ReadAllProduct()
        {
            return GetAll();
        }

        public Product ReadProduct(int Id)
        {
            return GetOne(Id);
        }

        public void UpdateProduct(Product product)
        {
            var ToUpdate = GetOne(product.Id);
            ToUpdate.Name = product.Name;
            ToUpdate.Price = product.Price;
            ctx.SaveChanges();
        }
    }
}
