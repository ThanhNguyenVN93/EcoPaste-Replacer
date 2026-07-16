using Microsoft.Win32;

namespace frm_ecopaste.Helpers
{
    /// <summary>
    /// Pipeline step 1: lock Windows Clipboard History (Win+V) via the registry.
    /// </summary>
    internal static class RegistryHelper
    {
        public static void DisableWindowsClipboardHistory()
        {
            using (RegistryKey clipboardKey = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Clipboard"))
            {
                clipboardKey.SetValue("EnableClipboardHistory", 0, RegistryValueKind.DWord);
            }

            using (RegistryKey policyKey = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\System"))
            {
                policyKey.SetValue("AllowClipboardHistory", 0, RegistryValueKind.DWord);
            }
        }

        public static void SetAutoStart(string name, string exePath)
        {
            using (RegistryKey runKey = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run"))
            {
                runKey.SetValue(name, "\"" + exePath + "\"", RegistryValueKind.String);
            }
        }
    }
}
