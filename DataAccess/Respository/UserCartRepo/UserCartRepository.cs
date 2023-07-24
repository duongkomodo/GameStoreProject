using AutoMapper;
using BusinessObject.Models;
using DataAccess.Dto;
using DataAccess.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace DataAccess.Respository.UserCartRepo
{
    public class UserCartRepository : IUserCartRepository
    {
        private readonly GameStoreContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        public UserCartRepository(IMapper mapper, GameStoreContext context, UserManager<User> userManager, IEmailSender emailSender)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _emailSender = emailSender;
        }
        public async Task<BaseOutputDto> CheckOutForValidUser(string userId, Order order, List<OrderDetail> gameItems)
        {
            var result = new BaseOutputDto() { Status = OutputStatus.Fail };
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                result.Messages.Add("User not found");
                return result;
            }
         
            var subject = $"Game Store - New Order #{order.OrderId}!!!";
            var mailContent = CreateOrderForm(user, order, gameItems); ;
            await _emailSender.SendEmailAsync(user.Email, subject, mailContent);

            result.Status = OutputStatus.Success;
            result.Messages.Add("We have emailed your latest order information. Please check.");
            RemoveUserCart(user.Id);
            return result;
        }
        private  void RemoveUserCart(string userId)
        {
            var list =  _context.UserCarts.Include(x => x.Game).Where(x => x.UserId == userId).ToList();
            if (list != null)
            {
                _context.UserCarts.RemoveRange(list);
                _context.SaveChanges();
            }
        }

        private string CreateOrderForm(User user, Order order, List<OrderDetail> orderDetails)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(" <div style='background: whitesmoke; margin: 40px 70px;' >");
            builder.AppendLine(" <div style='background: white; margin: 40px 70px; '>");
            builder.AppendLine(" <div class='body-content' style='margin:10px'>");
            builder.AppendLine(" <h2 class='card-title'>Hello Dương ,</h2>");
            builder.AppendLine(" <div style='line-height:30px'>");
            builder.AppendLine(" Your can view your order details at your GameStore profile.");
            builder.AppendLine(" </div>");
            builder.AppendLine(" <div>");
            builder.AppendLine($" <h1>Order Information #{order.OrderId}</h1>");
            builder.AppendLine($"<span>Order date {order.OrderTime.ToString("dd/MM/yyyy")}</span>");
            builder.AppendLine(" </div>");
            builder.AppendLine(" <div>");
            builder.AppendLine(" <table class='table' border='0' cellspacing='0' width='100%'>");
            builder.AppendLine(" <tbody>");
            builder.AppendLine(" <tr>");
            builder.AppendLine(" <td>");
            builder.AppendLine(" <span class='table-item-name'>Customer:</span>");
            builder.AppendLine($" <span class='table-item-value'>{user.FirstName + " " + user.LastName} </span>");
            builder.AppendLine(" </td>");
            builder.AppendLine(" </tr>");
            builder.AppendLine(" <tr>");
            builder.AppendLine(" <td>");
            builder.AppendLine(" <span class='table-item-name'>Email:</span>");
            builder.AppendLine($" <span class='table-item-value'><a href='mailto:{user.Email}' target='_blank'>{user.Email}</a></span>");
            builder.AppendLine(" </td>");
            builder.AppendLine(" </tr>");
            builder.AppendLine(" <tr>");
            builder.AppendLine(" <td>");
            builder.AppendLine(" <span class='table-item-name'>Phone number:</span>");
            builder.AppendLine($" <span class='table-item-value'>{user.PhoneNumber}</span>");
            builder.AppendLine(" </td>");
            builder.AppendLine(" <td>");
            builder.AppendLine(" <span class='table-item-name'>Receive Email:</span>");
            builder.AppendLine($" <span class='table-item-value'><a href='mailto:{user.Email}' target='_blank'>{user.Email}</a></span>");
            builder.AppendLine(" </td>");
            builder.AppendLine(" </tr>");
            builder.AppendLine(" </tbody>");
            builder.AppendLine(" </table>");
            builder.AppendLine(" </div>");
            builder.AppendLine(" <div>");
            builder.AppendLine($" <h2 class='title'>Order details #{order.OrderId}</h2>");
            builder.AppendLine(" </div>");
            builder.AppendLine(" <div class='order-item'>");
            builder.AppendLine(" <table class='table'>");
            builder.AppendLine(" <tbody>");
            foreach (var orderDetail in orderDetails)
            {
                builder.AppendLine(" <tr>");
                builder.AppendLine(" <td style='width:250px;vertical-align:top'>");
                builder.AppendLine($" <img width='100%' height='100%' src='{orderDetail.Game.Image}' alt='{orderDetail.Game.Name}' data-bit='iit' tabindex='0'/>");
                builder.AppendLine(" </td>");
                builder.AppendLine(" <td style='width:50%;vertical-align:top'>");
                builder.AppendLine($" <div class='order-text-medium'>{orderDetail.Game.Name}</div>");
                builder.AppendLine(" <div style='margin-top:10px'>");
                builder.AppendLine(" </div>");
                builder.AppendLine(" <div class='order-key' style='margin-top:10px'>");
                builder.AppendLine(" <table class='table'>");
                builder.AppendLine(" <tbody>");
                foreach (var key in orderDetail.Keys)
                {
                    builder.AppendLine(" <tr>");
                    builder.AppendLine(" <td class='hide-mb' style='vertical-align:top;width:36px;text-align:center'>");
                    builder.AppendLine(" <img src='https://ci6.googleusercontent.com/proxy/UQnRLVfR788S9FmupgaD9y-594D3ScdAF7AE03S22t6m3Hqg44EjL3nwFCmgwWz_vcSaW5ZcsdWWGH0okEPH=s0-d-e1-ft#https://cdn.divineshop.vn/image/mail/key.png'>");
                    builder.AppendLine(" </td>");
                    builder.AppendLine(" <td>");
                    builder.AppendLine(" <div>");
                    builder.AppendLine($"{key.Code}");
                    builder.AppendLine(" </div>");
                    builder.AppendLine(" </td>");
                    builder.AppendLine(" </tr>");
                }
                builder.AppendLine(" </tbody>");
                builder.AppendLine(" </table>");
                builder.AppendLine(" </div>");
                builder.AppendLine(" <div style='margin-top:12px;vertical-align:middle'>");
                builder.AppendLine(" </div>");
                builder.AppendLine($" <div style='margin-top:10px'>Quantity: {orderDetail.Quantity}</div>");
                builder.AppendLine(" </td>");
                builder.AppendLine(" <td style='vertical-align:top'>");
                builder.AppendLine($" <div style='margin-top:5px'>Price {orderDetail.Price.ToString("#,##0đ")}</div>");
                builder.AppendLine(" </td>");
                builder.AppendLine(" </tr>");
            }
            builder.AppendLine(" </tbody>");
            builder.AppendLine(" </table>");
            builder.AppendLine(" </div>");
            builder.AppendLine(" <div>");
            builder.AppendLine(" <table class='table'>");
            builder.AppendLine(" <tbody>");
            builder.AppendLine(" <tr style='margin-top:5px'>");
            builder.AppendLine(" <td class='hide-mb' style='width:55%'></td>");
            builder.AppendLine(" <td style='width:25%'>");
            builder.AppendLine(" <div>Total Price</div>");
            builder.AppendLine(" </td>");
            builder.AppendLine(" <td style='width:20%'>");
            builder.AppendLine($" <div><h3>{order.TotalPrice.ToString("#,##0đ")}</h3></div>");
            builder.AppendLine(" </td>");
            builder.AppendLine(" </tr>");
            builder.AppendLine(" </tbody>");
            builder.AppendLine(" </table>");
            builder.AppendLine(" </div>");
            builder.AppendLine(" </div>");
            builder.AppendLine(" </div>");
            builder.AppendLine(" </div>");
            return builder.ToString();
        }


        public async Task<List<UserCartDto>>? LoadAllGamesInUserCart(string uId)
        {
            var list = await _context.UserCarts.Include(x => x.Game).Where(x => x.UserId == uId).ToListAsync();
            return _mapper.Map<List<UserCartDto>>(list);
        }
        public async Task<BaseOutputDto> UpdateGameItemInCart(string uId, List<UserCartDto> gameItems)
        {
            var result = new BaseOutputDto() { Status = OutputStatus.Fail };
            var oldCart = await _context.UserCarts.Where(x => x.UserId == uId).ToListAsync();
            if (oldCart.Count > 0)
            {
                _context.UserCarts.RemoveRange(oldCart);
                _context.SaveChanges();
            }
            if (gameItems.Count > 0)
            {
                var gameCart = gameItems.Select(item => new UserCart
                {
                    GameId = item.GameId,
                    UserId = uId,
                    Quantity = item.Quantity,
                    Price = item.Price,
                }).ToList();
                await _context.UserCarts.AddRangeAsync(gameCart);
                await _context.SaveChangesAsync();
            }
            result.Status = OutputStatus.Success;
            result.Messages.Add("Update user cart success");
            return result;
        }
    }
}
