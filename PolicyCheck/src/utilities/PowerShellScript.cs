//------------------------------------------------------------------------------
// <copyright file="PowerShellScript.cs" company="MIT">
// Copyright (c) MIT.
// </copyright>
// < summary >
//     PowerShellScript
// </summary>
// <author>Ishihara</author>
// <date>2025-05-21</date>
//------------------------------------------------------------------------------
using System.Diagnostics;

namespace PolicyCheck.src.utilities
{
    internal static class PowerShellScript
    {
        /// <summary>
        /// PowerShellScript
        /// </summary>
        /// <param name="scriptPath"></param>
        /// <returns></returns>
        public static string ProcessStartInfoPowerShell(string scriptPath)
        {
            string resultMessage = string.Empty;

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = $"-ExecutionPolicy Bypass -File \"{scriptPath}\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(psi))
            {
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();
#if DEBUG
                Console.WriteLine("Output:\n" + output);
                Console.WriteLine("Error:\n" + error);
#endif
                resultMessage = output;
            }

            return resultMessage;
        }
    }
}
