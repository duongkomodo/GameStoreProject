using BusinessObject.Models;
using DataAccess.Respository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly GameStoreContext _context;

        public UserController(GameStoreContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            User u = _context.Users.FirstOrDefault(x => x.Email == user.Email);
            if (_context.Users.Contains(user) || u != null)
            {
                return NoContent();
            }

            _context.Users.Add(user);
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
            if (_context.Users == null)
            {
                return NotFound();
            }
            List<User> users = _context.Users.ToList();
            return Ok(users);
        }

        [HttpPut]
        public IActionResult Update(User user)
        {
            User entry = _context.Users.First(x => x.Email == user.Email);
            if (entry == null)
            {
                return NoContent();
            }

            _context.Entry(entry).CurrentValues.SetValues(user);
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

    }
}
