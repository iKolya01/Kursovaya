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
    class polygon : Primitive
    {
        int count;

        List<line> lineList;

        public polygon() { }
        public polygon(int ID, int count, List<line> lineList)
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

        public override void iDraw(ref bool[,] points) 
        {
            switch (count)
            {
                case 3:
                    {
                        for (int i = 0; i < 110; i++)
                            for (int j = 0; j < 50; j++)
                                if (!(lineList[0].Below(i * 5, j * 5) &&
                                    lineList[1].Below(i * 5, j * 5) &&
                                    lineList[2].Below(i * 5, j * 5)))
                                    points[i, j] = false;

                        break;
                    }
                case 4:
                    {
                        for (int i = 0; i < 110; i++)
                            for (int j = 0; j < 50; j++)
                                if (!(lineList[0].Below(i * 5, j * 5) &&
                                    lineList[1].Below(i * 5, j * 5) &&
                                    lineList[2].Below(i * 5, j * 5) &&
                                    lineList[3].Below(i * 5, j * 5)))
                                    points[i, j] = false;

                        break;
                    }
                case 5:
                    {
                        for (int i = 0; i < 110; i++)
                            for (int j = 0; j < 50; j++)
                                if (!(lineList[0].Below(i * 5, j * 5) &&
                                    lineList[1].Below(i * 5, j * 5) &&
                                    lineList[2].Below(i * 5, j * 5) &&
                                    lineList[3].Below(i * 5, j * 5) &&
                                    lineList[4].Below(i * 5, j * 5)))
                                    points[i, j] = false;

                        break;
                    }
            }
        }

        public override void uDraw(ref bool[,] points)
        {
            switch (count)
            {
                case 3:
                    {
                        for (int i = 0; i < 110; i++)
                            for (int j = 0; j < 50; j++)
                                if (!(lineList[0].Above(i * 5, j * 5) ||
                                    lineList[1].Above(i * 5, j * 5) ||
                                    lineList[2].Above(i * 5, j * 5)))
                                    points[i, j] = false;

                        break;
                    }
                case 4:
                    {
                        for (int i = 0; i < 110; i++)
                            for (int j = 0; j < 50; j++)
                                if (!(lineList[0].Above(i * 5, j * 5) ||
                                    lineList[1].Above(i * 5, j * 5) ||
                                    lineList[2].Above(i * 5, j * 5) ||
                                    lineList[3].Above(i * 5, j * 5)))
                                    points[i, j] = false;

                        break;
                    }
                case 5:
                    {
                        for (int i = 0; i < 110; i++)
                            for (int j = 0; j < 50; j++)
                                if (!(lineList[0].Above(i * 5, j * 5) ||
                                    lineList[1].Above(i * 5, j * 5) ||
                                    lineList[2].Above(i * 5, j * 5) ||
                                    lineList[3].Above(i * 5, j * 5) ||
                                    lineList[4].Above(i * 5, j * 5)))
                                    points[i, j] = false;

                        break;
                    }
            }
        }

        public override string Included()
        {
            string result = "";

            switch (count)
            {
                case 3:
                    {
                        result = lineList[0].Below() + "&" + lineList[1].Above() + "&" + lineList[2].Above();
                        
                        break;
                    }
                case 4:
                    {
                        result = lineList[0].Below() + "&" + lineList[1].Above() + "&" + lineList[2].Above() + "&" + lineList[3].Above();

                        break;
                    }
                case 5:
                    {
                        result = lineList[0].Below() + "&" + lineList[1].Below() + "&" + lineList[2].Above() + "&" + lineList[3].Above() + "&" + lineList[4].Above();
                        
                        break;
                    }
            }

            return result;
        }

        public override string unIncluded()
        {
            string result = "";

            switch (count)
            {
                case 3:
                    {
                        result = lineList[0].Below() + "&" + lineList[1].Above() + "&" + lineList[2].Above();

                        break;
                    }
                case 4:
                    {
                        result = lineList[0].Below() + "&" + lineList[1].Below() + "&" + lineList[2].Above() + "&" + lineList[3].Above();

                        break;
                    }
                case 5:
                    {
                        result = lineList[0].Below() + "&" + lineList[1].Below() + "&" + lineList[2].Above() + "&" + lineList[3].Above() + "&" + lineList[4].Above();

                        break;
                    }
            }

            return result;
        }
    }
}
