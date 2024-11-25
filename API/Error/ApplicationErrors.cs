using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Error
{
    public class ApplicationErrors(int status,string? message,string? details)
    {
        public int Status { get; set; } = status;
        public string? Message { get; set; } = message;
        public string? Details { get; set; } = details;
    }
}