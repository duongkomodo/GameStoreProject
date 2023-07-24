using BusinessObject.Models;
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
        Task<BaseOutputDto> UpdateGameItemInCart(string uId, List<UserCartDto> gameItems);
        Task<BaseOutputDto> CheckOutForValidUser(string uId, Order order, List<OrderDetail> gameItems);
     
    }
}
