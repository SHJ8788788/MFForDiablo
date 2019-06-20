using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MFForD
{
    public partial class FormHF : FormSTATE
    {
        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", EntryPoint = "keybd_event", SetLastError = true)] 
        public static extern void keybd_event(Keys bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

        public const int KEYEVENTF_KEYUP = 2;
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;                             //最左坐标
            public int Top;                             //最上坐标
            public int Right;                           //最右坐标
            public int Bottom;                        //最下坐标
        }

        //private MouseKeyHook mouseKeyHook1 = new MouseKeyHook(true, true);//鼠标，键盘

        private bool runFlag = false;
        private KeyboardHook k_hook;
        public FormHF()
        {
            InitializeComponent();
            //mouseKeyHook1.KeyDown += new KeyEventHandler(Form1_KeyDown);
            //mouseKeyHook1.KeyPress += new KeyPressEventHandler(mouseKeyHook1_KeyPress);
            //mouseKeyHook1.KeyUp += new KeyEventHandler(mouseKeyHook1_KeyUp);
            //mouseKeyHook1.OnMouseActivity += new MouseEventHandler(Form1_MouseDown);
            //mouseKeyHook1.OnMouseActivity += new MouseEventHandler(Form1_MouseDown);

            //还原窗体显示    
            //WindowState = FormWindowState.Minimized;
            //激活窗体并给予它焦点
            this.Activate();
            //任务栏区显示图标
            this.ShowInTaskbar = false;
            //托盘区图标隐藏
            notifyIcon.Visible = true;

        }

  

        private void Form1_Load(object sender, EventArgs e)
        {
            k_hook = new KeyboardHook();
            k_hook.KeyDownEvent += new System.Windows.Forms.KeyEventHandler(hook_KeyDown);//钩住键按下 
            k_hook.KeyPressEvent += K_hook_KeyPressEvent;
            k_hook.KeyUpEvent += K_hook_KeyUpEvent;
            k_hook.Start();//安装键盘钩子
            startToolStripMenuItemStart.Enabled = false;
            stopToolStripMenuItemStop.Enabled = true;

            if (k_hook.HookStatus == true)
            {
                toolStripTextBoxStatus.Text = "运行中";
                toolStripTextBoxStatus.BackColor = Color.Green;
            }
            else
            {
                toolStripTextBoxStatus.Text = "停止中";
                toolStripTextBoxStatus.BackColor = Color.Red;
            }
        }  
        private void K_hook_KeyPressEvent(object sender, KeyPressEventArgs e)
        {
            return;
            //int buttonKey = (int)e.KeyChar;
            //if (buttonKey == (int)Keys.Q) //截获F1
            //{
            //    runFlag = (!runFlag);
            //    if (runFlag)
            //    {
            //        cts = new CancellationTokenSource();
            //        ct = cts.Token;
            //        task = Task.Run(() => this.PressJob(ct), ct);
            //    }
            //    else
            //    {
            //        cts.Cancel();
            //    }
            //    return;
            //}
        }

        private void K_hook_KeyUpEvent(object sender, KeyEventArgs e)
        {
            return;
            //int buttonKey = (int)e.KeyChar;
            //if (buttonKey == (int)Keys.Q) //截获F1
            //{
            //    runFlag = (!runFlag);
            //    if (runFlag)
            //    {
            //        cts = new CancellationTokenSource();
            //        ct = cts.Token;
            //        task = Task.Run(() => this.PressJob(ct), ct);
            //    }
            //    else
            //    {
            //        cts.Cancel();
            //    }
            //    return;
            //}
        }

        /// <summary>
        /// 鼠标
        /// </summary>
        /// <param name = "sender" ></ param >
        /// < param name="e"></param>
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            MouseKeyHook hook = (MouseKeyHook)sender;
            if (e.Button == MouseButtons.Middle) //鼠标中键--买装备
            {
                IntPtr hwnd = FindWindow(null, toolStripTextBoxWinName.Text);
                IntPtr activeWindow = GetForegroundWindow();
                if (activeWindow == hwnd)
                {
                    Task task1 = new Task(() =>
                    {
                        for (int i = 0; i < 30; i++)
                        {
                            Thread.Sleep(20);
                            MouseHook.MouseRightClickEvent(0);
                        }
                    });
                    task1.Start();
                }
            }
        }

        private void hook_KeyDown(object sender, KeyEventArgs e)
        {
            int buttonKey = (int)e.KeyCode;
            if (buttonKey == (int)Keys.Oem3) //截获~
            {
                runFlag = (!runFlag);
                this.ChangeStatus(runFlag);
                if (runFlag)
                {
                    //timer1.Start();
                    //timer2.Start();
                    //timer3.Start();
                    //timer4.Start();
                    timerR.Start();
                    timerL.Start();
                }
                else
                {
                    //timer1.Stop();
                    //timer2.Stop();
                    //timer3.Stop();
                    //timer4.Stop();
                    timerR.Stop();
                    timerL.Stop();
                }
                return;
            }
            else if (buttonKey == (int)Keys.D1)
            {
                IntPtr hwnd = FindWindow(null, toolStripTextBoxWinName.Text);
                IntPtr activeWindow = GetForegroundWindow();
                if (activeWindow == hwnd)
                {
                    if (runFlag==false)
                    {
                        runFlag = true;
                        timerR.Start();
                        timerL.Start();
                        this.ChangeStatus(runFlag);
                        //keybd_event(Keys.LMenu, 0, 0, 0);
                        //MouseHook.MouseLeftClickEvent(0);
                        //keybd_event(Keys.LMenu, 0, KEYEVENTF_KEYUP, 0);
                    }
                }
            }
            else if (buttonKey == (int)Keys.D2)
            {
                IntPtr hwnd = FindWindow(null, toolStripTextBoxWinName.Text);
                IntPtr activeWindow = GetForegroundWindow();
                if (activeWindow == hwnd)
                {
                    if (runFlag)
                    {
                        SendKeys.Send("{4}");
                    }
                }
            }
            else if (buttonKey == (int)Keys.Escape|| buttonKey == (int)Keys.Tab)
            {
                IntPtr hwnd = FindWindow(null, toolStripTextBoxWinName.Text);
                IntPtr activeWindow = GetForegroundWindow();
                if (activeWindow == hwnd)
                {
                    if (runFlag)
                    {
                        runFlag = (!runFlag);
                        this.ChangeStatus(runFlag);
                    }
                }
            }          
        }
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            IntPtr hwnd = FindWindow(null, toolStripTextBoxWinName.Text);
            IntPtr activeWindow = GetForegroundWindow();
            if (activeWindow== hwnd)
            {
                SendKeys.Send("{1}");
            }
            

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            IntPtr hwnd = FindWindow(null, toolStripTextBoxWinName.Text);
            IntPtr activeWindow = GetForegroundWindow();
            if (activeWindow == hwnd)
            {

                SendKeys.Send("{2}");
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            IntPtr hwnd = FindWindow(null, toolStripTextBoxWinName.Text);
            IntPtr activeWindow = GetForegroundWindow();
            if (activeWindow == hwnd)
            {
                SendKeys.Send("{3}");
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            IntPtr hwnd = FindWindow(null, toolStripTextBoxWinName.Text);
            IntPtr activeWindow = GetForegroundWindow();
            if (activeWindow == hwnd)
            {
                SendKeys.Send("{4}");
            }
        }

        private void timerL_Tick(object sender, EventArgs e)
        {
            //
            IntPtr hwnd = FindWindow(null, toolStripTextBoxWinName.Text);
            IntPtr activeWindow = GetForegroundWindow();
            if (activeWindow == hwnd)
            {
                if (runFlag)
                {
                    keybd_event(Keys.LMenu, 0, 0, 0);
                    MouseHook.MouseLeftClickEvent(0);
                    keybd_event(Keys.LMenu, 0, KEYEVENTF_KEYUP, 0);
                }
            }
            else
            {
                runFlag = false;
                this.ChangeStatus(runFlag);
            }

        }

        private void timerR_Tick(object sender, EventArgs e)
        {
            IntPtr hwnd = FindWindow(null, toolStripTextBoxWinName.Text);
            IntPtr activeWindow = GetForegroundWindow();
            if (activeWindow == hwnd)
            {
                if (runFlag)
                {
                    MouseHook.MouseRightClickEvent(0);
                }
            }
            else
            {
                runFlag = false;
                this.ChangeStatus(runFlag);
            }
        }

        private void startToolStripMenuItemStart_Click(object sender, EventArgs e)
        {
            if (k_hook.HookStatus == false)
            {
                k_hook.Start();//安装键盘钩子
                startToolStripMenuItemStart.Enabled = false;
                stopToolStripMenuItemStop.Enabled = true;
            }

            if (k_hook.HookStatus == true)
            {
                toolStripTextBoxStatus.Text = "运行中";
                toolStripTextBoxStatus.BackColor = Color.Green;
            }
            else
            {
                toolStripTextBoxStatus.Text = "停止中";
                toolStripTextBoxStatus.BackColor = Color.Red;
            }
        }

        private void stopToolStripMenuItemStop_Click(object sender, EventArgs e)
        {
            if (k_hook.HookStatus == true)
            {
                k_hook.Stop();
                runFlag = false;
                startToolStripMenuItemStart.Enabled = true;
                stopToolStripMenuItemStop.Enabled = false;
            }


            
            if (k_hook.HookStatus == true)
            {
                toolStripTextBoxStatus.Text = "运行中";
                toolStripTextBoxStatus.BackColor = Color.Green;
            }
            else
            {
                toolStripTextBoxStatus.Text = "停止中";
                toolStripTextBoxStatus.BackColor = Color.Red;
            }

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            k_hook.Stop();
            runFlag = false;

        }

        private void exitToolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            try
            {
                k_hook.Stop();
                runFlag = false;

            }
            catch (Exception)
            {
                runFlag = false;
            }
            this.Close();
        }
    }
}
