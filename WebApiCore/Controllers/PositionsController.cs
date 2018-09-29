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
    [Route("api/positions")]
    [Produces("application/json")]
    public class PositionsController : Controller
    {
        private IPositionsRepository _positionsRepository;

        public PositionsController(IPositionsRepository positionsRepository)
        {
            _positionsRepository = positionsRepository;
        }

        // GET api/positions/get-last-index
        /// <summary>
        /// Get last index of position.
        /// </summary>
        [Route("get-last-index")]
        [HttpGet]
        public int GetLastIndex()
        {
            //---get last index of position---
            return _positionsRepository.GetLastIndexOfPosition();
        }

        // GET: api/positions/get-all
        /// <summary>
        /// Get all positions.
        /// </summary>
        [Route("get-all")]
        [HttpGet]
        public List<Position> GetPositionsAll()
        {
            //---get all positons names from SQL database---
            return _positionsRepository.GetPositionsAll();
        }

        // POST: api/positions/add
        /// <summary>
        /// Add a position.
        /// </summary>
        [Route("add")]
        [HttpPost]
        public void AddPosition([FromBody]Position position)
        {
            _positionsRepository.AddPosition(position);
        }

        // DELETE: api/positions/delete/{0}
        /// <summary>
        /// Deletes a position by ID.
        /// </summary>
        [Route("delete/{id}")]
        [HttpDelete]
        public void DeletePosition(int id)
        {
            _positionsRepository.DeletePosition(id);
        }
    }
}
