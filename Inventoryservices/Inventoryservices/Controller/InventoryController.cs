using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventoryservices.Models;
using Newtonsoft.Json.Linq;
using Inventoryservices.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventoryservices.Controller
{
    [Route("v1/")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly Services.IInventoryServices _services;
        public InventoryController(IInventoryServices services)
        {
            _services = services;
        }
        [HttpPost]
        [Route("AddInventoryItems")]
        public ActionResult<InventoryItems> AddInventoryItems(InventoryItems items)
        {
            var inventoryItems = _services.AddInventoryItems(items);
            /*if (inventoryItems == null)
            {
                return NotFound();
            }*/
            return inventoryItems;
        }
        [HttpGet]
        [Route("GetInventoryItems")]
        public ActionResult<Dictionary<string,InventoryItems>>GetInventoryItems()
        {
            var inventoryItems = _services.GetInventoryItems();
            /*if(inventoryItems.count==0)
            {
                return NotFound();
            }*/
            return Ok(inventoryItems);

        }
        [HttpPut]
        [Route("PutInventoryItems")]
        public ActionResult<Dictionary<string, InventoryItems>> PutInventoryItems()
        {
            var inventoryItems = _services.PutInventoryItems();
            return Ok(inventoryItems);

        }
        
    }
}