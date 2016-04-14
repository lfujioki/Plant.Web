using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plants.Web.Domain
{
    public class Plant
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Keywords { get; set; }

        public int? CategoryId { get; set; }

        public string CategoryType { get; set; }

        public int? SizeId { get; set; }

        public double? Feet { get; set; }

        public double? Meters { get; set; }

        public bool? IsBioluminescent { get; set; }
    }
}