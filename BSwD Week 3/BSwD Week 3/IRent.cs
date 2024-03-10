﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSwD_Week_3
{
    interface IRent
    {
        double GetCost(int months);
        bool IsBooked();
        bool Book(int months);
    }
}
