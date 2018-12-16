using HelperServices.LinqHelpers;
using System.Collections.Generic;

namespace LinqHelper
{
    public class DataSourceRequest
    {
        public int Take { get; set; }

        public int Skip { get; set; }

        public IEnumerable<Sort> Sort { get; set; }

        public Filter Filter { get; set; }

        public bool Countless { get; set; }
    }
}