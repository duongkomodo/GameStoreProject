using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dto
{
    public class UserCartDto:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        public string? UserId { get; set; }
        public int GameId
        {
            get; set;
        }
        public virtual DisplayGameDto Game
        {
            get; set;
        }
        private float price;
        public float Price
        {
            get
            {
                return price;
            }
            set
            {

                price = value;
                NotifyPropertyChanged("Price");
            }

        }
        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set
            {

                quantity = value;
                Price = Game.Price * value;

                NotifyPropertyChanged("Quantity");
            }
        }
    }


    }

