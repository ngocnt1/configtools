using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerScriptAgent.Entities
{
    public class BaseItem
    {
        public BaseItem()
        {
            GenID(DateTime.UtcNow);
        }

        public BaseItem(DateTime date)
        {
            GenID(date);
        }

        void GenID(DateTime date)
        {
            //YYYYMMDDhhmmss
            TimeTick = date.Year * 10000000000 +
                date.Month * 1000000 + 
                date.Day *   10000 +
                date.Minute* 100 + 
                date.Second;
        }

        public virtual long TimeTick
        {
            get;
            private set;
        }

        public virtual double Value
        {
            get;
            set;
        }
    }
}
