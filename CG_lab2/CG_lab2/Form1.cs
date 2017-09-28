using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Threading;

namespace CG_lab2
{

    // Реализовать Рекурсивный алгоритм заливки на основе серий пикселов (линий) в двух вариантах:
    // 1) заливка заданным цветом
    // 2) заливка рисунком из графического файла.
    // Файл можно загрузить встроенными средствами и затем считывать точки изображения для использования в заливке.

    // Область рисуется мышкой. Область произвольной формы. Внутри могут быть отверстия.
    // Точка, с которой начинается заливка, задается щелчком мыши.
    public partial class Form1 : Form
    {
        private Bitmap bmp;
        private Graphics g;
        private Pen pen = new Pen(Color.Black);
        private Point startPt;
        private Bitmap img;
        private int currentColor;

        public Form1()
        {
            InitializeComponent();
            pen.StartCap = pen.EndCap = LineCap.Round;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
            pictureBox1.Refresh();
            g = Graphics.FromImage(bmp);
            radioButtonImage.Enabled = false;
            radioButtonColor.Select();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                g.DrawLine(pen, startPt, e.Location);
                startPt = e.Location;
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            startPt = e.Location;
            if (e.Button == MouseButtons.Right)
            {
                g = Graphics.FromImage(bmp);
                currentColor = bmp.GetPixel(e.Location.X, e.Location.Y).ToArgb();
                if (radioButtonColor.Checked)
                    FillColor(e.Location);
                else if (radioButtonImage.Checked)
                    FillImage(e.Location, new Point(0, 0));
                pictureBox1.Refresh();
            }
        }

        private void labelColor_BackColorChanged(object sender, EventArgs e)
        {
            pen.Color = labelColor.BackColor;
        }

        private bool PointIsFilled(Point p)
        {
            //return bmp.GetPixel(p.X, p.Y).ToArgb() == colorDialog1.Color.ToArgb();
            return bmp.GetPixel(p.X, p.Y).ToArgb() != currentColor;
        }

        private bool OutOfBorder(Point p)
        {
            return !(p.X >= 0 && p.Y >= 0 && p.X < bmp.Width && p.Y < bmp.Height);
        }

        private int FindLeftBorder(Point p)
        {
            int leftBorder = p.X;
            while (bmp.GetPixel(leftBorder, p.Y).ToArgb() != colorDialog1.Color.ToArgb() && leftBorder > 0)
                --leftBorder;
            return leftBorder;
        }

        private int FindRightBorder(Point p)
        {
            int rightBorder = p.X;
            while (bmp.GetPixel(rightBorder, p.Y).ToArgb() != colorDialog1.Color.ToArgb() && rightBorder < bmp.Width - 1)
                ++rightBorder;
            return rightBorder;
        }

        private void FillColor(Point p)
        {
            if (OutOfBorder(p)) return;
            // Если текущая точка не закрашена
            if (!PointIsFilled(p))
            {
                //Для текущей точки находим левую и правую границу.
                int l = FindLeftBorder(p);
                int r = FindRightBorder(p);
                //Рисуем линию от левой границы до правой границы, не включая саму границу.
                Point lp = new Point(l+1, p.Y);
                Point rp = new Point(r-1, p.Y);
                Pen f = new Pen(pen.Color, 1);
                g.DrawLine(f, lp, rp);
                //Thread.Sleep(1);
                pictureBox1.Refresh();
                // В цикле от левой до правой границы (не включая саму границу) вызываем эту же функцию рекурсивно для всех точек, лежащих выше текущей на один пиксел.
                for (int i = l + 1; i < r; ++i)
                    FillColor(new Point(i, p.Y + 1));
                // Выполняем аналогичный цикл для всех точек, лежащих ниже текущей на один пиксел.
                for (int i = l + 1; i < r; ++i)
                    FillColor(new Point(i, p.Y - 1));
            }
        }

        private int IncImgX (int x, int d)
        {
            return (x + d) % img.Width;
        }

