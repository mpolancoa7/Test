using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarlonPolanco_COVID19Report.Models
{
    /// <summary>
    /// Classes for get regions
    /// </summary>
    public class RootRegion
    {
        public List<DatumRegion> data { get; set; }
    }
    public class DatumRegion
    {
        public string iso { get; set; }
        public string name { get; set; }
    }
}