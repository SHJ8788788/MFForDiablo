namespace MFForD
{
    partial class FormYMR
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormYMR));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.timerL = new System.Windows.Forms.Timer(this.components);
            this.timerR = new System.Windows.Forms.Timer(this.components);
            this.NotifyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripTextBoxWinName = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripTextBoxStatus = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.startToolStripMenuItemStart = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItemStop = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.NotifyMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 801;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Interval = 1000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // timer4
            // 
            this.timer4.Interval = 400;
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // timerL
            // 
            this.timerL.Interval = 110;
            this.timerL.Tick += new System.EventHandler(this.timerL_Tick);
            // 
            // timerR
            // 
            this.timerR.Interval = 620;
            this.timerR.Tick += new System.EventHandler(this.timerR_Tick);
            // 
            // NotifyMenu
            // 
            this.NotifyMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.NotifyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxWinName,
            this.toolStripTextBoxStatus,
            this.toolStripSeparator1,
            this.startToolStripMenuItemStart,
            this.stopToolStripMenuItemStop,
            this.exitToolStripMenuItemExit});
            this.NotifyMenu.Name = "NotifyMenu";
            this.NotifyMenu.Size = new System.Drawing.Size(161, 140);
            // 
            // toolStripTextBoxWinName
            // 
            this.toolStripTextBoxWinName.Name = "toolStripTextBoxWinName";
            this.toolStripTextBoxWinName.Size = new System.Drawing.Size(100, 27);
            this.toolStripTextBoxWinName.Text = "暗黑破坏神III";
            // 
            // toolStripTextBoxStatus
            // 
            this.toolStripTextBoxStatus.Name = "toolStripTextBoxStatus";
            this.toolStripTextBoxStatus.ReadOnly = true;
            this.toolStripTextBoxStatus.Size = new System.Drawing.Size(100, 27);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
            // 
            // startToolStripMenuItemStart
            // 
            this.startToolStripMenuItemStart.Name = "startToolStripMenuItemStart";
            this.startToolStripMenuItemStart.Size = new System.Drawing.Size(160, 24);
            this.startToolStripMenuItemStart.Text = "Start";
            this.startToolStripMenuItemStart.Click += new System.EventHandler(this.startToolStripMenuItemStart_Click);
            // 
            // stopToolStripMenuItemStop
            // 
            this.stopToolStripMenuItemStop.Name = "stopToolStripMenuItemStop";
            this.stopToolStripMenuItemStop.Size = new System.Drawing.Size(160, 24);
            this.stopToolStripMenuItemStop.Text = "Stop";
            this.stopToolStripMenuItemStop.Click += new System.EventHandler(this.stopToolStripMenuItemStop_Click);
            // 
            // exitToolStripMenuItemExit
            // 
            this.exitToolStripMenuItemExit.Name = "exitToolStripMenuItemExit";
            this.exitToolStripMenuItemExit.Size = new System.Drawing.Size(160, 24);
            this.exitToolStripMenuItemExit.Text = "Exit";
            this.exitToolStripMenuItemExit.Click += new System.EventHandler(this.exitToolStripMenuItemExit_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.NotifyMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "notifyIcon1";
            this.notifyIcon.Visible = true;
            // 
            // FormYMR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(88, 80);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormYMR";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.NotifyMenu.ResumeLayout(false);
            this.NotifyMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.Timer timerL;
        private System.Windows.Forms.Timer timerR;
        private System.Windows.Forms.ContextMenuStrip NotifyMenu;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItemStart;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItemStop;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItemExit;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxStatus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxWinName;
    }
}

