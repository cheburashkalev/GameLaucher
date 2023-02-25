//using IWshRuntimeLibrary;
using Microsoft.Win32;
using System;
using IWshRuntimeLibrary;
using static StaticPinvoke;

public static class Win32Helper
{
    static Win32Helper()
    {
        //软件启动就获取主窗口句柄
        CurrentWindowHandle = GetForegroundWindow();
    }
    public static IntPtr CurrentWindowHandle { get; }

    /// <summary>
    /// 隐藏任务栏图标
    /// </summary>
    public static void HideTaskBar()
    {
        try
        {
            ShowWindow(CurrentWindowHandle, (uint)ShowWindowCommands.SW_HIDE);
        }
        catch (Exception e)
        {
           // Debug.LogError(e.Message);
        }
    }
    /// <summary>
    /// 显示任务栏图标
    /// </summary>
    public static void ShowTaskBar()
    {
        try
        {
            ShowWindow(CurrentWindowHandle, (uint)ShowWindowCommands.SW_RESTORE);
            SetForegroundWindow(CurrentWindowHandle);
        }
        catch (Exception e)
        {
           // Debug.LogError(e.Message);
        }
    }

    /// <summary>
    /// 添加系统启动项
    /// </summary>
    /// <remarks>
    /// If disabled in taskmanager, entry gets added but key value will remain disabled.
    /// </remarks>
    /// <param name="val">true: set entry, false: delete entry.</param>
    public static void SetStartup(bool val)
    {
        //create shortcut first, overwrite if exist with new path.
        CreateShortcut();
        RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        if (val)
        {
          rk.SetValue(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName, System.AppDomain.CurrentDomain.BaseDirectory + "\\GameChainLauncher.lnk");
        }
        else
        {
            rk.DeleteValue(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName, false);
        }
        rk.Close();
    }
    public static bool GetStartup()
    {
        //create shortcut first, overwrite if exist with new path.

        RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        bool returnC = rk.GetValue(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName).ToString()!= String.Empty;
        rk.Close();
        return returnC;
    }

    /// <summary>
    /// Creates application shortcut to link to windows startup in registry.
    /// </summary>
    private static void CreateShortcut()
    {
        try
        {
           WshShell shell = new WshShell();
           var shortCutLinkFilePath = System.AppDomain.CurrentDomain.BaseDirectory + "\\GameChainLauncher.lnk";
           var windowsApplicationShortcut = (IWshShortcut)shell.CreateShortcut(shortCutLinkFilePath);
           windowsApplicationShortcut.Description = "Fast load Game launcher";
           windowsApplicationShortcut.WorkingDirectory = System.IO.Directory.GetParent(System.AppDomain.CurrentDomain.BaseDirectory).ToString();
           windowsApplicationShortcut.TargetPath = System.IO.Directory.GetParent(System.AppDomain.CurrentDomain.BaseDirectory).ToString() + "\\FlaxGame.exe";
           windowsApplicationShortcut.Save();
        }
        catch (Exception ex)
        {
            //  Debug.LogError(ex.Message);
        }
    }
}
