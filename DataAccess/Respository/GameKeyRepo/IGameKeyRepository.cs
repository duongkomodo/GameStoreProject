using BusinessObject.Models;
using DataAccess.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Respository.GameKeyRepo
{
    public interface IGameKeyRepository
    {
        List<GameKeyDto>? LoadAllGameKeys();
        Task<List<GameKey>?> GetGameKeys(int gameId, int quantity);
        Task<BaseOutputDto> CheckGameKeys(List<UserCartDto> game);
        bool UpdateGameKey(GameKeyDto model);
        bool RemoveGameKey(int gkId);
    }
}
