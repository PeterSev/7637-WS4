using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace _7637_WS4
{
    public static class Utils
    {
        public static bool isFileExist(string filename)
        {
            if (!File.Exists(Application.StartupPath + "\\" + filename))
                return false;
            return true;
        }

        public static void KillProcess(string processName)
        {
            //processName = "calc";
            Process[] procs = Process.GetProcessesByName(processName);
            foreach (Process p in procs)
                p.Kill();
        }

        public static void WriteLineToFile(string fullFileName, string message)
        {
            using (StreamWriter sw = new StreamWriter(fullFileName, true))
            {
                sw.WriteLine(String.Format("{0, -23}    {1}", DateTime.Now.ToString() + ":", message));
            }
        }
    }
}
