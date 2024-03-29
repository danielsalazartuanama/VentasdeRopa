﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VASTQuickShoping.Models.Domain;

namespace VASTQuickShoping.Manager.Contracts
{
    interface ICategoryManager: ICrud<Category>
    {
        IEnumerable<Category> GetAllSimple();
    }
}
