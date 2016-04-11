﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starter.Web.Core.Services
{
    public interface ISecureEntities<T>
    {
        bool IsAuthorized(T userId, object entityId, EntityActionType actionType, int entityType);
    }
}
