using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelperServices.LinqHelpers
{
    public class Filter
    {
        /// <summary>
        /// Gets or sets the name of the sorted field (property). Set to <c>null</c> if the <c>Filters</c> property is set.
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// Gets or sets the filtering operator. Set to <c>null</c> if the <c>Filters</c> property is set.
        /// </summary>
        public string Operator { get; set; }

        /// <summary>
        /// Gets or sets the filtering value. Set to <c>null</c> if the <c>Filters</c> property is set.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the filtering logic. Can be set to "or" or "and". Set to <c>null</c> unless <c>Filters</c> is set.
        /// </summary>
        public string Logic { get; set; }

        /// <summary>
        /// Gets or sets the child filter expressions. Set to <c>null</c> if there are no child expressions.
        /// </summary>
        public IEnumerable<Filter> Filters { get; set; }

        /// <summary>
        /// Mapping of Kendo DataSource filtering operators to Dynamic Linq
        /// </summary>
        private static readonly IDictionary<string, string> operators = new Dictionary<string, string>
    {
        {"eq", "="},
        {"neq", "!="},
        {"lt", "<"},
        {"lte", "<="},
        {"gt", ">"},
        {"gte", ">="},
        {"startswith", "StartsWith"},
        {"endswith", "EndsWith"},
        {"contains", "Contains"},
        {"null", "Null" },
        {"notnull", "NotNull" },
        {"nullorempty", "NullOrEmpty" },
        {"notnullorempty", "NotNullOrEmpty" },
    };

        /// <summary>
        /// Get a flattened list of all child filter expressions.
        /// </summary>
        public IList<Filter> All()
        {
            var filters = new List<Filter>();

            Collect(filters);

            return filters.Distinct().ToList();
        }

        private void Collect(IList<Filter> filters)
        {
            if (Filters != null && Filters.Any())
            {
                foreach (Filter filter in Filters)
                {
                    filters.Add(filter);

                    filter.Collect(filters);
                }
            }
            else
            {
                filters.Add(this);
            }
        }

        /// <summary>
        /// Converts the filter expression to a predicate suitable for Dynamic Linq e.g. "Field1 = @1 and Field2.Contains(@2)"
        /// </summary>
        /// <param name="filters">A list of flattened filters.</param>
        public string ToExpression(IList<Filter> filters)
        {
            if (Filters != null /*&& Filters.Any(x => x.Field != null)*/)
            {
                var str = new StringBuilder("( ");
                for (int i = 0; i < Filters.Count(); i++)
                {
                    if (i != 0)
                        str.Append(" ").Append(Filters.ToArray()[i].Logic != null && Filters.ToArray()[i].Logic != Logic ? " ) " + Filters.ToArray()[i].Logic + " ( " : Logic).Append(" ");
                    str.Append(Filters.ToArray()[i].ToExpression(filters));
                }
                str.Append(" )");
                return str.ToString();
                //return "(" + String.Join(" " + Logic + " ", Filters.Select(filter => filter.ToExpression(filters)).ToArray()) + ")";
            }

            int index = filters.IndexOf(this);
            if (string.IsNullOrEmpty(Operator))
                return "";
            string comparison = operators[Operator];

            if (comparison == "StartsWith" || comparison == "EndsWith" || comparison == "Contains")
            {
                return String.Format("{0}.{1}(@{2})", Field, comparison, index);
            }
            else if (comparison == "Null")
            {
                return String.Format("!{0}.{1}", Field, "HasValue");
            }
            else if (comparison == "NotNull")
            {
                return String.Format("{0}.{1}", Field, "HasValue");
            }
            else if (comparison == "NullOrEmpty")
            {
                return String.Format("string.NullOrEmpty({0})", Field);
            }
            else if (comparison == "NotNullOrEmpty")
            {
                return String.Format("!string.NullOrEmpty({0})", Field);
            }
            Guid guid;
            if (Guid.TryParse(Convert.ToString(this.Value), out guid))
            {
                this.Value = guid.ToString();
            }

            return String.Format("{0} {1} @{2}", Field, comparison, index);
        }
    }
}
