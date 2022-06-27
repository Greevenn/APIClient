﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SportWord.Core.Domain.Models.Interfaces
{
    public interface IRead<Entity, EntityId>
       
    {
        Entity GetById(EntityId entityId);
        List<Entity> GetAll();
    }
}
