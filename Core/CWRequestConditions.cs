using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http
{
    /// <summary>
    /// An instance of this 
    /// </summary>
    public class CWRequestConditions
    {
        /// <summary>
        /// Each element in the enumerable should be a distinct condition. I.E. -> board/name="Integration". All elements will be AND'ed. If you would like to OR conditions, make them a single element enclosed in parenthesis. I.E. -> (board/name="Integration" OR board/id in (3,2,4))
        /// </summary>
        public IEnumerable<string> Conditions { get; set; }

        /// <summary>
        /// Each element in the enumerable should be a distinct condition. I.E. -> board/name="Integration". All elements will be AND'ed. If you would like to OR conditions, make them a single element enclosed in parenthesis. I.E. -> (board/name="Integration" OR board/id in (3,2,4))
        /// </summary>
        public IEnumerable<string> ChildConditions { get; set; }

        /// <summary>
        /// Each element in the enumerable should be a distinct condition. I.E. -> board/name="Integration". All elements will be AND'ed. If you would like to OR conditions, make them a single element enclosed in parenthesis. I.E. -> (board/name="Integration" OR board/id in (3,2,4))
        /// </summary>
        public IEnumerable<string> CustomFieldConditions { get; set; }

        public string OrderBy { get; set; }

        /// <summary>
        /// Each element in the enumerable should be a distinct condition. I.E. -> board/name="Integration". All elements will be AND'ed. If you would like to OR conditions, make them a single element enclosed in parenthesis. I.E. -> (board/name="Integration" OR board/id in (3,2,4))
        /// </summary>
        public IEnumerable<string> Fields { get; set; }

        /// <summary>
        /// Each element in the enumerable should be a distinct condition. I.E. -> board/name="Integration". All elements will be AND'ed. If you would like to OR conditions, make them a single element enclosed in parenthesis. I.E. -> (board/name="Integration" OR board/id in (3,2,4))
        /// </summary>
        public IEnumerable<string> Columns { get; set; }

        public int? Page { get; set; }

        public int? PageSize { get; set; }

        public CWRequestConditions()
        {
            Conditions = new string[] { };
            ChildConditions = new string[] { };
            CustomFieldConditions = new string[] { };
            Fields = new string[] { };
            Columns = new string[] { };
        }

        private enum Delimiter
        {
            And,
            Comma
        }

        private StringBuilder sb = null;

        internal string ToUriConditions(CWConditionOptions options, bool appendToExisting = false)
        {
            var sb = new StringBuilder();
            bool append = appendToExisting;
            // Conditions
            buildConditionString(options.Conditions, "conditions", Conditions, Delimiter.And, append, out append);
            // ChildConditions
            buildConditionString(options.ChildConditions, "childConditions", ChildConditions, Delimiter.And, append, out append);
            // CustomFieldConditions
            buildConditionString(options.CustomFieldConditions, "customFieldConditions", CustomFieldConditions, Delimiter.And, append, out append);
            // OrderBy
            buildConditionString(options.OrderBy, "orderBy", OrderBy , append, out append);
            // Fields
            buildConditionString(options.Fields, "fields", Fields, Delimiter.Comma, append, out append);
            // Columns
            buildConditionString(options.Columns, "columns", Columns, Delimiter.Comma, append, out append);
            // Page
            buildConditionString(options.Page, "page", Page.HasValue ? Page.Value.ToString() : null, append, out append);
            // PageSize
            buildConditionString(options.PageSize, "pageSize", PageSize.HasValue ? PageSize.Value.ToString() : null, append, out append);
            // Return
            var final = sb.ToString();
            return string.IsNullOrWhiteSpace(final) ? string.Empty : Uri.EscapeUriString(final);
        }

        internal string ToBodyConditions()
        {
            var body = new CWConditionBody
            {
                Conditions = Conditions != null && Conditions.Any() ? and(Conditions) : null,
                ChildConditions = ChildConditions != null && ChildConditions.Any() ? and(ChildConditions) : null,
                CustomFieldConditions = CustomFieldConditions != null && CustomFieldConditions.Any() ? and(CustomFieldConditions) : null,
                OrderBy = !string.IsNullOrWhiteSpace(OrderBy) ? OrderBy : null
            };
            return JsonConvert.SerializeObject(body);
        }

        internal class CWConditionBody
        {
            public string Conditions { get; set; }

            public string ChildConditions { get; set; }

            public string CustomFieldConditions { get; set; }

            public string OrderBy { get; set; }
        }

        private void buildConditionString(bool option, string name, IEnumerable<string> conditions, Delimiter delim, bool append, out bool appendNext)
        {
            appendNext = append;
            if (option && conditions != null && conditions.Any())
            {
                if (append) sb.Append("&");
                else { appendNext = true; sb.Append("?"); }
                if (delim == Delimiter.Comma) sb.Append($"{name}={string.Join(",", conditions)}");
                else sb.Append($"{name}={and(conditions)}");
            }
        }

        private void buildConditionString(bool option, string name, string condition, bool append, out bool appendNext)
        {
            appendNext = append;
            if (option && !string.IsNullOrWhiteSpace(condition))
            {
                if (append) sb.Append("&");
                else { appendNext = true; sb.Append("?"); }
                sb.Append($"{name}={condition}");
            }
        }

        private string and(IEnumerable<string> enumerable)
        {
            bool didFirst = false;
            string output = string.Empty;
            foreach (var element in enumerable)
            {
                if (!string.IsNullOrWhiteSpace(element))
                {
                    if (didFirst) { output = output + " AND "; } else { didFirst = true; }
                    output = output + element.Trim(' ');
                }
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
