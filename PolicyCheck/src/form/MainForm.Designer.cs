
namespace PolicyCheck.src.form
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PolCheckButton = new System.Windows.Forms.Button();
            this.ShellScriptTextBox = new System.Windows.Forms.TextBox();
            this.Shelllabel = new System.Windows.Forms.Label();
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.PolicyNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KeyNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpectedValueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckBox = new System.Windows.Forms.CheckBox();
            this.RsopButton = new System.Windows.Forms.Button();
            this.GpeditButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // PolCheckButton
            // 
            this.PolCheckButton.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PolCheckButton.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.PolCheckButton.Location = new System.Drawing.Point(728, 5);
            this.PolCheckButton.Name = "PolCheckButton";
            this.PolCheckButton.Size = new System.Drawing.Size(154, 43);
            this.PolCheckButton.TabIndex = 0;
            this.PolCheckButton.Text = "Pol Check";
            this.PolCheckButton.UseVisualStyleBackColor = true;
            this.PolCheckButton.Click += new System.EventHandler(this.PolCheckButton_Click);
            // 
            // ShellScriptTextBox
            // 
            this.ShellScriptTextBox.Location = new System.Drawing.Point(5, 558);
            this.ShellScriptTextBox.Multiline = true;
            this.ShellScriptTextBox.Name = "ShellScriptTextBox";
            this.ShellScriptTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ShellScriptTextBox.Size = new System.Drawing.Size(878, 176);
            this.ShellScriptTextBox.TabIndex = 1;
            // 
            // Shelllabel
            // 
            this.Shelllabel.AutoSize = true;
            this.Shelllabel.Location = new System.Drawing.Point(3, 543);
            this.Shelllabel.Name = "Shelllabel";
            this.Shelllabel.Size = new System.Drawing.Size(97, 12);
            this.Shelllabel.TabIndex = 2;
            this.Shelllabel.Text = "Shell Script result";
            // 
            // DataGridView
            // 
            this.DataGridView.AllowUserToAddRows = false;
            this.DataGridView.AllowUserToDeleteRows = false;
            this.DataGridView.AllowUserToResizeRows = false;
            this.DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DataGridView.BackgroundColor = System.Drawing.Color.White;
            this.DataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PolicyNameColumn,
            this.KeyNameColumn,
            this.ExpectedValueColumn,
            this.ValueColumn});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridView.Location = new System.Drawing.Point(5, 54);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.ReadOnly = true;
            this.DataGridView.RowTemplate.Height = 21;
            this.DataGridView.Size = new System.Drawing.Size(878, 433);
            this.DataGridView.TabIndex = 3;
            // 
            // PolicyNameColumn
            // 
            this.PolicyNameColumn.HeaderText = "PolicyName";
            this.PolicyNameColumn.Name = "PolicyNameColumn";
            this.PolicyNameColumn.ReadOnly = true;
            this.PolicyNameColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // KeyNameColumn
            // 
            this.KeyNameColumn.HeaderText = "KeyName";
            this.KeyNameColumn.Name = "KeyNameColumn";
            this.KeyNameColumn.ReadOnly = true;
            this.KeyNameColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ExpectedValueColumn
            // 
            this.ExpectedValueColumn.HeaderText = "Expected Value";
            this.ExpectedValueColumn.Name = "ExpectedValueColumn";
            this.ExpectedValueColumn.ReadOnly = true;
            this.ExpectedValueColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ValueColumn
            // 
            this.ValueColumn.HeaderText = "Value";
            this.ValueColumn.Name = "ValueColumn";
            this.ValueColumn.ReadOnly = true;
            this.ValueColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CheckBox
            // 
            this.CheckBox.AutoSize = true;
            this.CheckBox.Location = new System.Drawing.Point(14, 22);
            this.CheckBox.Name = "CheckBox";
            this.CheckBox.Size = new System.Drawing.Size(79, 16);
            this.CheckBox.TabIndex = 4;
            this.CheckBox.Text = "DBG Mode";
            this.CheckBox.UseVisualStyleBackColor = true;
            this.CheckBox.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // RsopButton
            // 
            this.RsopButton.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.RsopButton.ForeColor = System.Drawing.Color.Black;
            this.RsopButton.Location = new System.Drawing.Point(5, 497);
            this.RsopButton.Name = "RsopButton";
            this.RsopButton.Size = new System.Drawing.Size(154, 43);
            this.RsopButton.TabIndex = 5;
            this.RsopButton.Text = "rsop.msc";
            this.RsopButton.UseVisualStyleBackColor = true;
            this.RsopButton.Click += new System.EventHandler(this.RsopButton_Click);
            // 
            // GpeditButton
            // 
            this.GpeditButton.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GpeditButton.ForeColor = System.Drawing.Color.Black;
            this.GpeditButton.Location = new System.Drawing.Point(165, 497);
            this.GpeditButton.Name = "GpeditButton";
            this.GpeditButton.Size = new System.Drawing.Size(154, 43);
            this.GpeditButton.TabIndex = 6;
            this.GpeditButton.Text = "gpedit.msc";
            this.GpeditButton.UseVisualStyleBackColor = true;
            this.GpeditButton.Click += new System.EventHandler(this.GpeditButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(894, 741);
            this.Controls.Add(this.GpeditButton);
            this.Controls.Add(this.RsopButton);
            this.Controls.Add(this.CheckBox);
            this.Controls.Add(this.DataGridView);
            this.Controls.Add(this.Shelllabel);
            this.Controls.Add(this.ShellScriptTextBox);
            this.Controls.Add(this.PolCheckButton);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "PolicyCheck";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PolCheckButton;
        private System.Windows.Forms.TextBox ShellScriptTextBox;
        private System.Windows.Forms.Label Shelllabel;
        private System.Windows.Forms.DataGridView DataGridView;
        private System.Windows.Forms.CheckBox CheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn PolicyNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeyNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpectedValueColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueColumn;
        private System.Windows.Forms.Button RsopButton;
        private System.Windows.Forms.Button GpeditButton;
    }
}

