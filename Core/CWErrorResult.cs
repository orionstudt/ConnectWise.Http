using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWise.Http
{
    public class CWErrorResult
    {
        public string Code { get; private set; }

        public string Message { get; private set; }

        public List<CWError> Errors { get; private set; }

        internal CWErrorResult() { }

        internal CWErrorResult(string code, string message)
        {
            Code = code;
            Message = message;
            Errors = new List<CWError>();
        }
    }

    public class CWError
    {
        public string Code { get; private set; }

        public string Message { get; private set; }

        public string Resource { get; private set; }

        public string Field { get; private set; }

        internal CWError() { }
    }
}
