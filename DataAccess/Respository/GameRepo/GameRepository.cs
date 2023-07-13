using AutoMapper;
using DataAccess.Dto;
using Microsoft.EntityFrameworkCore;
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



        public async Task<List<DisplayGameDto>>? LoadAllGames()
        {
            try
            {
                var list = await _context.Games.Include(x=>x.Category).ToListAsync();
                var result = _mapper.Map<List<DisplayGameDto>>(list);

                return result;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
    
        }

        public async Task<List<DisplayGameDto>>? LoadRecentAddedGames()
        {
            try
            {
                var list = await _context.Games.Include(x=>x.Category).OrderByDescending(x => x.GameId).Take(6).ToListAsync();
                var result = _mapper.Map<List<DisplayGameDto>>(list);


                return result;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public async Task<DisplayGameDto>? LoadMostBuyGame()
        {
            try
            {
                var list =  await _context.Games.GroupBy(game => game.GameId, game => game.OrderDetails,
                    (key, game) => new { GameId = key, Count = game.Count() }).ToListAsync();


                var gameId =  list.OrderByDescending(x=>x.Count).Select(x=>x.GameId).FirstOrDefault();


                if (gameId == -1)
                {
                    return null;
                }

                var getGame = _context.Games.Where(x=>x.GameId== gameId).FirstOrDefault();
                var result = new DisplayGameDto();
                if (getGame != null)
                {
                    result = _mapper.Map<DisplayGameDto>(getGame);
                }

                return result;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public bool RemoveGame(int gId)
        {
            throw new NotImplementedException();
        }


    }
}
