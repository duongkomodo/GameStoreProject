using DataAccess.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GameStoreClient.APIHelper
{
    public class UserData 
    {

        public static event PropertyChangedEventHandler StaticPropertyChanged;

        private static void OnStaticPropertyChanged(string propertyName)
        {
            StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
        }


        public UserData()
        {
        }
        private static UserDto? _user;
        public static UserDto? User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnStaticPropertyChanged("User");
            }
        }
        public static string? Jwt { get; set; }


    }
}
