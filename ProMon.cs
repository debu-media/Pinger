using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Pinger
{
    class ProMon
    {
        public bool GetProcessStatus(string proces)
        {
            Process[] pname = Process.GetProcessesByName(proces);
            if (pname.Length == 0)
            {
                return false;
            }
            else { return true; }

        }
    }
}
