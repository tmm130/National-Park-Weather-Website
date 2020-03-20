﻿using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public interface IParkDAO
    {
        IList<Park> GetAllParks();

        Park FindUserParkChoice(string parkCode);
    }
}
