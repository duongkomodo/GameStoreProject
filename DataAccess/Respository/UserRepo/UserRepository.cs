using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Respository.UserRepo
{
    public class UserRepository:IUserRepository
    {
        private readonly GameStoreContext _context;
        private readonly IMapper _mapper;

        public UserRepository(IMapper mapper, GameStoreContext context)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
