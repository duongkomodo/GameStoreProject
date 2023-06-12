using AutoMapper;
using BusinessObject.Models;
using DataAccess.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Utility
{
    public class Mapper : Profile
    {
        public Mapper()
        {


        }

        protected internal Mapper(string profileName) : base(profileName)
        {
        }

    }
}