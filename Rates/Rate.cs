using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rates
{
    public enum Pairs { EURNZD, NZDUSD }
    class Rate
    {
        public double Ask { get; set; }
        public double Bid { get; set; }
        public DateTime Date { get; set; }
    }
}
