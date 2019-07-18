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
    public class SalesController : Controller
    {
        DataAccessLayer obj = new DataAccessLayer();

        // GET: api/<controller>
        [HttpGet]
        [Route("api/Sales/Index")]
        public IEnumerable<SalesModel> Index()
        {
            return obj.GetAllSales();
        }

        [HttpPost]
        [Route("api/Sales/Create")]
        public int Create(SalesModel sales)
        {
            return obj.AddSale(sales);
        }

        [HttpGet]
        [Route("api/Sales/Details/{id}")]
        public SalesModel Details(int id)
        {
            return obj.GetSaleData(id);
        }

        [HttpPut]
        [Route("api/Sales/Edit")]
        public int Edit(SalesModel sales)
        {
            return obj.UpdateSale(sales);
        }

        [HttpDelete]
        [Route("api/Sales/Delete/{id}")]
        public int Delete(int id)
        {
            return obj.DeleteSale(id);
        }

        [HttpGet]
        [Route("api/Store/GetStoreName")]
        public IEnumerable<StoreModel> DetailsStoreName()
        {
            return obj.GetStore();
        }

        [HttpGet]
        [Route("api/Product/GetProductName")]
        public IEnumerable<ProductModel> DetailsProductName()
        {
            return obj.GetProduct();
        }

        [HttpGet]
        [Route("api/Customer/GetCustomerName")]
        public IEnumerable<CustomerModel> DetailCustomerName()
        {
            return obj.GetCustomer();
        }
    }
}
