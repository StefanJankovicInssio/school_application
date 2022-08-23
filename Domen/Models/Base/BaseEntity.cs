﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Models.Base
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;

    }
}
