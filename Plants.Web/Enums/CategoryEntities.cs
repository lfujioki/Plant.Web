using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Starter.Web
{
    public enum CategoryEntities : int
    {
        NotSet = 0,
        [Description("Tree")]
        Tree = 1,
        [Description("Shrub")]
        Shrub = 2,
        [Description("Fern")]
        Fern = 3,
        [Description("Wildflower")]
        Wildflower = 4,
        [Description("Cactus / Succulents")]
        Cactus = 5,
        [Description("Vines / Climbers")]
        Vine = 6,
        [Description("Aquatic")]
        Aquatic = 7,
        [Description("Grasses / Bamboo")]
        Grasses = 8
    }
}