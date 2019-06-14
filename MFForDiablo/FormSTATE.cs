using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MFForD
{
    public partial class FormSTATE : Form
    {
        private Point mouseOffst;
        private bool isMouseDown = false;
        protected Rectangle WorkAreaRectangle;
        private Bitmap backgroundImage;

        [DllImport("user32.dll")]
        private static extern Boolean ShowWindow(IntPtr hWnd, Int32 nCmdShow);

        public FormSTATE()
        {
            InitializeComponent();
            ShowWithOutFocus(false);
        }

        public void ShowWithOutFocus(bool status)
        {
            WorkAreaRectangle = Screen.GetWorkingArea(WorkAreaRectangle);
            if (status ==false)
            {
                backgroundImage = Properties.Resources.red;
            }
            else
            {
                backgroundImage = Properties.Resources.green;
            }           
            Color transparencyColor = Color.FromArgb(255, 0, 255);
            Width = backgroundImage.Width;
            Height = backgroundImage.Height;
            BackgroundImage = backgroundImage;
            Region = BitmapToRegion(backgroundImage, transparencyColor);

            //SetBounds(Region);

            ShowWindow(this.Handle, 4);
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            int xOffset;
            int yOffset;

            if (e.Button == MouseButtons.Left)
            {
                xOffset = -e.X - SystemInformation.FrameBorderSize.Width;
                yOffset = -e.Y - SystemInformation.FrameBorderSize.Height;
                mouseOffst = new Point(xOffset, yOffset);
                isMouseDown = true;
            }
        }

        private void MainForm_MouseLeave(object sender, EventArgs e)
        {
        }

        public string strText = "aaaaaaaaaaaaaaaaaa";

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Point mousePos = Control.MousePosition;
                int a = Screen.PrimaryScreen.WorkingArea.Height;
                int b = Screen.PrimaryScreen.Bounds.Height;

                int c = Screen.PrimaryScreen.WorkingArea.Width;
                int d = Screen.PrimaryScreen.Bounds.Width;

                mousePos.Offset(mouseOffst.X + 4, mouseOffst.Y + (b - a) / 2);
                Location = mousePos;
            }
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {          
        }

        public void ChangeStatus(bool status)
        {
            ShowWithOutFocus(status);
        }

        protected Region BitmapToRegion(Bitmap bitmap, Color transparencyColor)
        {
            if (bitmap == null)
                throw new ArgumentNullException("Bitmap", "Bitmap cannot be null!");

            int height = bitmap.Height;
            int width = bitmap.Width;

            GraphicsPath path = new GraphicsPath();

            for (int j = 0; j < height; j++)
                for (int i = 0; i < width; i++)
                {
                    if (bitmap.GetPixel(i, j) == transparencyColor)
                        continue;

                    int x0 = i;

                    while ((i < width) && (bitmap.GetPixel(i, j) != transparencyColor))
                        i++;

                    path.AddRectangle(new Rectangle(x0, j, i - x0, 1));
                }

            Region region = new Region(path);
            path.Dispose();
            return region;
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Center;
            sf.FormatFlags = StringFormatFlags.DirectionRightToLeft;
            sf.Trimming = StringTrimming.EllipsisCharacter;             // Added Rev 002

            g.DrawString(strText, new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Pixel), new SolidBrush(Color.White), new Rectangle(10, 10, 50, 50), sf);
            e.Graphics.DrawRectangle(Pens.White, Rectangle.Round(new Rectangle(10, 10, 50, 50)));

        }
    } 
}
