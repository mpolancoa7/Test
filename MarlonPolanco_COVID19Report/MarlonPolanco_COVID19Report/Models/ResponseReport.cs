using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarlonPolanco_COVID19Report
{
    /// <summary>
    /// Class for response of report
    /// </summary>
    public class ResponseReport
    {
        public string Regions { get; set; }
        public int Cases { get; set; }
        public int Deaths { get; set; }
    }
}