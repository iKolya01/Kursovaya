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
    class polyline : Primitive
    {
        int count;

        List<line> lineList;

        public polyline() { }
        public polyline(int ID, int count, List<line> lineList)
        {
            this.id = ID;
            this.count = count;
            this.lineList = lineList;
        }

        public override void Draw(Canvas myCanvas)
        {
            foreach (line l in lineList)
            {
                l.Draw(myCanvas);
            }
        }

        public override void aDraw(ref bool[,] points)
        {
            for (int i = 0; i < lineList.Count; i++)
            {
                int a, b;

                if (i == 0)
                {
                    a = 0;
                    b = lineList[i].Two.X;
                }
                else if (i == lineList.Count - 1)
                {
                    a = lineList[i].One.X;
                    b = 550;
                }
                else
                {
                    a = lineList[i].One.X;
                    b = lineList[i].Two.X;
                }

                for (int x = a; x < b; x += 5)
                {
                    for (int y = 0; y < 250; y += 5)
                    {
                        if (!lineList[i].Above(x, y)) points[x / 5, y / 5] = false;
                    }
                }
            }
        }

        public override void bDraw(ref bool[,] points)
        {
            for (int i = 0; i < lineList.Count; i++)
            {
                int a, b;

                if (i == 0)
                {
                    a = 0;
                    b = lineList[i].Two.X;
                }
                else if (i == lineList.Count - 1)
                {
                    a = lineList[i].One.X;
                    b = 550;
                }
                else
                {
                    a = lineList[i].One.X;
                    b = lineList[i].Two.X;
                }

                for (int x = a; x < b; x += 5)
                {
                    for (int y = 0; y < 250; y += 5)
                    {
                        if (!lineList[i].Below(x, y)) points[x / 5, y / 5] = false;
                    }
                }
            }
        }

        public override string Above()
        {
            string result = "";

            foreach (line l in lineList)
            {
                result += l.
            }

            return result;
        }
    }
}
