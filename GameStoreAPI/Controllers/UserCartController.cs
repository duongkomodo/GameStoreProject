using DataAccess.Dto;
using DataAccess.Respository.UserCartRepo;
using DataAccess.Utility;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("{uid}")]
        [Authorize]
        public async Task<IActionResult> LoadAllGamesInUserCart(string uid)
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

        [HttpPost]
        [Authorize]
        public async Task<BaseOutputDto> UpdateGameInCart(string uid,List<UserCartDto> game)
        {
            var result = new BaseOutputDto() { Status = OutputStatus.Fail };
            try
            {
                 result = await _userCartRepo.UpdateGameItemInCart(uid,game);

                return result;

            }
            catch (Exception ex)
            {
                result.Messages.Add(ex.Message);
                return result;
            }
        }


    }
}
