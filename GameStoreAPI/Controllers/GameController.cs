using BusinessObject.Models;
using DataAccess.Respository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class GameController : Controller
    {
        private readonly GameStoreContext _context;

        public GameController(GameStoreContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(Game game)
        {
            Game g = _context.Games.FirstOrDefault(x => x.GameId == game.GameId);
            if (_context.Games.Contains(game) || g != null)
            {
                return NoContent();
            }

            _context.Games.Add(game);
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
            if (_context.Games == null)
            {
                return NotFound();
            }
            List<Game> games = _context.Games.ToList();
            return Ok(games);
        }

        [HttpGet("{gid}")]
        public IActionResult ReadDetail(int gid)
        {
            if (_context.Games == null)
            {
                return NotFound();
            }
            Game game = _context.Games.FirstOrDefault(x => x.GameId == gid);
            return Ok(game);
        }

        [HttpPut]
        public IActionResult Update(Game game)
        {
            Game entry = _context.Games.First(x => x.GameId == game.GameId);
            if (entry == null)
            {
                return NoContent();
            }

            _context.Entry(entry).CurrentValues.SetValues(game);
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

        [HttpDelete("{gid}")]
        public IActionResult Delete(int gid)
        {
            Game game = new Game();
            if (gid == null)
            {
                game = _context.Games.LastOrDefault();
            }
            else
            {
                game = _context.Games.FirstOrDefault(x => x.GameId == gid);
            }

            if (_context.Games == null || game == null)
            {
                return NotFound();
            }

            _context.GameKeys.RemoveRange(_context.GameKeys.Where(x => x.GameId.Equals(gid)));
            _context.Games.Remove(game);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
