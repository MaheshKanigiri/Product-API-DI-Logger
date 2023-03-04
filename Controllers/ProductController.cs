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
    [EnableCors("angular")]
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
        [HttpGet]
        [Route("{id}")]
        public Product getProductById(int id)
        {
            try
            {
                return (_repo.ProductGetProductById(id));
            }
            catch (Exception ex)
            {
                throw new ResultNotFoundException("No Id Present!",ex);
            }
        }
            

        [HttpPost]
        public List<Product> createNewProduct(Product product)
        {
            return (_repo.CreateProducts(product));
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
            var message=_repo.DeleteProduct(id);
            return StatusCode(200,new {Message=message});
            }
            catch (Exception ex) { return NotFound("NO ID AVAILABLE!"); }
        }
        [HttpPut]
        [Route("{id}")]
        public List<Product> updateProduct(int id,Product product)
        {
            return (_repo.updateEmployee(id,product));
        }
    }
}



// +++++ [ baseUrl:https://localhost:7000/api ]++++++++
//[HttpGet]
//public List<Product> getProducts() {}
//SWAGGER: https://localhost:7000/api/Product
//return this.http.get<Product[]>(this.baseUrl + '/Product');

//[HttpGet]
//[Route("{id}")]
//public Product getProductById(int id){}
//SWAGGER:https://localhost:7000/api/Product/12
//return this.http.get<any>(this.baseUrl + '/Product/' + id);

//[HttpPut]
//[Route("{id}")]
//public List<Product> updateProduct(int id, Product product){}
//SWAGGER:https://localhost:7000/api/Product/12
//return this.http.put<Product>(this.baseUrl + '/Product/' + id, updateProductRequest)

//[HttpDelete]
//[Route("{id}")]
//public String DeleteStudent(int id){}
//SWAGGER:https://localhost:7000/api/Product/12
//return this.http.delete<Product>(this.baseUrl + '/Product/' + id)

//[HttpPost]
//public List<Product> createNewProduct(Product product)
//SWAGGER:https://localhost:7000/api/Product
//return this.http.post<Product>(this.baseUrl+'/Product/',addProductRequest)