        private int DecImgX(int x, int d)
        {
            x -= d;
            while (x < 0)
                x += img.Width;
            return x;
        }

        private int IncImgY (int y, int d)
        {
            return (y + d) % img.Height;
        }

        private int DecImgY(int y, int d)
        {
            y -= d;
            while (y < 0)
                y += img.Height;
            return y;
        }

        // В параметрах передаются соответствующие точки на заливаемой фигуре и на картинке
        private void DrawLineFromImage(Point figurePoint, Point imgPoint, int lBorder, int rBorder)
        {
            //Rectangle rect = new Rectangle(0,0,img.Width,img.Height);
            //BitmapData bmpData = img.LockBits(rect,ImageLockMode.ReadWrite,img.PixelFormat);
            //IntPtr ptr = bmpData.Scan0;
            int imgX = imgPoint.X;
            // заливаем вправо
            for (int i = figurePoint.X + 1; i < rBorder; ++i)
            {
                imgX = IncImgX(imgX,1);
                bmp.SetPixel(i, figurePoint.Y, img.GetPixel(imgX, imgPoint.Y));
            }
            // заливаем влево
            imgX = imgPoint.X;
            for (int i = figurePoint.X; i > lBorder; --i)
            {
                imgX = DecImgX(imgX,1);
                bmp.SetPixel(i, figurePoint.Y, img.GetPixel(imgX, imgPoint.Y));
            }
        }

        private void FillImage(Point figurePoint, Point imgPoint)
        {
            if (OutOfBorder(figurePoint)) return;
            // Если текущая точка не закрашена
            if (!PointIsFilled(figurePoint))
            {
                //Для текущей точки находим левую и правую границу.
                int l = FindLeftBorder(figurePoint);
                int r = FindRightBorder(figurePoint);
                //Рисуем линию от левой границы до правой границы, не включая саму границу.
                Point lp = new Point(l + 1, figurePoint.Y);
                Point rp = new Point(r - 1, figurePoint.Y);
                Pen f = new Pen(pen.Color, 1);
                DrawLineFromImage(figurePoint,imgPoint,l,r);
                //Thread.Sleep(1);
                pictureBox1.Refresh();
                // В цикле от левой до правой границы (не включая саму границу) вызываем эту же функцию рекурсивно для всех точек, лежащих выше текущей на один пиксел.
                // Слева и ниже текущей
                int d = 0;
                for (int i = figurePoint.X; i > l; --i)
                {
                    FillImage(new Point(i, figurePoint.Y + 1), new Point(DecImgX(imgPoint.X, d), IncImgY(imgPoint.Y, 1)));
                    ++d;
                }
                // слева выше
                d = 0;
                for (int i = figurePoint.X; i > l; --i)
                {
                    FillImage(new Point(i, figurePoint.Y - 1), new Point(DecImgX(imgPoint.X, d), DecImgY(imgPoint.Y, 1)));
                    ++d;
                }
                // Справа и ниже текущей
                d = 0;
                for (int i = figurePoint.X; i < r; ++i)
                {
                    FillImage(new Point(i, figurePoint.Y + 1), new Point(IncImgX(imgPoint.X, d), IncImgY(imgPoint.Y, 1)));
                    ++d;
                }
                // Выполняем аналогичный цикл для всех точек, лежащих ниже текущей на один пиксел.
                // справа выше
                d = 0;
                for (int i = figurePoint.X; i < r; ++i)
                {
                    FillImage(new Point(i, figurePoint.Y - 1), new Point(IncImgX(imgPoint.X, d), DecImgY(imgPoint.Y, 1)));
                    ++d;
                }
            }
        }

        private void labelColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = labelColor.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                labelColor.BackColor = colorDialog1.Color;
        }

        private void buttonLoadImg_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                img = Bitmap.FromFile(openFileDialog1.FileName) as Bitmap;
                radioButtonImage.Enabled = true;
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            g.Clear(pictureBox1.BackColor);
            pictureBox1.Refresh();
        }
    }
}
