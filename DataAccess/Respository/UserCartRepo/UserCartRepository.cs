using AutoMapper;
using BusinessObject.Models;
using DataAccess.Dto;
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
            try
            {
                var list = await _context.UserCarts.Where(x => x.UserId == uId).ToListAsync();
                foreach (var item in list)
                {
                    item.Game = _context.Games.FirstOrDefault(x => x.GameId == item.GameId);
                }
                var result = _mapper.Map<List<UserCartDto>>(list);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool AddGameToCart(UserCartDto game)
        {
            try
            {
                var addUserCart = _mapper.Map<UserCart>(game);
                UserCart uc = _context.UserCarts.FirstOrDefault(x => x.UserId == game.UserId && x.GameId == game.GameId);
                if (_context.UserCarts.Contains(addUserCart) || uc != null)
                {
                    return false;
                }
                //addUserCart.Game = _context.Games.FirstOrDefault(x => x.GameId == addUserCart.GameId);
                _context.UserCarts.Add(addUserCart);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool UpdateGameInCart(UserCartDto game)
        {
            try
            {
                UserCart entry = _context.UserCarts.First(x => x.UserId == game.UserId && x.GameId == game.GameId);
                if (entry == null)
                {
                    return false;
                }
                _context.Entry(entry).CurrentValues.SetValues(game);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool RemoveGameInCart(string uId, int gId)
        {
            UserCart game = new UserCart();
            if (gId == null)
            {
                game = _context.UserCarts.LastOrDefault(x => x.UserId == uId);
            }
            else
            {
                game = _context.UserCarts.FirstOrDefault(x => x.UserId == uId && x.GameId == gId);
            }

            if (_context.UserCarts.Where(x => x.UserId == uId) == null || game == null)
            {
                return false;
            }

            _context.UserCarts.Remove(game);
            _context.SaveChanges();
            return true;
        }
    }
}
