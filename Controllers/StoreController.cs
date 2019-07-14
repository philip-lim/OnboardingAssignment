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
    public class StoreController : Controller
    {
        DataAccessLayer obj = new DataAccessLayer();

        [HttpGet]
        [Route("api/Store/Index")]
        public IEnumerable<StoreModel> Index()
        {
            return obj.GetAllStores();
        }

        [HttpPost]
        [Route("api/Store/Create")]
        public int Create(StoreModel store)
        {
            return obj.AddStore(store);
        }

        [HttpGet]
        [Route("api/store/Details/{id}")]
        public StoreModel Details(int id)
        {
            return obj.GetStoreData(id);
        }

        [HttpPut]
        [Route("api/Store/Edit")]
        public int Edit(StoreModel store)
        {
            return obj.UpdateStore(store);
        }

        [HttpDelete]
        [Route("api/Store/Delete/{id}")]
        public int Delete(int id)
        {
            return obj.DeleteStore(id);
        }


    }
}

