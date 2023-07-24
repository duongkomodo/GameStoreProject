using AutoMapper;
using BusinessObject.Models;
using DataAccess.Dto;
using DataAccess.Respository.GameKeyRepo;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataAccess.Respository.OrderDetailRepo
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly GameStoreContext _context;
        private readonly IGameKeyRepository _gameKeyRepos;
        private readonly IMapper _mapper;
        public OrderDetailRepository(IMapper mapper, GameStoreContext context, IGameKeyRepository  gameKeyRepo )
        {
            _context = context;
            _mapper = mapper;
            _gameKeyRepos = gameKeyRepo;
        }
        public async Task<List<OrderDetail>?> CreateOrderDetail(int orderId, List<UserCartDto> game)
        {
            if (game.Count > 0)
            {
                var orderDetails = new List<OrderDetail>();
                foreach (var item in game)
                {

                    var listKey = await _gameKeyRepos.GetGameKeys(item.GameId,item.Quantity);
                    if (listKey != null)
                    {
                        OrderDetail orderDetail = new OrderDetail
                        {
                            GameId = item.GameId,                         
                            OrderId = orderId,
                            Price = item.Price,
                            Quantity = item.Quantity,
                            Keys = listKey,
                        };
                        orderDetails.Add(orderDetail);
                    }
                 
                }
                await _context.OrderDetails.AddRangeAsync(orderDetails);
               await _context.SaveChangesAsync();
                var result = _context.OrderDetails.Include(x=>x.Game).Where(x => x.OrderId == orderId).ToList();

                return result;
            }
            return null;
        }
        public List<OrderDetailDto>? LoadAllOrderDetails()
        {
            throw new NotImplementedException();
        }
        public List<OrderDetailDto>? LoadAllOrderDetailsByOrderId(int oId)
        {
            throw new NotImplementedException();
        }
        public bool RemoveAllOrderDetail(int oId)
        {
            throw new NotImplementedException();
        }
        public bool RemoveOrderDetail(int oId)
        {
            throw new NotImplementedException();
        }
        public bool UpdateOrderDetail(OrderDetailDto model)
        {
            throw new NotImplementedException();
        }
    }
}
