using BusinessObject.Models;
using DataAccess.Respository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OrderController : Controller
    {
        private readonly GameStoreContext _context;

        public OrderController(GameStoreContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(Order order)
        {
            Order o = _context.Orders.FirstOrDefault(x => x.OrderId == order.OrderId);
            if (_context.Orders.Contains(order) || o != null)
            {
                return NoContent();
            }

            _context.Orders.Add(order);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet]
        public IActionResult Read()
        {
            if (_context.Orders == null)
            {
                return NotFound();
            }
            List<Order> orders = _context.Orders.ToList();
            return Ok(orders);
        }

        [HttpGet("{oid}")]
        public IActionResult ReadDetail(int oid)
        {
            if (_context.Orders == null)
            {
                return NotFound();
            }
            Order order = _context.Orders.FirstOrDefault(x => x.OrderId == oid);
            return Ok(order);
        }

        [HttpPut]
        public IActionResult Update(Order order)
        {
            Order entry = _context.Orders.First(x => x.OrderId == order.OrderId);
            if (entry == null)
            {
                return NoContent();
            }

            _context.Entry(entry).CurrentValues.SetValues(order);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{oid}")]
        public IActionResult Delete(int oid)
        {
            Order order = new Order();
            if (oid == null)
            {
                order = _context.Orders.LastOrDefault();
            }
            else
            {
                order = _context.Orders.FirstOrDefault(x => x.OrderId == oid);
            }

            if (_context.Orders == null || order == null)
            {
                return NotFound();
            }

            _context.OrderDetails.Remove(_context.OrderDetails.FirstOrDefault(x => x.OrderId.Equals(oid)));
            _context.Orders.Remove(order);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
