using System;
using System.Threading.Tasks;
using CRUDWithRepositoryAspNetCoreApi.Models;
using CRUDWithRepositoryAspNetCoreApi.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDWithRepositoryAspNetCoreApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private IitemRepository iitemRepository;

        public ItemController(IitemRepository _iitemRepository)
        {
            iitemRepository = _iitemRepository;
        }


        [Produces("application/json")]
        [HttpGet]
        public async Task <IActionResult> FindAll()
        {
            try
            {
                var item = await iitemRepository.GetAll().ToListAsync();
                return  Ok(item);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [Produces("application/json")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Find(int id)
        {
            try
            {
                var itemID = await iitemRepository.GetById(id);
                if (itemID == null)
                    return BadRequest("El ID: " + id + " No existe, Vuela a ingresar otro ID.");
                var item = await iitemRepository.GetById(id);
                return Ok(item);
            }
            catch 
            {

               return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("search/{keyword}")]
        public async Task<IActionResult> Search(string keyword)
        {
            try
            {
                var item = iitemRepository.Search(keyword);
                return Ok(item);
            }
            catch
            {

                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("search/{min}/{max}")]
        public async Task<IActionResult> Search(decimal min, decimal max)
        {
            try
            {
                var item = iitemRepository.Search(min,max);
                return Ok(item);
            }
            catch
            {

                return BadRequest();
            }
        }

        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> Create(Item item)
        {
            try
            {
              await iitemRepository.Create(item);
                return Ok(item);
            }
            catch
            {
                return BadRequest();
            }
        }


        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPut]
        public async Task<IActionResult> Update(Item item)
        {
            try
            {
                var Itemid = await iitemRepository.GetById(item.ItemId);
                if (Itemid == null)
                    return BadRequest("El ID: " + item.ItemId + " No existe, Vuela a ingresar otro ID.");

                await iitemRepository.Update(item.ItemId, item);
                return Ok(item);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var item = await iitemRepository.GetById(id);
                if (item == null)
                    return BadRequest("El ID: " + id + " No existe, Vuela a ingresar otro ID.");

                await iitemRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}