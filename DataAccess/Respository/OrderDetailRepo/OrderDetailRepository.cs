using AutoMapper;
using DataAccess.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Respository.OrderDetailRepo
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly GameStoreContext _context;
        private readonly IMapper _mapper;

        public OrderDetailRepository(IMapper mapper, GameStoreContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool AddOrderDetail(OrderDetailDto model)
        {
            throw new NotImplementedException();
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
