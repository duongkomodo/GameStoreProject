using AutoMapper;
using BusinessObject.Models;
using DataAccess.Config;
using DataAccess.Dto;
using DataAccess.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Web;
namespace DataAccess.Respository.UserRepo
{
    public class UserRepository : IUserRepository
    {
        private readonly GameStoreContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ILookupNormalizer _normalizer;
        private readonly UserManager<User> _userManager;
        private readonly IPasswordHasher<User> _hashPasswordManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailSender _emailSender;
        public UserRepository(IMapper mapper, GameStoreContext context,
            IConfiguration configuration, UserManager<User> userManager,
            ILookupNormalizer normalizer,
        IPasswordHasher<User> hashPasswordManager, SignInManager<User> signInManager, IEmailSender emailSender)
        {
            _context = context;
            _mapper = mapper;
            _hashPasswordManager = hashPasswordManager;
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
            _normalizer = normalizer;
            _emailSender = emailSender;
        }
        public async Task<BaseOutputDto> SignUpAsync(SignUpInputDto model)
        {
            var result = new BaseOutputDto()
            {
                Status = "Fail"
            };
      
                var validators = _userManager.PasswordValidators;
                User user = await _userManager.FindByNameAsync(model.Email);

                if (user != null) {
                    result.Messages.Add("Email is exist! Please register with another email account.");
                }
                else
                {
                    user = new User
                    {
                        NormalizedEmail = _normalizer.NormalizeEmail(model.Email),
                        NormalizedUserName = _normalizer.NormalizeEmail(model.Email),
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        UserName = model.Email,
                        PhoneNumber = model.PhoneNumber,
                        Avatar = StringText.AvatarLink,
                    };

                    if (!model.Password.Equals(model.ConfirmPassword))
                    {
                        result.Messages.Add("The password and confirmation password do not match.");
                    }
                    foreach (var validator in validators)
                    {
                        var validatepassword = await validator.ValidateAsync(_userManager, user, model.Password);
                        if (!validatepassword.Succeeded)
                        {
                            foreach (var error in validatepassword.Errors)
                            {
                                result.Messages.Add(error.Description);
                            }
                        }
                    }
                    var identityResult = await _userManager.CreateAsync(user, model.Password);
                    if (identityResult.Succeeded)
                    {
                        await SendConfirmEmailAsync(user);
                        await _userManager.AddToRoleAsync(user, Roles.Member.ToString());
                    }

                    result.Status = identityResult.Succeeded ? "Succeed":"Fail";
                }            
             
                return result;
            
         
        }
        public async Task SendConfirmEmailAsync(User newUser)
        {
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
            var userId = await _userManager.GetUserIdAsync(newUser);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var uriBuilder = new UriBuilder(@"https://localhost:7142/api/User/ConfirmRegister");
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["userId"] = userId;
            query["code"] = code;
            uriBuilder.Query = query.ToString();

            var subject = "Confirm your email";
            var mailContent = $"Please confirm your account by <a href='{uriBuilder.ToString()}'>clicking here</a>.";


      await _emailSender.SendEmailAsync(newUser.Email, subject, mailContent);
        }
        public async Task<bool> CheckAccountExistByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email) != null ? true : false;
        }
        public async Task<bool> CheckAccountExistByUsernameAsync(string username)
        {
            return await _userManager.FindByNameAsync(username) != null ? true : false;
        }
        public async Task<string> ConfirmEmailAsync(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return "Error, code is null";
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return $"Unable to load user with ID '{userId}'.";
            }
            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await _userManager.ConfirmEmailAsync(user, code);
            string statusMessage = result.Succeeded ? "Thank you for confirming your email." : "Error confirming your email.";
            return statusMessage;
        }
        public async Task<BaseOutputDto> SignInAsync(SignInDto model)
        {
            //Create result 
            var result = new BaseOutputDto()
            {
                Status = "Fail"
            };
            // Get User
            User user = await _userManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                result.Messages.Add("Invalid login attempt!");
                return result; 
            }
     
            var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

            if (signInResult.Succeeded)
            {
                var userDto = _mapper.Map<UserDto>(user);
                var token = JWTConfig.CreateToken(userDto, _configuration);
                result.Messages.Add(token);
                result.Status= "Success";
            }
            else
            {
                result.Messages.Add("Invalid login attempt!");
            }
            //Map user with dto
          
            return result;
        }

        public async Task<string> ResendConfirmEmailAsync(SignInDto model)
        {
            // Get User
            User user = await _userManager.FindByNameAsync(model.Email);
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (!result.Succeeded)
            {
                return string.Empty;
            }
            //Map user with dto
            var userDto = _mapper.Map<UserDto>(user);
            var token = JWTConfig.CreateToken(userDto, _configuration);
            return token;
        }

        public async Task<string> LogoutAsync()
        {
            // Get User
            await _signInManager.SignOutAsync();
            return "Success"; 
           
        }

        public async Task<bool> IsEmailConfirmedAsync(SignInDto model)
        {
            // Get User
            User user = await _userManager.FindByNameAsync(model.Email);
            var isConfirmed = await _userManager.IsEmailConfirmedAsync(user);
            return isConfirmed;
        }
    }
}
