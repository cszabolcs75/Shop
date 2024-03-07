using Models;

namespace Logic
{
    public interface IProductLogic
    {
        void CreateProduct(Product product);
        void DeleteProduct(int Id);
        IQueryable<Product> ReadAllProduct();
        Product ReadProduct(int Id);
        void UpdateProduct(Product product);
    }
}