using Parser.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Core
{
    public class Result<T> where T : class
    {
        public Status Status { get; set; }
        public string Message { get; set; }
        public T Body { get; set; }
        public Result(Status status, T body)
        {
            Status = status;
            Body = body;
        }
        public Result(Status status, string message)
        {
            Status = status;
            Message = message;
        }
    }
}
