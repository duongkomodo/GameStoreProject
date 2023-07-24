using BusinessObject.Models;
using DataAccess.Dto;
using DataAccess.Respository.GameKeyRepo;
using DataAccess.Respository.OrderDetailRepo;
using DataAccess.Respository.OrderRepo;
using DataAccess.Respository.UserCartRepo;
using DataAccess.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Xml.Linq;

namespace GameStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserCartController : Controller
    {
        private readonly IUserCartRepository _userCartRepo;
        private readonly IOrderRepository _orderRepo;
        private readonly IOrderDetailRepository _orderDetailRepo;
        private readonly IGameKeyRepository _gameKeyRepos;
        private readonly UserManager<User> _userManager;
        private readonly IEmailSender _emailSender;
        public UserCartController(IUserCartRepository userCartRepository,
            IOrderRepository orderRepository, IGameKeyRepository gameKeyRepository , IOrderDetailRepository orderDetailRepository, UserManager<User> userManager, IEmailSender emailSender)
        {
            _userCartRepo = userCartRepository;
            _orderRepo = orderRepository;
            _userManager = userManager;
            _emailSender = emailSender;
            _gameKeyRepos = gameKeyRepository;
            _orderDetailRepo= orderDetailRepository;
        }
        [HttpPost]
        public async Task<BaseOutputDto> CheckOutForAnonymousUser(string uid, List<UserCartDto> game)
        {
            var result = new BaseOutputDto() { Status = OutputStatus.Fail };
            try
            {
                if (!string.IsNullOrEmpty(uid))
                {
                }
                //result = await _userCartRepo.CheckOut(uid, game);
                return result;
            }
            catch (Exception ex)
            {
                result.Messages.Add(ex.Message);
                return result;
            }
        }
        [HttpPost("{uid}")]
        [Authorize]
        public async Task<BaseOutputDto> CheckOutForValidUser(string uid, List<UserCartDto> game)
        {
            var result = new BaseOutputDto() { Status = OutputStatus.Fail };
            try
            {
                //Check Order is valid
                var checkOrder = await _gameKeyRepos.CheckGameKeys(game);
                if (checkOrder.Status == OutputStatus.Fail)
                {
                    return checkOrder;
                }

                //Create Order
                
                var totalPrice = game.Sum(x => x.Price);
                var order = await _orderRepo.CreateOrder(uid, totalPrice);
                if (order == null)
                {
                    result.Messages.Add("Create new order fail!");
                    return result;
                }

                var orderDetails = await _orderDetailRepo.CreateOrderDetail(order.OrderId, game);
                if (orderDetails == null)
                {
                    result.Messages.Add("Insert new order details fail!");
                    return result;
                }

                var mailContent = await _userCartRepo.CheckOutForValidUser(uid, order, orderDetails);
                if (mailContent != null)
                {
                    mailContent.Status = OutputStatus.Success;
                    result = mailContent;
                }

                return result;
            }
            catch (Exception ex)
            {
                result.Messages.Add(ex.Message);
                return result;
            }
        }


        [HttpGet("{uid}")]
        [Authorize]
        public async Task<IActionResult> LoadAllGamesInUserCart(string uid)
        {
            try
            {
                return StatusCode(200, await _userCartRepo.LoadAllGamesInUserCart(uid));
            }
            catch (ApplicationException ae)
            {
                return StatusCode(400, ae.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        [Authorize]
        public async Task<BaseOutputDto> UpdateGameInCart(string uid, List<UserCartDto> game)
        {
            var result = new BaseOutputDto() { Status = OutputStatus.Fail };
            try { 
                 result = await _userCartRepo.UpdateGameItemInCart(uid, game);
                return result;
            }
            catch (Exception ex)
            {
                result.Messages.Add(ex.Message);
                return result;
            }
        }
    }
}
