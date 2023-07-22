using BusinessObject.Models;
using DataAccess.Dto;
using DataAccess.Utility;
using GameStoreClient.APIHelper;
using GameStoreClient.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace GameStoreClient.ViewModels
{
    public class UserCartVM : BaseVM
    {
        #region Property

        public Action CloseWindowAction { get; set; }
        private ObservableCollection<UserCartDto> _userCart = new ObservableCollection<UserCartDto>();
        public ObservableCollection<UserCartDto> UserCart
        {
            get
            {
                
                return _userCart;
            }
            set
            {
                _userCart = value;
                OnPropertyChanged();
            }
        }
        private float _userCartTotalPrice;
        public float UserCartTotalPrice
        {
            get
            {
                return _userCartTotalPrice;
            }
            set
            {
                if (UserCart != null)
                {
                    _userCartTotalPrice = value;
                }
                OnPropertyChanged();
            }
        }

        private string _anonymousUserEmail;
        public string AnonymousUserEmail
        {
            get
            {
                return _anonymousUserEmail;
            }
            set
            {
                    _anonymousUserEmail = value;
                
                OnPropertyChanged();
            }
        }
        #endregion
        #region Function

        public void LoadUserCart(List<UserCartDto>? game)
        {
            if (game != null)
            {
                UserCart = new ObservableCollection<UserCartDto>(game);
            }
        }
        public void UnLoadUserCart()
        {
          
                UserCart = new ObservableCollection<UserCartDto>();
            
        }
        public void AddToCart(DisplayGameDto game)
        {
            if (game != null)
            {
                var getGame = UserCart.FirstOrDefault(x => x.GameId == game.GameId);
                if (getGame != null)
                {
                    getGame.Quantity += 1;
                }
                else
                {
                    getGame = new UserCartDto()
                    {
                        Game = game,
                        GameId = game.GameId,
                        Quantity = 1,
                    };
                    UserCart.Add(getGame);
                }
                ReCalTotalPrice();
            }
        }
        public void MinusCartItem(UserCartDto item)
        {
            if (item != null)
            {
                var getGame = UserCart.FirstOrDefault(x => x.GameId == item.GameId);
                if (getGame != null)
                {
                    getGame.Quantity -= 1;
                    if (getGame.Quantity <= 0)
                    {
                        RemoveCartItem(getGame.GameId);
                    }
                    ReCalTotalPrice();
                }
            }
        }
        public void RemoveCartItem(int gId)
        {
            var getGame = UserCart.FirstOrDefault(x => x.GameId == gId);
            if (getGame != null)
            {
                var result = MessageBox.Show("Are you sure you want to delete this item?",
                    "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    UserCart.Remove(getGame);
                    ReCalTotalPrice();
                }
            }
        }
        public void AddCartItem(UserCartDto item)
        {
            if (item != null)
            {
                var getGame = UserCart.FirstOrDefault(x => x.GameId == item.GameId);
                if (getGame != null)
                {
                    getGame.Quantity = getGame.Quantity + 1;
                    ReCalTotalPrice();
                }
            }
        }
        public void ReCalTotalPrice()
        {
            if (UserCart != null)
            {
                UserCartTotalPrice = UserCart.Sum(x => x.Price);
            }
        }

        public async Task SaveUserCartAsync()
        {
            if (UserCart != null && UserCart.Count > 0)
            {
                var result = await SendApiRequest
.SendApiRequestAsync<BaseOutputDto>($"https://localhost:7142/api/UserCart/UpdateGameInCart?uid={UserData.User.Id}", HttpMethod.Post, UserCart, UserData.Jwt);
            }
        }
        #endregion
        #region Command
        public ICommand AddCartItemCommand { get; set; }
        public ICommand MinusCartItemCommand { get; set; }
        public ICommand RemoveCartItemCommand { get; set; }
        public ICommand GobackCommand { get; set; }
        public ICommand CheckoutCommand { get; set; }
        #endregion
        public UserCartVM()
        {

            GobackCommand = new RelayCommand<object>((p) =>
            {
            
                return true;

            },  (p) =>
            {
          
                 CloseWindowAction();
            });
            CheckoutCommand = new RelayCommand<object>((p) =>
            {
                if (UserCart != null && UserCart.Any())
                {
                    return true;
                }
                return false;
             
            }, (p) =>
            {
               if (UserData.User == null)
                {
                    CheckOutPopupWindow checkOutPopup = new CheckOutPopupWindow(this);
                    checkOutPopup.ShowDialog();
                }
               
            });
            RemoveCartItemCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                if (p != null)
                {
                    var item = p as UserCartDto;
                    RemoveCartItem(item.GameId);
                }
            });
            AddCartItemCommand = new RelayCommand<object>((p) =>
            {
                var item = p as UserCartDto;
                if (item != null)
                {
                    if (item.Quantity <= item.Game.Quantity)
                    {
                        return true;
                    }

                }
                return false;
            }, (p) =>
            {
                if (p != null)
                {
                    var item = p as UserCartDto;
                    AddCartItem(item);
                }
            });
            MinusCartItemCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                if (p != null)
                {
                    var item = p as UserCartDto;
                    MinusCartItem(item);
                }
            });
        }
    }
}
