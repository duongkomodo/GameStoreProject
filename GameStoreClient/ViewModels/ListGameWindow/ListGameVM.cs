using DataAccess.Dto;
using GameStoreClient.APIHelper;
using GameStoreClient.ViewModels.Paginating;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GameStoreClient.ViewModels.ListGameWindow
{
    public class ListGameVM : BaseVM
    {
        #region Property
        private PagingCollectionView _allGames;
        public PagingCollectionView AllGames
        {
            get
            {
                return _allGames;
            }
            set
            {
                _allGames = value; OnPropertyChanged();
            }
        }

        private ObservableCollection<CategoryDto> _allCategories;
        public ObservableCollection<CategoryDto> AllCategories
        {
            get
            {
                return _allCategories;
            }
            set
            {
                _allCategories = value; OnPropertyChanged();
            }
        }

        private ObservableCollection<DisplayGameDto> _currListGames;
        public ObservableCollection<DisplayGameDto> CurrListGames
        {
            get
            {
                return _currListGames;
            }
            set
            {
                _currListGames = value; OnPropertyChanged();
            }
        }



        #endregion

        #region Function
        private async void LoadListGameData()
        {
            var result = await SendApiRequest
                .SendApiRequestAsync<List<DisplayGameDto>>("https://localhost:7142/api/Game/LoadAllGames", HttpMethod.Get);
            if (result != null)
            {
               
                AllGames =  new PagingCollectionView(result,8);
            }
        }

        private async void LoadListCategoryData()
        {
            var result = await SendApiRequest
                .SendApiRequestAsync<List<CategoryDto>>("https://localhost:7142/api/Category/LoadAllCategories", HttpMethod.Get);
            if (result != null)
            {

                AllCategories = new ObservableCollection<CategoryDto>(result);
            }
        }



        #endregion

        #region Command
        public ICommand OnNextCommand   { get; set; }
        public ICommand OnPreviousCommand { get; set; }
        #endregion
        public ListGameVM()
        {
            LoadListGameData();
            LoadListCategoryData();

            OnNextCommand = new RelayCommand<object>((p) =>
            {
                if (AllGames != null)
                {
                    return AllGames.CurrentPage != AllGames.PageCount;
                }
                return false;

            }, (p) =>
            {
                AllGames.MoveToNextPage();
            });


            OnPreviousCommand = new RelayCommand<object>((p) =>
            {
                if (AllGames != null)
                {
                    return AllGames.CurrentPage != 1;
                }
                return false;

            }, (p) =>
            {
                AllGames.MoveToPreviousPage();
            });
        }
    }
}
