using BusinessObject.Models;
using DataAccess.Dto;
using DataAccess.Respository;
using DataAccess.Respository.UserRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using System.Text;
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
        public async Task<BaseOutputDto> SignUp(SignUpInputDto model)
        {
            var result = new BaseOutputDto()
            {
                Messages = new List<string>(),
                Status = "Fail"
            };
            try
            {
                if (await _userRepo.CheckAccountExistByEmailAsync(model.Email))
                {
                    result.Messages.Add("Name already exist!");
                    return result;
                }
                if (await _userRepo.CheckAccountExistByUsernameAsync(model.FirstName))
                {
                    result.Messages.Add("Name already exist!");
                    return result;
                }
                result = await _userRepo.SignUpAsync(model);
                return result;
            }
            catch (Exception ex)
            {
                result.Messages.Add(ex.Message);
                return result;
            }
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<BaseOutputDto> Login(SignInDto model)
        {
            var result = new BaseOutputDto() { Messages = new List<string>(), Status = "Fail" };
            try
            {
                if (await _userRepo.IsEmailConfirmedAsync(model))
                {
                    result.Messages.Add("Your email has not been confirmed!");
                    return result;
                }
                var resultToken = await _userRepo.SignInAsync(model);
                if (resultToken != null && resultToken.Status.Equals("Success"))
                {
                    return result;
                }
                result.Messages.Add("Login Fail, username or password may incorrect!");
                return result;
            }
            catch (Exception ex)
            {
                result.Messages.Add(ex.Message);
                return result;
            }
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<BaseOutputDto> ResendConfrimEmail(SignInDto model)
        {
            var result = new BaseOutputDto() { Messages = new List<string>(), Status = "Fail" };
            try
            {
                var resultToken = await _userRepo.ResendConfirmEmailAsync(model);
                if (!string.IsNullOrEmpty(resultToken))
                {
                    result.Messages.Add(resultToken);
                    result.Status = "Success";
                    return result;
                }
                result.Messages.Add("Login Fail, username or password may incorrect!");
                return result;
            }
            catch (Exception ex)
            {
                result.Messages.Add(ex.Message);
                return result;
            }
        }
        [HttpGet]
        public async Task<string> ConfirmRegister(string userId, string code)
        {
            try
            {
                var result = await _userRepo.ConfirmEmailAsync(userId, code);
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [HttpGet]
        public async Task<string> Logout()
        {
            try
            {
                var result = await _userRepo.LogoutAsync();
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
