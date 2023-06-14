using AutoMapper;
using DataAccess.Dto;
using DataAccess.Respository.GameRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Respository.GameKeyRepo
{
    public class GameKeyRepository: IGameKeyRepository
    {
        private readonly GameStoreContext _context;
        private readonly IMapper _mapper;

        public GameKeyRepository(IMapper mapper, GameStoreContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool AddGameKey(GameKeyDto model)
        {
            throw new NotImplementedException();
        }

        public List<GameKeyDto>? LoadAllGameKeys()
        {
            throw new NotImplementedException();
        }

        public bool RemoveGameKey(int gkId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateGameKey(GameKeyDto model)
        {
            throw new NotImplementedException();
        }
    }
}
