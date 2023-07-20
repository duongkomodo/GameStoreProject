using DataAccess.Dto;
using DataAccess.Respository;
using DataAccess.Respository.UserRepo;
using DataAccess.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
                Status = OutputStatus.Fail
            };
            try
            {
                var checkAccount = await _userRepo.CheckAccountExistByEmailAsync(model.Email);
                if (!checkAccount)
                {
                    result.Messages.Add("Email already exist!");
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
            var result = new BaseOutputDto() { Status=OutputStatus.Fail};
            try
            {

                var checkAccount = await _userRepo.CheckAccountExistByEmailAsync(model.Email);
                if (!checkAccount)
                {
                    result.Messages.Add("Account not found!");
                    return result;
                }
                checkAccount = await _userRepo.IsEmailConfirmedAsync(model);
                if (!checkAccount)
                {
                    result.Messages.Add("Your email has not been confirmed! \n Would you like to resend the confirmation email ?");
                    result.Status= "Unconfirmed Email";
                    return result;
                }
                var resultToken = await _userRepo.SignInAsync(model);
                if (resultToken != null && OutputStatus.Success.Equals(resultToken.Status))
                {
                    return resultToken;
                }
                result.Messages.Add("Login fail, username or password may incorrect!");
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
        public async Task<BaseOutputDto> ResendConfirmEmail(string email)
        {
            var result = new BaseOutputDto() { Status= OutputStatus.Fail };
            try
            {
                 result = await _userRepo.ResendConfirmEmailAsync(email);
                return result;
           
            }
            catch (Exception ex)
            {
                result.Messages.Add(ex.Message);
                return result;
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<BaseOutputDto> ChangePassword(ChangePasswordDto data)
        {
            var result = new BaseOutputDto() { Status = OutputStatus.Fail };
            try
            {
                result = await _userRepo.ChangePasswordAsync(data.Email, data.Password, data.ConfirmPassword);
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

        [HttpGet,Authorize]
        public async Task<UserDto> GetUserInformation([FromQuery]string userName )
        {

                var result = await _userRepo.GetUserInformationAsync(userName);
                return result;
            

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
