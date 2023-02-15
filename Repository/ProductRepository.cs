using Product_API_DI.DataAccess;
using Product_API_DI.DataAccess.Interfaces;
using Product_API_DI.ExceptionHandling;
using Product_API_DI.Models;

namespace Product_API_DI.Repository
{
    public class ProductRepository : IProduct
    {
        private readonly ProductdbContext _context;

        public ProductRepository(ProductdbContext context)
        {
            _context = context;
        }
        //GET-IMP
        public List<Product> CreateProducts(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return _context.Products.ToList();
        }

        public string DeleteProduct(int id)
        {
           
            var product = _context.Products.Find(id);
            if (product == null)
            {
                throw new ResultNotFoundException("Product with ID:" + id + " Not Found");
            }
            _context.Products.Remove(product);
            _context.SaveChanges();

            return "Deleted successfully";
        }

        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public Product ProductGetProductById(int id)
        {
            var prod = _context.Products.Find(id);
            if (prod == null)
            {
                throw new ResultNotFoundException("Product with ID:" + id + " Not Found");
            }
            else { return (prod); };
        }

        public List<Product> updateEmployee(Product product)
        {
            var oldProduct = _context.Products.Find(product.Id);
            if (oldProduct == null)
            {
                throw new ResultNotFoundException("Product not Found!");
            }

            oldProduct.ProductName = product.ProductName;
            oldProduct.ProductPrice = product.ProductPrice;
            oldProduct.ProductDescription = product.ProductDescription;
            oldProduct.ProductCategory = product.ProductCategory;

            _context.SaveChanges();

            return _context.Products.ToList();

        }
    }
}
