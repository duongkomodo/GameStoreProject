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
        Task<string> SignInAsync(SignInDto model);
        Task<SignUpOutputDto> SignUpAsync(SignUpInputDto model);
    }
}
