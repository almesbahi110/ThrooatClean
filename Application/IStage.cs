﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IStage
    {
        Task<string> AddAsync(Stage entity);
    }
}