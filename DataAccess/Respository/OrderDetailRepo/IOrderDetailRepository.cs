using DataAccess.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Respository.OrderDetailRepo
{
    public interface IOrderDetailRepository
    {
        List<OrderDetailDto>? LoadAllOrderDetails();
        bool AddOrderDetail(OrderDetailDto model);
        bool UpdateOrderDetail(OrderDetailDto model);
        bool RemoveOrderDetail(int oId);
        bool RemoveAllOrderDetail(int oId);
        public List<OrderDetailDto>? LoadAllOrderDetailsByOrderId(int oId);
    }
}
