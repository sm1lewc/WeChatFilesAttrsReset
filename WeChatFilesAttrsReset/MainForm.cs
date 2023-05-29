namespace WeChatFilesAttrsReset
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 微信文件路径的一部分
        /// </summary>
        const string PartFile = @"\FileStorage\File";
        /// <summary>
        /// 配置文件路径
        /// </summary>
        readonly string ConfigPath = $"{Environment.CurrentDirectory}\\WeChatFilesAttrsResetConfig.ini";
        /// <summary>
        /// 属性监视
        /// </summary>
        readonly FileSystemWatcher _watcherAttr= new FileSystemWatcher();

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!CheckFile())
            {
                MessageBox.Show("文件路径不正确");
            }
            else
            {
                HideForm();
                if (_watcherAttr.EnableRaisingEvents == true)
                {
                    _watcherAttr.EnableRaisingEvents = false;
                }
                _watcherAttr.Path = txbFile.Text + PartFile;
                _watcherAttr.EnableRaisingEvents = true;
                File.WriteAllText(ConfigPath, txbFile.Text);
            }
        }

        private bool CheckFile()
        {
            if (txbFile.Text.Trim() == "输入微信文件路径") return false;
            if (Directory.Exists(txbFile.Text.Trim()) == false || Directory.Exists(txbFile.Text.Trim() + PartFile) == false) return false;
            return true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            btnOK.Enabled = false;
            txbFile.ForeColor = Color.Gray;

            _watcherAttr.IncludeSubdirectories = true;
            _watcherAttr.NotifyFilter = NotifyFilters.Attributes;
                                 //| NotifyFilters.FileName
                                 //| NotifyFilters.Size;
            _watcherAttr.Created += _watcherAttr_Created;
            _watcherAttr.Changed += _watcherAttr_Changed;

            var config = Init();
            if (!string.IsNullOrEmpty(config))
            {
                txbFile.Text = config;
                txbFile.ForeColor = Color.Black;
            }
            btnOK.Enabled = true;
        }

        private void _watcherAttr_Changed(object sender, FileSystemEventArgs e)
        {
            ResetAttr(e.FullPath);
        }

        private void _watcherAttr_Created(object sender, FileSystemEventArgs e)
        {
            ResetAttr(e.FullPath);
        }

        private void ResetAttr(string fullPath)
        {
            try
            {
                File.SetAttributes(fullPath, FileAttributes.Normal);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message);
            }
        }


        private string Init()
        {
            using var fs = new FileStream(ConfigPath, FileMode.OpenOrCreate, FileAccess.Read);
            using var sr = new StreamReader(fs);
            string strConfig = sr.ReadToEnd();
            return strConfig;
        }

        private void txbFile_Enter(object sender, EventArgs e)
        {
            if (txbFile.Text == "输入微信文件路径")
            {
                txbFile.ForeColor = Color.Black;
                txbFile.Text = string.Empty;
            }
        }

        private void txbFile_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbFile.Text.Trim()))
            {
                txbFile.ForeColor = Color.Gray;
                txbFile.Text = "输入微信文件路径";
            }
        }

        private void WFARnotify_DoubleClick(object sender, EventArgs e)
        {
            ShowForm();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            HideForm();
        }

        private void HideForm()
        {
            this.Hide();
            WFARnotify.ShowBalloonTip(1000, "微信文件去除只读", "后台运行", ToolTipIcon.Info);
        }

        private void ShowForm()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Focus();
        }

        private void nm_Show_Click(object sender, EventArgs e)
        {
            ShowForm();
        }

        private void nm_Exit_Click(object sender, EventArgs e)
        {
            //_watcherFile.EnableRaisingEvents = false;
            _watcherAttr.EnableRaisingEvents = false;
            Environment.Exit(0);
        }
    }
}
