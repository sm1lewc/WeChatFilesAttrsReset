namespace WeChatFilesAttrsReset
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            WFARnotify = new NotifyIcon(components);
            btnOK = new Button();
            txbFile = new TextBox();
            lblTag = new Label();
            notifyMenu = new ContextMenuStrip(components);
            nm_Show = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            nm_Exit = new ToolStripMenuItem();
            notifyMenu.SuspendLayout();
            SuspendLayout();
            // 
            // WFARnotify
            // 
            WFARnotify.ContextMenuStrip = notifyMenu;
            WFARnotify.Icon = (Icon)resources.GetObject("WFARnotify.Icon");
            WFARnotify.Text = "微信文件去除只读";
            WFARnotify.Visible = true;
            WFARnotify.DoubleClick += WFARnotify_DoubleClick;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(224, 60);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 1;
            btnOK.Text = "确定";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // txbFile
            // 
            txbFile.Location = new Point(9, 10);
            txbFile.Name = "txbFile";
            txbFile.Size = new Size(291, 23);
            txbFile.TabIndex = 2;
            txbFile.Text = "输入微信文件路径";
            txbFile.Enter += txbFile_Enter;
            txbFile.Leave += txbFile_Leave;
            // 
            // lblTag
            // 
            lblTag.AutoSize = true;
            lblTag.ForeColor = Color.RoyalBlue;
            lblTag.Location = new Point(8, 38);
            lblTag.Name = "lblTag";
            lblTag.Size = new Size(292, 17);
            lblTag.TabIndex = 3;
            lblTag.Text = "微信-设置-文件管理-打开文件夹-复制地址栏中的路径";
            // 
            // notifyMenu
            // 
            notifyMenu.Items.AddRange(new ToolStripItem[] { nm_Show, toolStripSeparator1, nm_Exit });
            notifyMenu.Name = "notifyMenu";
            notifyMenu.Size = new Size(101, 54);
            // 
            // nm_Show
            // 
            nm_Show.Name = "nm_Show";
            nm_Show.Size = new Size(100, 22);
            nm_Show.Text = "显示";
            nm_Show.Click += nm_Show_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(97, 6);
            // 
            // nm_Exit
            // 
            nm_Exit.Name = "nm_Exit";
            nm_Exit.Size = new Size(100, 22);
            nm_Exit.Text = "退出";
            nm_Exit.Click += nm_Exit_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(307, 91);
            Controls.Add(lblTag);
            Controls.Add(txbFile);
            Controls.Add(btnOK);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "微信文件去除只读";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            notifyMenu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NotifyIcon WFARnotify;
        private Button btnOK;
        private TextBox txbFile;
        private Label lblTag;
        private ContextMenuStrip notifyMenu;
        private ToolStripMenuItem nm_Show;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem nm_Exit;
    }
}