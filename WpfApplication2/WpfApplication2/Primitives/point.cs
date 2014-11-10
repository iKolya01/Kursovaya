using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApplication2.Primitives
{
    public class point : Primitive
    {
        int x;
        public int X
        {
            get { return x; }
            set { x = value; }
        }

        int y;
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public point(int id, int x, int y)
        {
            this.id = id;
            this.x = x;
            this.y = y;
        }

        public void Draw(Canvas myCanvas, Brush Collor)
        {
            ellipse myEllipse = new ellipse(0, new point(0, x, y), 1, 1);
            myEllipse.Draw(myCanvas, Collor);
        }
    }
}
