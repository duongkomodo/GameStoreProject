using DataAccess.Dto;
using GameStoreClient.APIHelper;
using GameStoreClient.ViewModels.Paginating;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
namespace GameStoreClient.ViewModels.ListGameWindow
{
    public class ListGameVM : BaseVM
    {
        public readonly int ItemsPerPage = 8;
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
        private ObservableCollection<CategoryDto> _allCategories = new ObservableCollection<CategoryDto>();
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
        private CategoryDto _selectCategory;
        public CategoryDto SelectCategory
        {
            get
            {
                return _selectCategory;
            }
            set
            {
                _selectCategory = value; OnPropertyChanged();
                if (_selectCategory != null)
                {
                    FilterWithCategory(_selectCategory.CategoryId);

                }
            }
        }
        private ObservableCollection<DisplayGameDto> _currListGames
            = new ObservableCollection<DisplayGameDto>();
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
                .SendApiRequestAsync<List<DisplayGameDto>>
                ("https://localhost:7142/api/Game/LoadAllGames", HttpMethod.Get);
            if (result != null)
            {
                CurrListGames = new ObservableCollection<DisplayGameDto>(result);
                AllGames = new PagingCollectionView(result, ItemsPerPage);
            }
        }
        public void SearchGameData(string query)
        {
            if (SelectCategory != null || CurrListGames != null)
            {
                SelectCategory = AllCategories.FirstOrDefault();
                AllGames = new PagingCollectionView(CurrListGames
                    .Where(x => x.Name.ToLower().Contains(query.ToLower().TrimEnd())).ToList(), ItemsPerPage);
            }
        }
        public async void FilterWithCategory(int cid)
        {
            if (SelectCategory != null || CurrListGames != null)
            {
                if (cid != 0)
                {
                    AllGames = new PagingCollectionView(
                        CurrListGames.Where(x => x.CategoryId == cid).ToList(), ItemsPerPage);
                }
                else
                {
                    AllGames = new PagingCollectionView(CurrListGames, ItemsPerPage);
                }
                AllGames.Refresh();
            }
        }
        private async void LoadListCategoryData()
        {
            var result = await SendApiRequest
                .SendApiRequestAsync<List<CategoryDto>>
                ("https://localhost:7142/api/Category/LoadAllCategories", HttpMethod.Get);
            if (result != null)
            {
                result.Insert(0, new CategoryDto { CategoryId = 0, Name = "All Games" });
                AllCategories = new ObservableCollection<CategoryDto>(result);
            SelectCategory = AllCategories.FirstOrDefault();
            }
          
        }
        #endregion
        #region Command
        public ICommand OnNextCommand { get; set; }
        public ICommand OnPreviousCommand { get; set; }
        public ICommand OnFirstCommand { get; set; }
        public ICommand OnLastCommand { get; set; }
        #endregion
        public ListGameVM()
        {
             LoadListCategoryData();

            LoadListGameData();
        
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
            OnFirstCommand = new RelayCommand<object>((p) =>
            {
                if (AllGames != null)
                {
                    return AllGames.CurrentPage != 1;
                }
                return false;
            }, (p) =>
            {
                AllGames.MoveCurrentToFirst();
            });
            OnLastCommand = new RelayCommand<object>((p) =>
            {
                if (AllGames != null)
                {
                    return AllGames.CurrentPage != AllGames.PageCount;
                }
                return false;
            }, (p) =>
            {
                AllGames.MoveCurrentToLast();
            });
        }
    }
}
