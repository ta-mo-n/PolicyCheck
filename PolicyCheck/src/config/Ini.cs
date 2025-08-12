//------------------------------------------------------------------------------
// <copyright file="Ini.cs" company="MIT">
// Copyright (c) MIT.
// </copyright>
// < summary >
//     INI
// </summary>
// <author>Ishihara</author>
// <date>2025-05-21</date>
//------------------------------------------------------------------------------
using PolicyCheck.src.module;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

using static PolicyCheck.src.utilities.WinAPI;

namespace PolicyCheck.src.config
{
    public class Ini
    {
        /// <summary>
        ///  設定ファイル名
        /// </summary>
        private const string APPINITCONFIG = "PolicyCheck.ini";

        /// <summary>
        /// DEFAULTSCRIPTPATH
        /// </summary>
        private const string DEFAULTSCRIPTPATH = "./script/GetPolcyScript.ps1";

        /// <summary>
        /// INI読み込みサイズ
        /// </summary>
        private const int BUFFSIZE = 500;

        /// <summary>
        /// スクリプトパス
        /// </summary>
        private string _scriptPath;

        /// <summary>
        /// チェック元のデータ
        /// </summary>
        private readonly List<PolicyKeyValue> _CheckPolicyDataList = new List<PolicyKeyValue>();

        /// <summary>
        /// チェック元のデータ
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Roslynator", "RCS1085:Use auto-implemented property")]
        public List<PolicyKeyValue> CheckPolicyDataList
        {
            get => _CheckPolicyDataList;
        }

        /// <summary>
        /// スクリプトパス
        /// </summary>
        public string ScriptPath
        {
            get => _scriptPath;
        }

        /// <summary>
        /// 設定ファイル
        /// </summary>
        public Ini()
        {
            SetAppCurrentDirectory();
            Read();
        }

        /// <summary>
        /// SetCurrentDirectory
        /// </summary>
        private void SetAppCurrentDirectory()
        {
            string newDirectory = Application.StartupPath;
            Directory.SetCurrentDirectory(newDirectory);
        }

        /// <summary>
        /// 設定ファイル読み込み
        /// </summary>
        private void Read()
        {
            const int capacitySize = BUFFSIZE;
            StringBuilder sb = new StringBuilder(capacitySize);
            string appPath = Application.StartupPath;
            string iniPath = Path.Combine(appPath, APPINITCONFIG);

            GetPrivateProfileString("script", "path", DEFAULTSCRIPTPATH, sb, Convert.ToUInt32(sb.Capacity), iniPath);
            _scriptPath = sb.ToString();

            GetPrivateProfileString("policy", "polnum", DEFAULTSCRIPTPATH, sb, Convert.ToUInt32(sb.Capacity), iniPath);
            int polnum = int.Parse(sb.ToString());

            for (int ii = 0; ii < polnum; ii++)
            {
                string kyeString = "pol" + (ii + 1).ToString("D2");
                GetPrivateProfileString("policy", kyeString, DEFAULTSCRIPTPATH, sb, Convert.ToUInt32(sb.Capacity), iniPath);

                SetCheckPolicyDataList(sb.ToString());
            }
        }

        /// <summary>
        /// SetCheckPolicyDataList
        /// </summary>
        /// <param name="str"></param>
        private void SetCheckPolicyDataList(string str)
        {
            string[] data = str.Split(',');

            PolicyKeyValue set = new PolicyKeyValue
            {
                PolicyName = data[0],
                KeyName = data[1],
                ValueName = data[2],
                ValueType = data[3],
                ValueLength = data[4],
                ValueData = data[5],
            };
            _CheckPolicyDataList.Add(set);
        }
    }
}
