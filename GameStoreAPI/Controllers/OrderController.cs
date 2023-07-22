using BusinessObject.Models;
using DataAccess.Dto;
using DataAccess.Respository;
using DataAccess.Respository.OrderRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace GameStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepo;
        private readonly GameStoreContext _context;

        public OrderController(IOrderRepository orderRepo, GameStoreContext context)
        {
            _orderRepo = orderRepo;
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(OrderDto order)
        {
            try
            {
                var result = _orderRepo.AddOrder(order);

                if (result)
                {
                    return Ok(result);
                }

                return NotFound();

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Read()
        {
            try
            {
                return StatusCode(200, await _orderRepo.LoadAllOrders());
            }
            catch (ApplicationException ae)
            {
                return StatusCode(400, ae.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{oid}")]
        public IActionResult ReadDetail(int oid)
        {
            try
            {
                return Ok(_orderRepo.LoadOrder(oid));
            }
            catch (ApplicationException ae)
            {
                return StatusCode(400, ae.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(OrderDto order)
        {
            try
            {
                var result = _orderRepo.UpdateOrder(order);

                if (result)
                {
                    return Ok(result);
                }

                return NotFound("Order not found!");

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{oid}")]
        public IActionResult Delete(int oid)
        {
            try
            {
                var result = _orderRepo.RemoveOrder(oid);

                if (result)
                {
                    return Ok(result);
                }

                return NotFound("Order not found!");

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
