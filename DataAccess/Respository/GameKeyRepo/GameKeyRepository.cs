using AutoMapper;
using BusinessObject.Models;
using DataAccess.Dto;
using DataAccess.Respository.GameRepo;
using DataAccess.Utility;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataAccess.Respository.GameKeyRepo
{
    public class GameKeyRepository : IGameKeyRepository
    {
        private readonly GameStoreContext _context;
        private readonly IMapper _mapper;
        public GameKeyRepository(IMapper mapper, GameStoreContext context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<BaseOutputDto> CheckGameKeys(List<UserCartDto> games)
        {
            var result = new BaseOutputDto()
            {
                Status = OutputStatus.Fail
            };
            bool IsValid = true;
            foreach (var item in games)
            {
                var count = await _context.GameKeys.CountAsync(x => x.GameId == item.GameId);
                if (count < item.Quantity)
                {
                    var response = count != 0 ? $" only have {count} key(s) left." : "is out of stock.";
                    result.Messages.Add($"Your item: {item.Game.Name} {response}.");
                    IsValid = false;
                }
            }
            if (IsValid)
            {
                result.Status = OutputStatus.Success;
                return result;
            }
            return result;
        }
        public async Task<List<GameKey>?> GetGameKeys(int gameId, int quantity)
        {
            var list = await _context.GameKeys.Where(x => x.GameId == gameId && x.OrderDetailOrderId == null).ToListAsync();
            if (list.Count < quantity)
            {
                return null;
            }
            return list.Take(quantity).ToList();
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
