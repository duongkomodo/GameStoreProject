using BusinessObject.Models;
using DataAccess.Respository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class GameKeyController : Controller
    {
        private readonly GameStoreContext _context;

        public GameKeyController(GameStoreContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(GameKey gamekey)
        {
            GameKey gk = _context.GameKeys.FirstOrDefault(x => x.Code == gamekey.Code && x.GameId == gamekey.GameId);
            if (_context.GameKeys.Contains(gamekey) || gk != null)
            {
                return NoContent();
            }

            _context.GameKeys.Add(gamekey);
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
            if (_context.GameKeys == null)
            {
                return NotFound();
            }
            List<GameKey> gamekeys = _context.GameKeys.ToList();
            return Ok(gamekeys);
        }

        [HttpDelete("{code},{gid}")]
        public IActionResult Delete(string code, int gid)
        {
            GameKey gamekey = new GameKey();
            if (code == null || gid == null)
            {
                gamekey = _context.GameKeys.LastOrDefault();
            }
            else
            {
                gamekey = _context.GameKeys.FirstOrDefault(x => x.Code == code && x.GameId == gid);
            }

            if (_context.GameKeys == null || gamekey == null)
            {
                return NotFound();
            }

            _context.GameKeys.Remove(gamekey);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
