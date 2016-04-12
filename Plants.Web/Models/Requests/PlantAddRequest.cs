using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plants.Web.Models.Requests
{
    public class PlantAddRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Keywords { get; set; }

        public int? CategoryId { get; set; }

        public int? SizeId { get; set; }

        public bool? IsBioluminescent { get; set; }
    }
}