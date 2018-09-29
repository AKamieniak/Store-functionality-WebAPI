using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCore.Models;
using WebApiCore.Repository;

namespace WebApiCore.Controllers
{
    [Route("api/shops")]
    [Produces("application/json")]
    public class ShopsController : Controller
    {
        private IShopsRepository _shopsRepository;

        public ShopsController(IShopsRepository shopsRepository)
        {
            _shopsRepository = shopsRepository;
        }

        // GET api/shops/get-last-index
        /// <summary>
        /// Get last index of shop.
        /// </summary>
        [Route("get-last-index")]
        [HttpGet]
        public int GetLastIndex()
        {
            //---get last index of shop---
            return _shopsRepository.GetLastIndexOfShop();
        }

        // GET api/shops/get-by-city
        /// <summary>
        /// Get shops with same city.
        /// </summary>
        [Route("get-by-city/{city}")]
        [HttpGet]
        public List<Shop> GetShopsByCity(string city)
        {
            return _shopsRepository.GetShopsByCity(city);
        }

        // GET: api/shops/get-all
        /// <summary>
        /// Get all shops.
        /// </summary>
        [Route("get-all")]
        [HttpGet]
        public List<Shop> GetShopsAll()
        {
            //---get all shops from SQL database---
            return _shopsRepository.GetShopsAll();
        }

        // POST: api/shops/add
        /// <summary>
        /// Add a shop.
        /// </summary>
        [Route("add")]
        [HttpPost]
        public void AddShop([FromBody]Shop shop)
        {
            _shopsRepository.AddShop(shop);
        }

        // DELETE: api/shops/delete/{0}
        /// <summary>
        /// Deletes a shop by ID.
        /// </summary>
        [Route("delete/{id}")]
        [HttpDelete]
        public void DeleteShop(int id)
        {
            _shopsRepository.DeleteShop(id);
        }
    }
}
