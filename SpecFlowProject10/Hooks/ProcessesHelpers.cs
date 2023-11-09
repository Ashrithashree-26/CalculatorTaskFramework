using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Hooks
{
    public class ProcessesHelpers
    {
        public static Process GetProcessByName(string processName)
        {
            return Process.GetProcessesByName(processName).FirstOrDefault();
        }
        public static bool ProcessExists(string processName)
        {
            return GetProcessByName(processName) != null;
        }
        public void KillMultipleInstancesOfProcess(string processName)
        {
            Process[] processes = Process.GetProcessesByName(processName);
            foreach (Process process in processes)
            {
                process.Kill();
                process.Dispose();

            }
        }
    }
}
