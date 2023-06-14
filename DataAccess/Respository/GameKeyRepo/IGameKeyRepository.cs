﻿using DataAccess.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Respository.GameKeyRepo
{
    public interface IGameKeyRepository
    {
        List<GameKeyDto>? LoadAllGameKeys();
        bool AddGameKey(GameKeyDto model);
        bool UpdateGameKey(GameKeyDto model);
        bool RemoveGameKey(int gkId);
    }
}
