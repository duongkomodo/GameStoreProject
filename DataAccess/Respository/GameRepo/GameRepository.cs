using AutoMapper;
using DataAccess.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Respository.GameRepo
{
    public class GameRepository : IGameRepository
    {
        private readonly GameStoreContext _context;
        private readonly IMapper _mapper;

        public GameRepository(IMapper mapper, GameStoreContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool AddGame(GameDto model)
        {
            throw new NotImplementedException();
        }

        public List<GameDto>? LoadAllGames()
        {
            throw new NotImplementedException();
        }

        public bool RemoveGame(int gId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateGame(GameDto model)
        {
            throw new NotImplementedException();
        }
    }
}
