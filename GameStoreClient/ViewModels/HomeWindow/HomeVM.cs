using DataAccess.Dto;
using GameStoreClient.APIHelper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
namespace GameStoreClient.ViewModels.HomeWindow
{
    public class HomeVM : BaseVM
    {
        #region Property
        private ObservableCollection<DisplayGameDto> _recentAddGames;
        public ObservableCollection<DisplayGameDto> RecentAddGames
        {
            get
            {
                return _recentAddGames;
            }
            set
            {
                _recentAddGames = value; OnPropertyChanged();
            }
        }
        private DisplayGameDto _mostBuyGame;
        public DisplayGameDto MostBuyGames
        {
            get
            {
                return _mostBuyGame;
            }
            set
            {
                _mostBuyGame = value; OnPropertyChanged();
            }
        }
        private bool _isListGameEmpty;
        public bool IsListGameEmpty
        {
            get
            {
                return _isListGameEmpty;
            }
            set
            {
                _isListGameEmpty = MostBuyGames != null; OnPropertyChanged();
            }
        }

        #endregion
        #region Function
        private async void LoadHomeData()
        {
            var result = await SendApiRequest
                .SendApiRequestAsync<List<DisplayGameDto>>("https://localhost:7142/api/Game/LoadRecentAddedGames", HttpMethod.Get);
            if (result != null)
            {
                MostBuyGames = result.First();
                
                RecentAddGames = new ObservableCollection<DisplayGameDto>(result.Take(5));
            }
        }
        #endregion

        #region Command
        #endregion
        public HomeVM()
        {
            LoadHomeData();
        }
    }
}
