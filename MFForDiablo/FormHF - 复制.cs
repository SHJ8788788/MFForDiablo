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
    public partial class FormHF : Form
    {
        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", EntryPoint = "keybd_event", SetLastError = true)] 
        public static extern void keybd_event(Keys bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

        public const int KEYEVENTF_KEYUP = 2;

        private MouseKeyHook mouseKeyHook1 = new MouseKeyHook(true, true);//鼠标，键盘

        private bool runFlag = false;
        private KeyboardHook k_hook;
        public FormHF()
        {
            InitializeComponent();
            //mouseKeyHook1.KeyDown += new KeyEventHandler(Form1_KeyDown);
            //mouseKeyHook1.KeyPress += new KeyPressEventHandler(mouseKeyHook1_KeyPress);
            //mouseKeyHook1.KeyUp += new KeyEventHandler(mouseKeyHook1_KeyUp);
            mouseKeyHook1.OnMouseActivity += new MouseEventHandler(Form1_MouseDown);
            
            //还原窗体显示    
            WindowState = FormWindowState.Minimized;
            //激活窗体并给予它焦点
            this.Activate();
            //任务栏区显示图标
            this.ShowInTaskbar = false;
            //托盘区图标隐藏
            notifyIcon.Visible = true;

        }

        private void btnStart_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            k_hook = new KeyboardHook();
            k_hook.KeyDownEvent += new System.Windows.Forms.KeyEventHandler(hook_KeyDown);//钩住键按下 
            k_hook.KeyPressEvent += K_hook_KeyPressEvent;
            k_hook.KeyUpEvent += K_hook_KeyUpEvent;
            k_hook.Start();//安装键盘钩子

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

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                IntPtr hwnd = FindWindow(null, toolStripTextBoxWinName.Text);
                IntPtr activeWindow = GetForegroundWindow();
                if (activeWindow == hwnd)
                {
                    SendKeys.Send("{1}");
                }
            }
        }

        //private void Pressed(int buttonKey)
        //{
        //if (buttonKey == 91) // 截获左win(开始菜单键)
        //    return;
        //if (buttonKey == 92) // 截获右win
        //    return;
        //if (buttonKey == (int)Keys.Escape && (int)Control.ModifierKeys == (int)Keys.Control) //截获Ctrl+Esc
        //    return;
        //if (buttonKey == (int)Keys.F4 && (int)Control.ModifierKeys == (int)Keys.Alt) //截获alt+f4
        //    return;
        //if (buttonKey == (int)Keys.Tab && (int)Control.ModifierKeys == (int)Keys.Alt) //截获alt+tab
        //    return;
        //if (buttonKey == (int)Keys.Escape &&
        //    (int)Control.ModifierKeys == (int)Keys.Control + (int)Keys.Shift) //截获Ctrl+Shift+Esc
        //    return;
        //if (buttonKey == (int)Keys.Space && (int)Control.ModifierKeys == (int)Keys.Alt) //截获alt+空格
        //    return;

        //if (buttonKey == (int)Keys.Control && buttonKey == (int)Keys.Alt && buttonKey == (int)Keys.Delete)
        //    return;
        //if ((int)Control.ModifierKeys == (int)Keys.Control + (int)Keys.Alt + (int)Keys.Delete
        //) //截获Ctrl+Alt+Delete
        //    return;
        //if ((int)Control.ModifierKeys == (int)Keys.Control + (int)Keys.Shift) //截获Ctrl+Shift
        //    return;
        //}

        //private int KeyDown(int key, int interval)
        //{
        //    string keyT="";
        //    while (true)
        //    {
        //        if (ct.IsCancellationRequested)
        //        {
        //            throw new OperationCanceledException(ct);
        //        }
        //        if (key ==(int)Keys.D2)
        //        {
        //            keyT = "{2}";
        //        }
        //        else if (key == (int)Keys.D3)
        //        {
        //            keyT = "{3}";
        //        }
        //        else if (key == (int)Keys.D4)
        //        {
        //            keyT = "{4}";
        //        }

        //        SendKeys.SendWait(keyT);
        //        //char i = (char)key;
        //        //SendKeys.SendWait(i.ToString());
        //        //SendKeys.SendWait("{2}");
        //        Thread.Sleep(interval);
        //    }
        //}

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

        private void hook_KeyDown(object sender, KeyEventArgs e)
        {
            int buttonKey = (int)e.KeyCode;
            if (buttonKey == (int)Keys.Oem3) //截获~
            {
                runFlag = (!runFlag);
                if (runFlag)
                {
                    //timer2.Start();
                   //timer3.Start();
                    timer4.Start();
                    //timerR.Start();
                }
                else
                {
                    //timer2.Stop();
                    //timer3.Stop();
                    timer4.Stop();
                    //timerR.Stop();
                }
                return;
            }
            else if (buttonKey==(int)Keys.D1)
            {
                IntPtr hwnd = FindWindow(null, toolStripTextBoxWinName.Text);
                IntPtr activeWindow = GetForegroundWindow();
                if (activeWindow == hwnd)
                {
                    keybd_event(Keys.LShiftKey, 0, 0, 0);
                    MouseHook.MouseLeftClickEvent(0);
                    keybd_event(Keys.LShiftKey, 0, KEYEVENTF_KEYUP, 0);
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
            //MouseHook.MouseLeftClickEvent(0);
        }

        private void timerR_Tick(object sender, EventArgs e)
        {
            //
            MouseHook.MouseRightClickEvent(0);
        }

        private void startToolStripMenuItemStart_Click(object sender, EventArgs e)
        {
            k_hook.Start();
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
            k_hook.Stop();
            runFlag = false;
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
