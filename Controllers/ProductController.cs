using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Product_API_DI.DataAccess.Interfaces;
using Product_API_DI.ExceptionHandling;
using Product_API_DI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Product_API_DI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("swagger")]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _repo;

        public ProductController(IProduct repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public List<Product> getProducts()
        {
            return (_repo.GetProducts());
        }
        [HttpGet("Id")]
        public Product getProductById(int Id)
        {
            return (_repo.ProductGetProductById(Id));
        }

        [HttpPost]
        public List<Product> createNewProduct(Product product)
        {
            return (_repo.CreateProducts(product));
        }
        [HttpDelete("Id")]
        public String DeleteStudent(int id)
        {
            return (_repo.DeleteProduct(id));
        }
        [HttpPut]
        public List<Product> updateProduct(Product product)
        {
            return (_repo.updateEmployee(product));
        }
    }
}
