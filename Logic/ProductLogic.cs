using Models;
using Repository;

namespace Logic
{
    public class ProductLogic : IProductLogic
    {
        IProductRepository ProductRepository;
        public ProductLogic(IProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }


        public void CreateProduct(Product product)
        {
            if (String.IsNullOrEmpty(product.Id.ToString()) || String.IsNullOrEmpty(product.Name) || String.IsNullOrEmpty(product.Price.ToString()))
            {
                throw new ArgumentException("Value cannot be null");
            }
            else
            {
                var HasItem = from products in ProductRepository.GetAll() where products.Id == product.Id select products.Id;

                if (HasItem.Count() > 0)
                {
                    throw new ArgumentException("Already Exist");
                }
                else
                {
                    ProductRepository.CreateProduct(product);
                }
            }
        }

        public void DeleteProduct(int Id)
        {
            try
            {
                ReadProduct(Id);
                ProductRepository.DeleteProduct(Id);
            }
            catch (Exception)
            {

                throw new KeyNotFoundException();
            }
        }


        public IQueryable<Product> ReadAllProduct()
        {
            return ProductRepository.ReadAllProduct();
        }

        public Product ReadProduct(int Id)
        {
            var HasItem = from products in ProductRepository.GetAll() where products.Id == Id select products.Id;

            if (HasItem.Count() > 0)
            {
                return ProductRepository.ReadProduct(Id);
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }
        public void UpdateProduct(Product product)
        {
            if (String.IsNullOrEmpty(product.Id.ToString()) || String.IsNullOrEmpty(product.Name) || String.IsNullOrEmpty(product.Price.ToString()))
            {
                throw new ArgumentException("Value cannot be null");
            }
            else
            {
                try
                {
                    ReadProduct(product.Id);
                    ProductRepository.UpdateProduct(product);
                }
                catch (Exception)
                {

                    throw new KeyNotFoundException();
                }
            }
        }
    }
}
