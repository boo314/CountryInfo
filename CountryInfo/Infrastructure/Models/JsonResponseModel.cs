using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CountryInfo.Infrastructure.Models
{
    public class JsonResponseModel
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public DateTime Date { get; set; }
    }
}