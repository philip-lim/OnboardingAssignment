using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDCoreReact.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRUDCoreReact.Controllers
{
    //[Route("api/[controller]")]
    public class ProductController : Controller
    {
        DataAccessLayer obj = new DataAccessLayer();

        [HttpGet]
        [Route("api/Product/Index")]
        public IEnumerable<ProductModel> Index()
        {
            return obj.GetAllProducts();
        }

        [HttpPost]
        [Route("api/Product/Create")]
        public int Create(ProductModel product)
        {
            return obj.AddProduct(product);
        }

        [HttpGet]
        [Route("api/Product/Details/{id}")]
        public ProductModel Details(int id)
        {
            return obj.GetProductData(id);
        }

        [HttpPut]
        [Route("api/Product/Edit")]
        public int Edit(ProductModel product)
        {
            return obj.UpdateProduct(product);
        }

        [HttpDelete]
        [Route("api/Product/Delete/{id}")]
        public int Delete(int id)
        {
            return obj.DeleteProduct(id);
        }

    }
}

