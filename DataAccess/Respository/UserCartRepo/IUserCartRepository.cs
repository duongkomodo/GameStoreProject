using DataAccess.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Respository.UserCartRepo
{
    public interface IUserCartRepository
    {
        Task<List<UserCartDto>>? LoadAllGamesInUserCart(string uId);
        bool AddGameToCart(UserCartDto game);
        bool UpdateGameInCart(UserCartDto game);
        bool RemoveGameInCart(string uId, int gId);
    }
}
