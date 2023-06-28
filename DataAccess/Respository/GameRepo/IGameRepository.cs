using DataAccess.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Respository.GameRepo
{
    public interface IGameRepository
    {
        Task<List<DisplayGameDto>>? LoadAllGames();
        Task<List<DisplayGameDto>>? LoadRecentAddedGames();
        Task<DisplayGameDto>? LoadMostBuyGame();
    }
}
