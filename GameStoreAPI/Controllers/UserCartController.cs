using DataAccess.Dto;
using DataAccess.Respository.UserCartRepo;
using Microsoft.AspNetCore.Mvc;

namespace GameStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserCartController : Controller
    {
        private readonly IUserCartRepository _userCartRepo;

        public UserCartController(IUserCartRepository userCartRepository)
        {
            _userCartRepo = userCartRepository;
        }

        [HttpPost]
        public IActionResult Create(UserCartDto game)
        {
            try
            {
                var result = _userCartRepo.AddGameToCart(game);

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

        [HttpGet("{uid}")]
        public async Task<IActionResult> Read(string uid)
        {
            try
            {
                return StatusCode(200, await _userCartRepo.LoadAllGamesInUserCart(uid));
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
        public IActionResult Update(UserCartDto game)
        {
            try
            {
                var result = _userCartRepo.UpdateGameInCart(game);

                if (result)
                {
                    return Ok(result);
                }

                return NotFound("Game not found in cart!");

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{uid},{gid}")]
        public IActionResult Delete(string uid, int gid)
        {
            try
            {
                var result = _userCartRepo.RemoveGameInCart(uid, gid);

                if (result)
                {
                    return Ok(result);
                }

                return NotFound("Game not found in cart!");

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
