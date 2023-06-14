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
        List<GameDto>? LoadAllGames();
        bool AddGame(GameDto model);
        bool UpdateGame(GameDto model);
        bool RemoveGame(int gId);
    }
}
