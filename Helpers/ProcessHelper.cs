using System;
using System.Diagnostics;

namespace frm_ecopaste.Helpers
{
    internal static class ProcessHelper
    {
        public static void KillByName(string processName)
        {
            foreach (Process process in Process.GetProcessesByName(processName))
            {
                try
                {
                    process.Kill();
                    process.WaitForExit(5000);
                }
                catch (Exception)
                {
                    // Process may have already exited between GetProcessesByName and Kill().
                }
                finally
                {
                    process.Dispose();
                }
            }
        }

        public static bool IsRunning(string processName)
        {
            Process[] processes = Process.GetProcessesByName(processName);
            bool running = processes.Length > 0;

            foreach (Process process in processes)
            {
                process.Dispose();
            }

            return running;
        }
    }
}
