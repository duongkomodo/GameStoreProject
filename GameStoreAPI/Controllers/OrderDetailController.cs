using BusinessObject.Models;
using DataAccess.Respository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OrderDetailController : Controller
    {
        private readonly GameStoreContext _context;

        public OrderDetailController(GameStoreContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(OrderDetail orderDetail)
        {
            OrderDetail od = _context.OrderDetails.FirstOrDefault(x => x.OrderId == orderDetail.OrderId);
            if (_context.OrderDetails.Contains(orderDetail) || od != null)
            {
                return NoContent();
            }

            _context.OrderDetails.Add(orderDetail);
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
            if (_context.OrderDetails == null)
            {
                return NotFound();
            }
            List<OrderDetail> ordDetails = _context.OrderDetails.ToList();
            return Ok(ordDetails);
        }

        [HttpGet("{oid}")]
        public IActionResult ReadDetail(int oid)
        {
            if (_context.OrderDetails == null)
            {
                return NotFound();
            }
            OrderDetail orderDetail = _context.OrderDetails.FirstOrDefault(x => x.OrderId == oid);
            return Ok(orderDetail);
        }

        [HttpPut]
        public IActionResult Update(OrderDetail orderDetail)
        {
            OrderDetail entry = _context.OrderDetails.First(x => x.OrderId == orderDetail.OrderId);
            if (entry == null)
            {
                return NoContent();
            }

            _context.Entry(entry).CurrentValues.SetValues(orderDetail);
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
            OrderDetail od = new OrderDetail();
            if (oid == null)
            {
                od = _context.OrderDetails.LastOrDefault();
            }
            else
            {
                od = _context.OrderDetails.FirstOrDefault(x => x.OrderId == oid);
            }

            if (_context.Orders == null || od == null)
            {
                return NotFound();
            }

            _context.OrderDetails.Remove(od);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
