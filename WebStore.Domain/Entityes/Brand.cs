﻿using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Domain.Entityes.Base;
using WebStore.Domain.Entityes.Base.Interfaces;

namespace WebStore.Domain.Entityes
{
    public class Brand : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
    }
}
