using AutoMapper;
using DataAccess.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Respository.OrderRepo
{
    public class OrderRepository : IOrderRepository
    {
        private readonly GameStoreContext _context;
        private readonly IMapper _mapper;

        public OrderRepository(IMapper mapper, GameStoreContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool AddOrder(OrderDto Order)
        {
            throw new NotImplementedException();
        }

        public List<OrderDto>? LoadAllOrders()
        {
            throw new NotImplementedException();
        }

        public List<OrderDto>? LoadAllOrdersByUserId(int uId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveOrder(int oId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateOrder(OrderDto Order)
        {
            throw new NotImplementedException();
        }
    }
}
