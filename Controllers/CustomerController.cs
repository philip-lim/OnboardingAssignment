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
    public class CustomerController : Controller
    {
        DataAccessLayer obj = new DataAccessLayer();

        // GET: api/<controller>
        [HttpGet]
        [Route("api/Customer/Index")]
        public IEnumerable<CustomerModel> Index()
        {
            return obj.GetAllCustomers();
        }

        [HttpPost]
        [Route("api/Customer/Create")]
        public int Create(CustomerModel customer)
        {
            return obj.AddCustomer(customer);
        }

        [HttpGet]
        [Route("api/Customer/Details/{id}")]
        public CustomerModel Details(int id)
        {
            return obj.GetCustomerData(id);
        }

        [HttpPut]
        [Route("api/Customer/Edit/")]
        public int Edit(CustomerModel customer)
        {
            return obj.UpdateCustomer(customer);
        }

        [HttpDelete]
        [Route("api/Customer/Delete/{id}")]
        public int Delete(int id)
        {
            return obj.DeleteCustomer(id);
        }
    }
}
