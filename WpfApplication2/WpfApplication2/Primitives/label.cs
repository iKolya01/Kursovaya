using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WpfApplication2.Primitives
{
    class label
    {
        string content;//содержание строки
        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        Point coordinate;//отрисовка строки(верхний левый угол)
        public Point Coordinate
        {
            get { return coordinate; }
            set { if (value.X > 0 && value.X < 550 && value.Y > 0 && value.Y < 250) coordinate = value; }
        }

        public label(Point coordinate, string content)
        {
            this.content = content;
            this.coordinate = coordinate;
        }

        public void Draw(Canvas myCanvas)
        {
            Label myLabel = new Label();
            myLabel.Content = this.content;
            myLabel.HorizontalAlignment = HorizontalAlignment.Left;
            myLabel.VerticalAlignment = VerticalAlignment.Top;
            myLabel.Margin = new Thickness(10 + coordinate.X, 260 - coordinate.Y, 0, 0);

            myCanvas.Children.Add(myLabel);
        }
    }
}
