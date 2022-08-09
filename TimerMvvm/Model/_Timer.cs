using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerMvvm.Model
{
    public class _Timer
    {
        #region Members
        string time_now;
        #endregion

        #region Properties
        public string setTimer
        {
            get { return time_now; }
            set { time_now = value; }
        }
        #endregion
    }
}
