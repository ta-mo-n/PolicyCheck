//------------------------------------------------------------------------------
// <copyright file="WinApi.cs" company="MIT">
// Copyright (c) MIT.
// </copyright>
// < summary >
//     WindowsAPIクラスを定義します
// </summary>
// <author>Ishihara</author>
// <date>2025-05-21</date>
//------------------------------------------------------------------------------
using System.Runtime.InteropServices;
using System.Text;

namespace PolicyCheck.src.utilities
{
    public static class WinAPI
    {
        #region WinAPI
        /// <summary>
        /// INIファイルから指定されたセクションとキーの値を取得します。
        /// </summary>
        /// <param name="lpAppName"></param>
        /// <param name="lpKeyName"></param>
        /// <param name="lpDefault"></param>
        /// <param name="lpReturnedString"></param>
        /// <param name="nSize"></param>
        /// <param name="lpFileName"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileStringW", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern uint GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault,
                                                          StringBuilder lpReturnedString, uint nSize, string lpFileName);
        #endregion

    }
}
