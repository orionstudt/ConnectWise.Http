using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http
{
    public class CWRequestConditions
    {
        /// <summary>
        /// Each element in the enumerable should be a distinct condition.
        /// I.E. -> board/name="Integration"
        /// All elements will be AND'ed. If you would like to OR conditions, make them a single element enclosed in parenthesis.
        /// I.E. -> (board/name="Integration" OR board/id in (3,2,4))
        /// </summary>
        public IEnumerable<string> Conditions { get; set; }

        /// <summary>
        /// Each element in the enumerable should be a distinct condition.
        /// I.E. -> board/name="Integration"
        /// All elements will be AND'ed. If you would like to OR conditions, make them a single element enclosed in parenthesis.
        /// I.E. -> (board/name="Integration" OR board/id in (3,2,4))
        /// </summary>
        public IEnumerable<string> ChildConditions { get; set; }

        /// <summary>
        /// Each element in the enumerable should be a distinct condition.
        /// I.E. -> board/name="Integration"
        /// All elements will be AND'ed. If you would like to OR conditions, make them a single element enclosed in parenthesis.
        /// I.E. -> (board/name="Integration" OR board/id in (3,2,4))
        /// </summary>
        public IEnumerable<string> CustomFieldConditions { get; set; }

        public string OrderBy { get; set; }

        /// <summary>
        /// Each element in the enumerable should be a distinct condition.
        /// I.E. -> board/name="Integration"
        /// All elements will be AND'ed. If you would like to OR conditions, make them a single element enclosed in parenthesis.
        /// I.E. -> (board/name="Integration" OR board/id in (3,2,4))
        /// </summary>
        public IEnumerable<string> Fields { get; set; }

        /// <summary>
        /// Each element in the enumerable should be a distinct condition.
        /// I.E. -> board/name="Integration"
        /// All elements will be AND'ed. If you would like to OR conditions, make them a single element enclosed in parenthesis.
        /// I.E. -> (board/name="Integration" OR board/id in (3,2,4))
        /// </summary>
        public IEnumerable<string> Columns { get; set; }

        public int? Page { get; set; }

        public int? PageSize { get; set; }

        internal string Build(CWConditionOptions options, bool appendToExisting = false)
        {
            var sb = new StringBuilder();
            bool didFirst = appendToExisting;
            // Conditions
            if (options.Conditions && Conditions != null && Conditions.Any())
            {
                if (didFirst) { sb.Append("&"); } else { didFirst = true; sb.Append("?"); }
                sb.Append(getConditions());
            }
            // ChildConditions
            if (options.ChildConditions && ChildConditions != null && ChildConditions.Any())
            {
                if (didFirst) { sb.Append("&"); } else { didFirst = true; sb.Append("?"); }
                sb.Append(getChildConditions());
            }
            // CustomFieldConditions
            if (options.CustomFieldConditions && CustomFieldConditions != null && CustomFieldConditions.Any())
            {
                if (didFirst) { sb.Append("&"); } else { didFirst = true; sb.Append("?"); }
                sb.Append(getCustomFieldConditions());
            }
            // OrderBy
            if (options.OrderBy && !string.IsNullOrWhiteSpace(OrderBy))
            {
                if (didFirst) { sb.Append("&"); } else { didFirst = true; sb.Append("?"); }
                sb.Append($"orderBy={OrderBy.Trim(' ').Replace(" ", "%20")}");
            }
            // Fields
            if (options.Fields && Fields != null && Fields.Any())
            {
                if (didFirst) { sb.Append("&"); } else { didFirst = true; sb.Append("?"); }
                sb.Append(getFields());
            }
            // Columns
            if (options.Columns && Columns != null && Columns.Any())
            {
                if (didFirst) { sb.Append("&"); } else { didFirst = true; sb.Append("?"); }
                sb.Append(getColumns());
            }
            // Page
            if (options.Page && Page.HasValue)
            {
                if (didFirst) { sb.Append("&"); } else { didFirst = true; sb.Append("?"); }
                sb.Append($"page={Page.Value.ToString()}");
            }
            // PageSize
            if (options.PageSize && PageSize.HasValue)
            {
                if (didFirst) { sb.Append("&"); } else { didFirst = true; sb.Append("?"); }
                sb.Append($"pageSize={PageSize.Value.ToString()}");
            }
            // Return
            var final = sb.ToString();
            return string.IsNullOrWhiteSpace(final) ? string.Empty : final;
        }

        private string getConditions()
        {
            return "conditions=" + and(Conditions);
        }

        private string getChildConditions()
        {
            return "childConditions=" + and(ChildConditions);
        }

        private string getCustomFieldConditions()
        {
            return "customFieldConditions=" + and(CustomFieldConditions);
        }

        private string getFields()
        {
            return "fields=" + and(Fields);
        }

        private string getColumns()
        {
            return "columns=" + and(Columns);
        }

        private string and(IEnumerable<string> enumerable)
        {
            bool didFirst = false;
            string output = string.Empty;
            foreach (var element in enumerable)
            {
                if (didFirst) { output = output + "%20AND%20"; } else { didFirst = true; }
                output = output + element.Trim(' ').Replace(" ", "%20");
            }
            return output;
        }
    }

    internal class CWConditionOptions
    {
        public bool Conditions { get; set; }
        public bool ChildConditions { get; set; }
        public bool CustomFieldConditions { get; set; }
        public bool OrderBy { get; set; }
        public bool Fields { get; set; }
        public bool Columns { get; set; }
        public bool Page { get; set; }
        public bool PageSize { get; set; }

        internal CWConditionOptions() { }

        internal static CWConditionOptions StandardConditions
        {
            get
            {
                return new CWConditionOptions
                {
                    Conditions = true,
                    ChildConditions = true,
                    CustomFieldConditions = true,
                    OrderBy = true,
                    Fields = true,
                    Page = true,
                    PageSize = true
                };
            }
        }

        internal static CWConditionOptions CountConditions
        {
            get
            {
                return new CWConditionOptions
                {
                    Conditions = true,
                    CustomFieldConditions = true
                };
            }
        }

        internal static CWConditionOptions OnlyFields
        {
            get
            {
                return new CWConditionOptions
                {
                    Fields = true
                };
            }
        }

        internal static CWConditionOptions ConditionsAndPaging
        {
            get
            {
                return new CWConditionOptions
                {
                    Conditions = true,
                    Page = true,
                    PageSize = true
                };
            }
        }

        internal static CWConditionOptions Pagination
        {
            get
            {
                return new CWConditionOptions
                {
                    Page = true,
                    PageSize = true
                };
            }
        }
    }
}
