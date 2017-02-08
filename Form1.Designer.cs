namespace KuGou_MP3_LinearChain
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BTN_搜索音乐 = new System.Windows.Forms.Button();
            this.TXT_音乐名 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TXT_url = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listView1.Location = new System.Drawing.Point(21, 52);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(703, 228);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "文件名";
            this.columnHeader1.Width = 233;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "歌曲名";
            this.columnHeader2.Width = 159;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "歌手名";
            this.columnHeader3.Width = 115;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "比特率";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "时长";
            this.columnHeader5.Width = 83;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "音乐直链";
            this.columnHeader6.Width = 0;
            // 
            // BTN_搜索音乐
            // 
            this.BTN_搜索音乐.Location = new System.Drawing.Point(47, 12);
            this.BTN_搜索音乐.Name = "BTN_搜索音乐";
            this.BTN_搜索音乐.Size = new System.Drawing.Size(75, 23);
            this.BTN_搜索音乐.TabIndex = 3;
            this.BTN_搜索音乐.Text = "搜索音乐";
            this.BTN_搜索音乐.UseVisualStyleBackColor = true;
            this.BTN_搜索音乐.Click += new System.EventHandler(this.button1_Click);
            // 
            // TXT_音乐名
            // 
            this.TXT_音乐名.Location = new System.Drawing.Point(208, 12);
            this.TXT_音乐名.Name = "TXT_音乐名";
            this.TXT_音乐名.Size = new System.Drawing.Size(198, 21);
            this.TXT_音乐名.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(152, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "音乐名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 308);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "音乐直链";
            // 
            // TXT_url
            // 
            this.TXT_url.Location = new System.Drawing.Point(117, 305);
            this.TXT_url.Name = "TXT_url";
            this.TXT_url.Size = new System.Drawing.Size(460, 21);
            this.TXT_url.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(172, 339);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(281, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "可在浏览器中直接打开直链，以便测试直链是否可用\r\n";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 385);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TXT_url);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TXT_音乐名);
            this.Controls.Add(this.BTN_搜索音乐);
            this.Controls.Add(this.listView1);
            this.Name = "Form1";
            this.Text = "酷狗音乐直链——可用作空间背景音乐";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button BTN_搜索音乐;
        private System.Windows.Forms.TextBox TXT_音乐名;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TXT_url;
        private System.Windows.Forms.Label label3;
    }
}

