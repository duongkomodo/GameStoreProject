using AutoMapper;
using BusinessObject.Models;
using DataAccess.Config;
using DataAccess.Dto;
using DataAccess.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
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
        public UserRepository(IMapper mapper, GameStoreContext context,
            IConfiguration configuration, UserManager<User> userManager,
            ILookupNormalizer normalizer,
        IPasswordHasher<User> hashPasswordManager, SignInManager<User> signInManager)
        {
            _context = context;
            _mapper = mapper;
            _hashPasswordManager = hashPasswordManager;
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
            _normalizer = normalizer;
        }
        public async Task<SignUpOutputDto> SignUpAsync(SignUpInputDto model)
        {
            var result = new SignUpOutputDto();
            try
            {


                var validators = _userManager.PasswordValidators;

                var newUser = new User
                {
                    NormalizedEmail = _normalizer.NormalizeEmail(model.Email),
                    NormalizedUserName = _normalizer.NormalizeEmail(model.Email),
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    EmailConfirmed = true,
                    UserName = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Avatar = StringText.AvatarLink,
                };

                if (!model.Password.Equals(model.ConfirmPassword))
                {
                    result.PasswordValidates.Add("The password and confirmation password do not match.");
                }


                foreach (var validator in validators)
                {
                    var validatepassword = await validator.ValidateAsync(_userManager, newUser, model.Password);
                    if (!validatepassword.Succeeded)
                    {
                        foreach (var error in validatepassword.Errors)
                        {
                            result.PasswordValidates.Add(error.Description);
                        }
                    }
                }

                //newUser.PasswordHash = _hashPasswordManager.HashPassword(newUser, model.Password);

                var identityResult = await _userManager.CreateAsync(newUser, model.Password);
                if (identityResult.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newUser, Roles.Member.ToString());
                }
                result.Result = identityResult.Succeeded ? "Succeed" : "Fail";
                return result;
            }
            catch (Exception ex)
            {
                result.Result = ex.Message;
                return result;
            }
        }
        public async Task<bool> CheckAccountExistByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email) != null ? true : false;
        }
        public async Task<bool> CheckAccountExistByUsernameAsync(string username)
        {
            return await _userManager.FindByNameAsync(username) != null ? true : false;
        }
        public async Task<string> SignInAsync(SignInDto model)
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
    }
}
