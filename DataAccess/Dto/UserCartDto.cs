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
    public class UserCartDto:BaseDto
    {
 
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
                OnPropertyChanged("Price");
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

                OnPropertyChanged("Quantity");
            }
        }
    }


    }

