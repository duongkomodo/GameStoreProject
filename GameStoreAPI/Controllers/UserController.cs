using BusinessObject.Models;
using DataAccess.Dto;
using DataAccess.Respository;
using DataAccess.Respository.UserRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly GameStoreContext _context;
        private readonly IUserRepository _userRepo;

        public UserController(GameStoreContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepo = userRepository; 
            
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<SignUpOutputDto> SignUp(SignUpInputDto model)
        {

            if (await _userRepo.CheckAccountExistByEmailAsync(model.Email))
            {
                return new SignUpOutputDto()
                {
                    Result = "Email already exist!" 
                };
            }

            if (await _userRepo.CheckAccountExistByUsernameAsync(model.FirstName))
            {
                return new SignUpOutputDto()
                {
                    Result = "Name already exist!" 
                };

            }

            var result = await _userRepo.SignUpAsync(model);

            return result;
        }

        [HttpPost]
        [AllowAnonymous]

        public async Task<string> Login(SignInDto model)
        {
            var resultToken = await _userRepo.SignInAsync(model);
            if (!string.IsNullOrEmpty(resultToken))
            {
                return resultToken;
            }

            return "Login fail!";
        }


      

    }
}
