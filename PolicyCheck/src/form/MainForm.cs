//------------------------------------------------------------------------------
// <copyright file="MainForm.cs" company="MIT">
// Copyright (c) MIT.
// </copyright>
// < summary >
//     MainForm
// </summary>
// <author>Ishihara</author>
// <date>2025-05-21</date>
//------------------------------------------------------------------------------
using PolicyCheck.src.config;
using PolicyCheck.src.module;
using PolicyCheck.src.utilities;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PolicyCheck.src.form
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 設定
        /// </summary>
        private readonly Ini _Config = new Ini();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// MainForm_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Size = new Size(910, 530);

            for (int ii = 0; ii < _Config.CheckPolicyDataList.Count; ii++)
            {
                // KeyName  // ValueName
                DataGridView.Rows.Add(_Config.CheckPolicyDataList[ii].PolicyName, _Config.CheckPolicyDataList[ii].KeyName, _Config.CheckPolicyDataList[ii].ValueName);
                // ValueType
                DataGridView.Rows.Add(string.Empty, string.Empty, _Config.CheckPolicyDataList[ii].ValueType);
                // ValueLength
                DataGridView.Rows.Add(string.Empty, string.Empty, _Config.CheckPolicyDataList[ii].ValueLength);
                // ValueData
                DataGridView.Rows.Add(string.Empty, string.Empty, _Config.CheckPolicyDataList[ii].ValueData);

                DataGridView.Rows[(ii * PolicyKeyValueEnum.End.ToInt()) + PolicyKeyValueEnum.ValueName.ToInt()].HeaderCell.Value = "ValueName";
                DataGridView.Rows[(ii * PolicyKeyValueEnum.End.ToInt()) + PolicyKeyValueEnum.ValueType.ToInt()].HeaderCell.Value = "ValueType";
                DataGridView.Rows[(ii * PolicyKeyValueEnum.End.ToInt()) + PolicyKeyValueEnum.ValueLength.ToInt()].HeaderCell.Value = "ValueLength";
                DataGridView.Rows[(ii * PolicyKeyValueEnum.End.ToInt()) + PolicyKeyValueEnum.ValueData.ToInt()].HeaderCell.Value = "ValueData";
            }
            DataGridView.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }

        /// <summary>
        /// CheckBox_CheckedChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox.Checked)
            {
                this.Size = new Size(910, 780);
            }
            else
            {
                this.Size = new Size(910, 530);
            }
        }

        /// <summary>
        /// Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PolCheckButton_Click(object sender, EventArgs e)
        {
            string shellMessage = ShellExecute();

            SetData(shellMessage);

            ShellScriptTextBox.Text = shellMessage;
        }

        /// <summary>
        /// ps1 shell Execute
        /// </summary>
        /// <returns></returns>
        private string ShellExecute()
        {
            string scriptPath = Path.GetFullPath(_Config.ScriptPath);

            if (!File.Exists(scriptPath))
            {
                MessageBox.Show(scriptPath + Environment.NewLine + "にscriptが存在しません。");
                return string.Empty;
            }

            return PowerShellScript.ProcessStartInfoPowerShell(scriptPath);
        }

        /// <summary>
        /// SetData
        /// </summary>
        /// <param name="argumentInputMessage"></param>
        private void SetData(string argumentInputMessage)
        {
            List<string> blocks = ExtractRegistryBlocks(argumentInputMessage);
            List<PolicyKeyValue> policies = new List<PolicyKeyValue>();

            foreach (var block in blocks)
            {
                PolicyKeyValue entry = ParseRegistryBlock(block);
                policies.Add(entry);
            }

            SetPolicyData(policies);

            CheckPolicyData();
        }

        /// <summary>
        /// SetPolicyData
        /// </summary>
        private void SetPolicyData(List<PolicyKeyValue> policies)
        {
            for (int ii = 0; ii < policies.Count; ii++)
            {
                bool flag = false;

                for (int jj = 0; jj < _Config.CheckPolicyDataList.Count; jj++)
                {
                    // key name の比較
                    if (!StringHelper.IsStringEqual(policies[ii].KeyName, _Config.CheckPolicyDataList[jj].KeyName))
                    {
                        continue;
                    }
                    //ValueName の比較
                    if (!StringHelper.IsStringEqual(policies[ii].ValueName, _Config.CheckPolicyDataList[jj].ValueName))
                    {
                        continue;
                    }

                    DataGridView.Rows[(jj * PolicyKeyValueEnum.End.ToInt()) + PolicyKeyValueEnum.ValueName.ToInt()].Cells[3].Value = policies[ii].ValueName;
                    DataGridView.Rows[(jj * PolicyKeyValueEnum.End.ToInt()) + PolicyKeyValueEnum.ValueType.ToInt()].Cells[3].Value = policies[ii].ValueType;
                    DataGridView.Rows[(jj * PolicyKeyValueEnum.End.ToInt()) + PolicyKeyValueEnum.ValueLength.ToInt()].Cells[3].Value = policies[ii].ValueLength;
                    DataGridView.Rows[(jj * PolicyKeyValueEnum.End.ToInt()) + PolicyKeyValueEnum.ValueData.ToInt()].Cells[3].Value = policies[ii].ValueData;
                    DataGridView.Refresh();
                    flag = true;
                }
                //該当無し
                if (!flag)
                {
                    if (CheckBox.Checked)
                    {
                        //追加
                        AddGridPolicyData(policies[ii]);
                    }
                }
            }
        }

        /// <summary>
        /// AddGridPolicyData
        /// </summary>
        private void AddGridPolicyData(PolicyKeyValue argumentPolicy)
        {
            if (IsPolicyValue(argumentPolicy))
            {
                return;
            }

            const string message = "Policyが設定されていますご確認ください。";
            // KeyName  // ValueName
            DataGridView.Rows.Add(message, argumentPolicy.KeyName, string.Empty, argumentPolicy.ValueName);
            DataGridView.Rows[DataGridView.Rows.Count - 1].HeaderCell.Value = "ValueName";
            // ValueType
            DataGridView.Rows.Add(string.Empty, string.Empty, string.Empty, argumentPolicy.ValueType);
            DataGridView.Rows[DataGridView.Rows.Count - 1].HeaderCell.Value = "ValueType";
            // ValueLength
            DataGridView.Rows.Add(string.Empty, string.Empty, string.Empty, argumentPolicy.ValueLength);
            DataGridView.Rows[DataGridView.Rows.Count - 1].HeaderCell.Value = "ValueLength";
            // ValueData
            DataGridView.Rows.Add(string.Empty, string.Empty, string.Empty, argumentPolicy.ValueData);
            DataGridView.Rows[DataGridView.Rows.Count - 1].HeaderCell.Value = "ValueData";
        }

        /// <summary>
        /// IsPolicyValue
        /// </summary>
        /// <param name="argumentPoliciy"></param>
        /// <returns></returns>
        private bool IsPolicyValue(PolicyKeyValue argumentPoliciy)
        {
            foreach (DataGridViewRow row in DataGridView.Rows)
            {
                //KeyName
                if (!StringHelper.IsStringEqual(row.Cells[1].Value.ToString(), argumentPoliciy.KeyName))
                {
                    continue;
                }
                //ValueName
                if (!StringHelper.IsStringEqual(row.Cells[3].Value.ToString(), argumentPoliciy.ValueName))
                {
                    continue;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// CheckPolicyData
        /// </summary>
        private void CheckPolicyData()
        {
            for (int ii = 0; ii < DataGridView.Rows.Count; ii++)
            {
                string a = DataGridView.Rows[ii].Cells[2].Value?.ToString() ?? string.Empty;
                string b = DataGridView.Rows[ii].Cells[3].Value?.ToString() ?? string.Empty;

                if (StringHelper.IsStringEqual(a, b))
                {
                    DataGridView.Rows[ii].Cells[2].Style.BackColor = Color.Yellow;
                    DataGridView.Rows[ii].Cells[3].Style.BackColor = Color.Yellow;
                }
                else
                {
                    DataGridView.Rows[ii].Cells[2].Style.BackColor = Color.Red;
                    DataGridView.Rows[ii].Cells[3].Style.BackColor = Color.Red;
                }
            }
        }

        /// <summary>
        /// ExtractRegistryBlocks
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private List<string> ExtractRegistryBlocks(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return new List<string>();

            int keyStartIndex = input.IndexOf("KeyName");
            if (keyStartIndex < 0)
                return new List<string>();

            string registryData = input.Substring(keyStartIndex).Trim();

            // レジストリブロックを空行で区切る
            List<string> blocks = Regex.Split(registryData, @"\r?\n\r?\n")
                              .Where(b => !string.IsNullOrWhiteSpace(b))
                              .ToList();

            return blocks;
        }

        /// <summary>
        /// ParseRegistryBlock
        /// </summary>
        /// <param name="block"></param>
        /// <returns></returns>
        private PolicyKeyValue ParseRegistryBlock(string block)
        {
            PolicyKeyValue entry = new PolicyKeyValue();
            string[] lines = block.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                var (key, value) = ParseLine(line);
                switch (key)
                {
                    case "KeyName": entry.KeyName = value; break;
                    case "ValueName": entry.ValueName = value; break;
                    case "ValueType": entry.ValueType = value; break;
                    case "ValueLength": entry.ValueLength = value; break;
                    case "ValueData": entry.ValueData = value; break;
                }
            }

            return entry;
        }

        /// <summary>
        /// ParseLine
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private (string key, string value) ParseLine(string line)
        {
            string[] parts = line.Split(new[] { ':' }, 2);
            if (parts.Length != 2)
                return (string.Empty, string.Empty);

            return (parts[0].Trim(), parts[1].Trim());
        }

        /// <summary>
        /// RsopButton_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RsopButton_Click(object sender, EventArgs e)
        {
            Process.Start("rsop.msc");
        }

        /// <summary>
        /// GpeditButton_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GpeditButton_Click(object sender, EventArgs e)
        {
            Process.Start("gpedit.msc");
        }
    }
}