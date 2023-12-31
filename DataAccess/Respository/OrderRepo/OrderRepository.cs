﻿using AutoMapper;
using AutoMapper.Execution;
using BusinessObject.Models;
using DataAccess.Dto;
using DataAccess.Utility;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
        public async Task<List<OrderDto>>? LoadAllOrders()
        {
            try
            {
                var list = await _context.Orders.Include(x => x.OrderDetails).ToListAsync();
                var result = _mapper.Map<List<OrderDto>>(list);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<OrderDto>?> LoadAllOrdersByUserId(string uId)
        {
            try
            {
                var list = await _context.Orders.Where(x => x.UserId == uId)
                    .Include(x => x.OrderDetails).ThenInclude(x=>x.Keys).ThenInclude(x=>x.Game).ToListAsync();
                var result = _mapper.Map<List<OrderDto>>(list);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public OrderDto? LoadOrder(int oId)
        {
            try
            {
                var ord = _context.Orders.FirstOrDefault(x => x.OrderId == oId);
                return _mapper.Map<OrderDto>(ord);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Order?> CreateOrder(string uid, float totalPrice)
        {
                Order neworder = new Order()
                {
                    OrderTime = DateTime.Now,
                    Status = OrderStatus.Paid,
                    UserId = uid,
                    TotalPrice= totalPrice,
                };
                await _context.Orders.AddAsync(neworder);
                var result = await _context.SaveChangesAsync();

                return neworder;

        }
        public bool RemoveOrder(int oId)
        {
            Order order = new Order();
            if (oId == null)
            {
                order = _context.Orders.LastOrDefault();
            }
            else
            {
                order = _context.Orders.FirstOrDefault(x => x.OrderId == oId);
            }
            if (_context.Orders == null || order == null)
            {
                return false;
            }
            _context.OrderDetails.RemoveRange(_context.OrderDetails.Where(x => x.OrderId.Equals(oId)));
            _context.Orders.Remove(order);
            _context.SaveChanges();
            return true;
        }
        public bool UpdateOrder(OrderDto order)
        {
            try
            {
                Order entry = _context.Orders.First(x => x.OrderId == order.OrderId);
                if (entry == null)
                {
                    return false;
                }
                _context.Entry(entry).CurrentValues.SetValues(order);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
