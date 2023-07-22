using AutoMapper;
using BusinessObject.Models;
using DataAccess.Dto;
using DataAccess.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
namespace DataAccess.Respository.UserCartRepo
{
    public class UserCartRepository : IUserCartRepository
    {
        private readonly GameStoreContext _context;
        private readonly IMapper _mapper;
        public UserCartRepository(IMapper mapper, GameStoreContext context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<UserCartDto>>? LoadAllGamesInUserCart(string uId)
        {
            var list = await _context.UserCarts.Include(x => x.Game).Where(x => x.UserId == uId).ToListAsync();
            return _mapper.Map<List<UserCartDto>>(list);
        }
        public async Task<BaseOutputDto> UpdateGameItemInCart(string uId, List<UserCartDto> gameItems)
        {
            var result = new BaseOutputDto() { Status = OutputStatus.Fail };
            var oldCart = await _context.UserCarts.Where(x => x.UserId == uId).ToListAsync();
            if (oldCart.Count > 0)
            {
                _context.UserCarts.RemoveRange(oldCart);
                _context.SaveChanges();
            }
            if (gameItems.Count > 0)
            {
                var gameCart = gameItems.Select(item => new UserCart
                {
                    GameId = item.GameId,
                    UserId = uId,
                    Quantity = item.Quantity,
                    Price = item.Price,
                }).ToList();

               await _context.UserCarts.AddRangeAsync(gameCart);
                await _context.SaveChangesAsync();
            }
         
            result.Status = OutputStatus.Success;
            result.Messages.Add("Update user cart success");
            return result;
        }
    }
}
