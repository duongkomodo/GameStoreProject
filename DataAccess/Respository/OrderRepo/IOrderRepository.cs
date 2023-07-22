using DataAccess.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Respository.OrderRepo
{
    public interface IOrderRepository
    {
        Task<List<OrderDto>>? LoadAllOrders();
        Task<List<OrderDto>>? LoadAllOrdersByUserId(string uId);
        OrderDto? LoadOrder(int oId);
        bool AddOrder(OrderDto Order);
        bool UpdateOrder(OrderDto Order);
        bool RemoveOrder(int oId);
    }
}
