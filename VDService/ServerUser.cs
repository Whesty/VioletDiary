﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace VDService
{
    internal class ServerUser
    {
        public int Id { get; set; }
        public OperationContext OperationContext { get; set; }
    }
}
