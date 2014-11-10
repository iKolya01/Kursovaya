using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace WpfApplication2.Primitives
{
    class line : Primitive
    {
        point one;//первая точка
        public override point One
        {
            get { return one; }
            set { if (value.X > 0 && value.X < 550 && value.Y > 0 && value.Y < 250) one = value; }
        }

        point two;//вторая точка
        public override point Two
        {
            get { return two; }
            set { if (value.X > 0 && value.X < 550 && value.Y > 0 && value.Y < 250) two = value; }
        }

        public line(int id, point one, point two, int linewidth)
        {
            this.id = id;
            this.one = one;
            this.two = two;
            this.linewidth = linewidth;
        }

        public override void Draw(Canvas myCanvas)
        {
            Line myLine = new Line();
            myLine.HorizontalAlignment = HorizontalAlignment.Left;
            myLine.VerticalAlignment = VerticalAlignment.Top;
            myLine.X1 = 10 + one.X;
            myLine.Y1 = 260 - one.Y;
            myLine.X2 = 10 + two.X;
            myLine.Y2 = 260 - two.Y;
            myLine.StrokeThickness = linewidth;
            myLine.Stroke = System.Windows.Media.Brushes.Black;
            myLine.ToolTip = "Ебаь это наведение";
            myCanvas.Children.Add(myLine);
        }

        public override bool Above(Point point)
        {
            if ((one.Y - two.Y) * point.X + (two.X - one.X) * point.Y + (one.X * two.Y - two.X * one.Y) > 0) return true;
            return false;
        }

        public override bool Below(Point point)
        {
            if ((one.Y - two.Y) * point.X + (two.X - one.X) * point.Y + (one.X * two.Y - two.X * one.Y) < 0) return true;
            return false;
        }

        public bool Above(int X, int Y)
        {
            if ((one.Y - two.Y) * X + (two.X - one.X) * Y + (one.X * two.Y - two.X * one.Y) > 0) return true;
            return false;
        }

        public bool Below(int X, int Y)
        {
            if ((one.Y - two.Y) * X + (two.X - one.X) * Y + (one.X * two.Y - two.X * one.Y) < 0) return true;
            return false;
        }

        public override string Above()
        {
            int dx = One.X > Two.X ? One.X - Two.X : Two.X - One.X;
            int dy = One.Y > Two.Y ? One.Y - Two.Y : Two.Y - One.Y;

            float k = dy / dx;

            float b = One.Y - k * One.X;

            return "y>" + k.ToString() +  "*x+" + b.ToString(); 
        }

        public override string Below()
        {
            int dx = One.X > Two.X ? One.X - Two.X : Two.X - One.X;
            int dy = One.Y > Two.Y ? One.Y - Two.Y : Two.Y - One.Y;

            float k = dy / dx;

            float b = One.Y - k * One.X;

            return "y<" + k.ToString() + "*x+" + b.ToString();
        }
    }
}
