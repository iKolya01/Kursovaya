using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApplication2.Primitives
{
    class ellipse : Primitive
    {
        point coordinate;//координата центра окружности
        public override point Coordinate
        {
            get { return coordinate; }
            set { coordinate = value; }
        }

        int r;//радиус
        public override int R
        {
            get { return r; }
            set { if ((value > 0) && (value < 62)) r = value; }
        }

        public ellipse(int id, point coordinate, int r, int linewidth)
        {
            this.id = id;
            this.coordinate = coordinate;
            this.r = r;
            this.linewidth = linewidth;
        }

        private string getUrv()
        {
            return "(x-" + Coordinate.X.ToString() + ")*(x-" + Coordinate.X.ToString() + ") + (y-" +
                   Coordinate.Y.ToString() + ")*(y - " + Coordinate.Y.ToString() + ")=" + R.ToString() + "*" + R.ToString();
        }

        public override void Draw(Canvas myCanvas)
        {
            Ellipse myEllipse = new Ellipse();
            myEllipse.HorizontalAlignment = HorizontalAlignment.Left;
            myEllipse.VerticalAlignment = VerticalAlignment.Top;
            myEllipse.Width = r * 2;
            myEllipse.Height = r * 2;
            myEllipse.Margin = new Thickness(10 + coordinate.X - r, 260 - coordinate.Y - r, 0, 0);
            myEllipse.Stroke = System.Windows.Media.Brushes.Black;
            myEllipse.StrokeThickness = linewidth;
            myCanvas.Children.Add(myEllipse);
        }

        public override void Draw(Canvas myCanvas, bool lbl)
        {
            Ellipse myEllipse = new Ellipse();
            myEllipse.HorizontalAlignment = HorizontalAlignment.Left;
            myEllipse.VerticalAlignment = VerticalAlignment.Top;
            myEllipse.Width = r * 2;
            myEllipse.Height = r * 2;
            myEllipse.Margin = new Thickness(10 + coordinate.X - r, 260 - coordinate.Y - r, 0, 0);
            myEllipse.Stroke = System.Windows.Media.Brushes.Black;
            myEllipse.StrokeThickness = linewidth;
            myEllipse.ToolTip = getUrv();
            myCanvas.Children.Add(myEllipse);
        }

        public override void iDraw(ref bool[,] points)
        {
            for (int i = 0; i < 110; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    if (!Included(i * 5, j * 5)) points[i, j] = false;
                }
            }
        }


        public override void uDraw(ref bool[,] points)
        {
            for (int i = 0; i < 110; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    if (!unIncluded(i * 5, j * 5)) points[i, j] = false;
                }
            }
        }

        public void Draw(Canvas myCanvas, Brush Collor)//отрисовка для точки
        {
            Ellipse myEllipse = new Ellipse();
            myEllipse.HorizontalAlignment = HorizontalAlignment.Left;
            myEllipse.VerticalAlignment = VerticalAlignment.Top;
            myEllipse.Width = r * 2;
            myEllipse.Height = r * 2;
            myEllipse.Margin = new Thickness(10 + coordinate.X - r, 260 - coordinate.Y - r, 0, 0);
            myEllipse.Stroke = Collor;
            myEllipse.StrokeThickness = linewidth;
            myCanvas.Children.Add(myEllipse);
        }

        public override bool Included(Point point)
        {
            if ((point.X - coordinate.X) * (point.X - coordinate.X) + (point.Y - coordinate.Y) * (point.Y - coordinate.Y) < r * r - r - 125)
                return true;

            return false;
        }

        public override bool Included(int X, int Y)
        {
            if ((X - coordinate.X) * (X - coordinate.X) + (Y - coordinate.Y) * (Y - coordinate.Y) < r * r - r - 125)
                return true;

            return false;
        }

        public override bool unIncluded(Point point)
        {
            if ((point.X - coordinate.X) * (point.X - coordinate.X) + (point.Y - coordinate.Y) * (point.Y - coordinate.Y) > r * r - r - 125)
                return true;

            return false;
        }

        public bool unIncluded(int X, int Y)
        {
            if ((X - coordinate.X) * (X - coordinate.X) + (Y - coordinate.Y) * (Y - coordinate.Y) > r * r - r - 125)
                return true;

            return false;
        }

        public override void dDraw(ref bool[,] points)
        {
            for (int i = 0; i < 110; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    if (!unIncluded(i * 5, j * 5)) points[i, j] = true;
                }
            }
        }

        public override string Included()
        {
            return "(x-" + Coordinate.X.ToString() + ")*(x-" + Coordinate.X.ToString() + ") + (y-" + 
                   Coordinate.Y.ToString() + ")*(y - " + Coordinate.Y.ToString() + ")<" + R.ToString() + "*" + R.ToString();
        }

        public override string unIncluded()
        {
            return "(x-" + Coordinate.X.ToString() + ")*(x-" + Coordinate.X.ToString() + ") + (y-" +
                   Coordinate.Y.ToString() + ")*(y - " + Coordinate.Y.ToString() + ")>" + R.ToString() + "*" + R.ToString();
        }
    }
}
