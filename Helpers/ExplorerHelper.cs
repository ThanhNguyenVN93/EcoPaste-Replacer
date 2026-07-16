using System.Diagnostics;

namespace frm_ecopaste.Helpers
{
    /// <summary>
    /// Pipeline step 2: restart explorer.exe to apply the Win+V registry change immediately.
    /// </summary>
    internal static class ExplorerHelper
    {
        public static void Restart()
        {
            ProcessHelper.KillByName("explorer");
            Process.Start("explorer.exe");
        }
    }
}
