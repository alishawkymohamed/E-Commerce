using System.Collections.Generic;

namespace LinqHelper
{
    /// <summary>
    /// Describes the result of DataSource read operation.
    /// </summary>
    public class DataSourceResult<T>
    {
        /// <summary>
        /// Represents a single page of processed data.
        /// </summary>
        public IEnumerable<T> Data { get; set; }

        /// <summary>
        /// The total number of records available.
        /// </summary>
        public int Count { get; set; }
    }
}