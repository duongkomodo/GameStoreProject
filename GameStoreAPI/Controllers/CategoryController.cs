using BusinessObject.Models;
using DataAccess.Respository;
using DataAccess.Respository.CategoryRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GameStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CategoryController : Controller
    {
        //private readonly ICategoryRepository _categoryRepo;

        //public CategoryController(ICategoryRepository categoryRepo)
        //{
        //    _categoryRepo = categoryRepo;
        //}

        private readonly GameStoreContext _context;

        public CategoryController(GameStoreContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            Category c = _context.Categories.FirstOrDefault(x => x.CategoryId == category.CategoryId);
            if (_context.Categories.Contains(category) || c != null)
            {
                return NoContent();
            }
            
            _context.Categories.Add(category);
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
            if (_context.Categories == null)
            {
                return NotFound();
            }
            List<Category> categories = _context.Categories.ToList();
            return Ok(categories);
        }

        [HttpGet("{cid}")]
        public IActionResult ReadDetail(int cid)
        {
            if (_context.Categories == null)
            {
                return NotFound();
            }
            Category category = _context.Categories.FirstOrDefault(x => x.CategoryId == cid);
            return Ok(category);
        }

        [HttpPut]
        public IActionResult Update(Category category)
        {
            Category entry = _context.Categories.First(x => x.CategoryId == category.CategoryId);
            if (entry == null)
            {
                return NoContent();
            }

            _context.Entry(entry).CurrentValues.SetValues(category);
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

        [HttpDelete("{cid}")]
        public IActionResult Delete(int cid)
        {
            Category cat = new Category();
            if (cid == null)
            {
                cat = _context.Categories.LastOrDefault();
            }
            else
            {
                cat = _context.Categories.FirstOrDefault(x => x.CategoryId == cid);
            }

            if (_context.Categories == null || cat == null)
            {
                return NotFound();
            }

            List<Game> gamesInCategory = _context.Games.Where(x => x.CategoryId.Equals(cid)).ToList();
            foreach(Game game in gamesInCategory)
            {
                _context.GameKeys.RemoveRange(_context.GameKeys.Where(x => x.GameId.Equals(game.GameId)));
                _context.Games.Remove(game);
            }
            _context.Categories.Remove(cat);
            _context.SaveChanges();
            return NoContent();
        }

       
    }
}
