using DataAccess.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Respository.UserRepo
{
    public interface IUserRepository
    {
        public Task<bool> CheckAccountExistByEmailAsync(string model);
        public Task<bool> CheckAccountExistByUsernameAsync(string model);
        Task<BaseOutputDto> SignInAsync(SignInDto model);
        Task<BaseOutputDto> SignUpAsync(SignUpInputDto model);
        Task<string> ConfirmEmailAsync(string userId, string code);
        Task<string> ResendConfirmEmailAsync(SignInDto model);
        Task<bool> IsEmailConfirmedAsync(SignInDto model);
        Task LogoutAsync();
    }
}
