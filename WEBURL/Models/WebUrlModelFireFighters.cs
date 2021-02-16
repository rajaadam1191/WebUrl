using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBURL.Models
{
    public class WebUrlModelFireFighters
    {
        public int FFsno { get; set; }
        public string FFname { get; set; }
        public string FFdepartment { get; set; }
        public string FFpunchcount { get; set; }

        public IEnumerable<WebUrlModelFireFighters> WUVTabledatafromdbFireFighters { get; set; }
        public IEnumerable<WebUrlModelFireAiders> WUVTabledatafromdbFireAiders { get; set; }
    }
}