using Models;

namespace Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        void CreateProduct(Product product);
        void DeleteProduct(int Id);
        Product GetOne(int Id);
        IQueryable<Product> ReadAllProduct();
        Product ReadProduct(int Id);
        void UpdateProduct(Product product);
    }
}