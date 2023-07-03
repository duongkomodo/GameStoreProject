using DataAccess.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStoreClient.ViewModels
{
    class GameDetailVM
    {
        public GameDetailVM()
        {
        }

        public GameDetailVM(DisplayGameDto obj)
        {
            Game = obj;
        }

        public DisplayGameDto Game { get; }
    }
}
