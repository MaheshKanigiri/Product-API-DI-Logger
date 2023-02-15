using Product_API_DI.Models;

namespace Product_API_DI.DataAccess.Interfaces
{
    public interface IProduct
    {
        //GET-PRODUCTS
        List<Product> GetProducts();
        //GET-PRODUCTS-BY-ID
        Product ProductGetProductById(int id);
        //CREATE[POST]-NEW-PRODUCT
        List<Product> CreateProducts(Product product);
        //DELETE-PRODUCT
        string DeleteProduct(int id);
        //UPDATE-[PUT] PRODUCT
        List<Product> updateEmployee(Product product);

    }
}
