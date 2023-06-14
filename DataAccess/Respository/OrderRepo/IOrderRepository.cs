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
        List<OrderDto>? LoadAllOrders();
        List<OrderDto>? LoadAllOrdersByUserId(int uId);
        bool AddOrder(OrderDto Order);
        bool UpdateOrder(OrderDto Order);
        bool RemoveOrder(int oId);
    }
}
