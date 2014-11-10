using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using WpfApplication2.Primitives;

namespace WpfApplication2
{
    class from_XML_to_Task
    {
        public Random rand = new Random();
        public string fileAdress;

        public from_XML_to_Task()                   { this.fileAdress = ""; }
        public from_XML_to_Task(string fileAdress)  { this.fileAdress = fileAdress; }

        private bool isInCircle(int x, int y, int x0, int y0, int r)
        {
            if ((x - x0) * (x - x0) + (y - y0) * (y - y0) < r * r) return true;
            return false;
        }
        
        public List<Task> Decode()
        {
            List<Task> resultTask = new List<Task>();

            //читаем данные из файла
            XDocument doc = XDocument.Load(fileAdress);
            //(этот элемент сразу доступен через свойство doc.Root)
            foreach (XElement template in doc.Root.Elements())
            {

                List<Primitive> stack = new List<Primitive>();

                string area = "";

                //выводим в цикле названия всех дочерних элементов и их значения
                foreach (XElement parts in template.Elements())
                {
                    if (parts.Name == "primitive")
                    {
                        foreach (XElement prim in parts.Elements())
                        {
                            if (prim.Name == "circle")
                            {
                                int ID = -1;

                                string link = prim.Attribute("link").Value;
                                if (link != "none") ID = Convert.ToInt32(link);

                                if (ID < 0)
                                    stack.Add(new ellipse(Convert.ToInt32(prim.Attribute("id").Value), 
                                                          new point(0, rand.Next(20, 35) * 10,
                                                                    rand.Next(10, 15) * 10),
                                                                    rand.Next(4, 9) * 10, 3));
                                else
                                {
                                    int R = rand.Next(3, 7) * 10;

                                    int X = 0;
                                    int Y = 0;
                                    int d = 0;
                                    do
                                    {
                                        X = rand.Next(20, 35) * 10;
                                        Y = rand.Next(10, 15) * 10;

                                        d = (int)Math.Sqrt((X - stack[ID].Coordinate.X) * (X - stack[ID].Coordinate.X)
                                                            + (Y - stack[ID].Coordinate.Y) * (Y - stack[ID].Coordinate.Y));
                                    } while (d >= (stack[ID].R + R) || d <= R || d <= stack[ID].R);

                                    stack.Add(new ellipse(Convert.ToInt32(prim.Attribute("id").Value), 
                                                          new point(0, X, Y), R, 2));
                                }
                            }
                            if (prim.Name == "polygon")
                            {
                                int ID = -1;

                                string link = prim.Attribute("link").Value;
                                if (link != "none") ID = Convert.ToInt32(link);

                                int lineCount = Convert.ToInt32(prim.Attribute("linecount").Value);

                                int sector = 360 / lineCount;

                                List<point> pointList = new List<point>();
                                List<line> lineList = new List<line>();

                                if (ID >= 0)
                                {
                                    point center = stack[ID].Coordinate;
                                    int r = stack[ID].R;

                                    int a = center.X - r;
                                    int b = center.X + r;

                                    int X = 0, Y = 0;

                                    int top = 0, bot = 0;

                                    if (lineCount == 3)
                                    {
                                        top = 2;
                                        bot = 1;
                                    }
                                    else if (lineCount == 4)
                                    {
                                        top = 2;
                                        bot = 2;
                                    }
                                    else if (lineCount == 5)
                                    {
                                        top = 3;
                                        bot = 2;
                                    }

                                    int topDis = r * 2 / top;

                                    for (int i = 0; i < top; i++)
                                    {
                                        X = rand.Next(a + topDis * i, a + topDis * (i + 1));
                                        if (i == 0 || lineCount == 4 || lineCount == 3)
                                            Y = rand.Next(center.Y + 10, center.Y + r - 10);
                                        else{
                                            if (i == 1)
                                                Y = rand.Next(pointList[i - 1].Y, center.Y + r - 10);
                                            else
                                                Y = rand.Next(center.Y + 10, pointList[i - 1].Y);
                                        }

                                        pointList.Add(new point(-1, X, Y));
                                    }

                                    a = pointList[0].X;
                                    b = pointList[top - 1].X;

                                    int botDis = (b - a) / bot;

                                    for (int i = 0; i < bot; i++)
                                    {
                                        X = rand.Next(b - botDis * (i + 1), b - botDis * i);
                                        Y = rand.Next(center.Y - r + 10, center.Y);

                                        pointList.Add(new point(-1, X, Y));
                                    }
                                }else
                                {
                                    point center = new point(-1, rand.Next(15, 45) * 10, rand.Next(7, 17) * 10);
                                    int r = rand.Next(5, 8) * 10;

                                    int a = center.X - r;
                                    int b = center.X + r;

                                    int X = 0, Y = 0;

                                    int top = 0, bot = 0;

                                    if (lineCount == 3)
                                    {
                                        top = 2;
                                        bot = 1;
                                    }
                                    else if (lineCount == 4)
                                    {
                                        top = 2;
                                        bot = 2;
                                    }
                                    else if (lineCount == 5)
                                    {
                                        top = 3;
                                        bot = 2;
                                    }

                                    int topDis = r * 2 / top;

                                    for (int i = 0; i < top; i++)
                                    {
                                        X = rand.Next(a + topDis * i, a + topDis * (i + 1));
                                        if (i == 0 || lineCount == 4 || lineCount == 3)
                                            Y = rand.Next(center.Y + 10, center.Y + r - 10);
                                        else
                                        {
                                            if (i == 1)
                                                Y = rand.Next(pointList[i - 1].Y, center.Y + r - 10);
                                            else
                                                Y = rand.Next(center.Y + 10, pointList[i - 1].Y);
                                        }

                                        pointList.Add(new point(-1, X, Y));
                                    }

                                    a = pointList[0].X;
                                    b = pointList[top - 1].X;

                                    int botDis = (b - a) / bot;

                                    for (int i = 0; i < bot; i++)
                                    {
                                        X = rand.Next(b - botDis * (i + 1), b - botDis * i);
                                        //if (bot == 1 || lineCount == 4 || i == 0)
                                            Y = rand.Next(center.Y - r + 10, center.Y);
                                        //else


                                        pointList.Add(new point(-1, X, Y));
                                    }
                                }


                                for (int i = 0; i < lineCount; i++)
                                {
                                    lineList.Add(new line(i, pointList[i], pointList[(i == lineCount - 1) ? 0 : i + 1], 3));
                                }

                                stack.Add(new polygon(Convert.ToInt32(prim.Attribute("id").Value), lineCount, lineList));
                            }
                            if (prim.Name == "polyline")
                            {
                                int ID = -1;

                                string link = prim.Attribute("link").Value;
                                if (link != "none") ID = Convert.ToInt32(link);

                                int lineCount = Convert.ToInt32(prim.Attribute("linecount").Value);

                                List<line> lineList = new List<line>();

                                List<point> pointList = new List<point>();
                                int i = 0;

                                if (ID >= 0)
                                {
                                    int sector = (stack[ID].R * 2 / 10) / (lineCount - 1);

                                    pointList.Add(new point(0, stack[ID].Coordinate.X - stack[ID].R,
                                                            rand.Next(stack[ID].Coordinate.Y / 10 - stack[ID].R / 10,
                                                                      stack[ID].Coordinate.Y / 10 + stack[ID].R / 10) * 10));

                                    for (i = 0; i < lineCount - 1; i++)
                                    {
                                        int X = 0, Y = 0;

                                        while ((X - stack[ID].Coordinate.X) * (X - stack[ID].Coordinate.X) +
                                               (Y - stack[ID].Coordinate.Y) * (Y - stack[ID].Coordinate.Y) >=
                                               (stack[ID].R * stack[ID].R))
                                        {
                                            X = rand.Next(stack[ID].Coordinate.X / 10 - stack[ID].R / 10 + sector * i,
                                                          stack[ID].Coordinate.X / 10 - stack[ID].R / 10 + sector * (i + 1)) * 10;

                                            Y = rand.Next(stack[ID].Coordinate.Y / 10 - stack[ID].R / 10,
                                                          stack[ID].Coordinate.Y / 10 + stack[ID].R / 10) * 10;
                                        }

                                        pointList.Add(new point(i, X, Y));
                                    }

                                    pointList.Add(new point(lineCount + 1, stack[ID].Coordinate.X + stack[ID].R,
                                                            rand.Next(stack[ID].Coordinate.Y / 10 - stack[ID].R / 10,
                                                                      stack[ID].Coordinate.Y / 10 + stack[ID].R / 10) * 10));
                                }
                                else
                                {
                                    int sector = 55 / (lineCount + 1);

                                    for (i = 0; i <= lineCount; i++)
                                    {
                                        pointList.Add(new point(i, rand.Next(1 + sector * i, 1 + sector * (i + 1)) * 10,
                                                                   rand.Next(1, 22) * 10));
                                    }
                                }

                                i = 0;
                                for (i = 0; i < lineCount; i++)
                                {
                                    lineList.Add(new line(i, pointList[i], pointList[i + 1], 3));
                                }

                                stack.Add(new polyline(Convert.ToInt32(prim.Attribute("id").Value), lineCount, lineList));
                            }
                        }
                    }
                    else if (parts.Name == "area")
                    {
                        area = parts.Value;
                    }
                }

                int IdTemplate = Convert.ToInt32(template.Attribute("id").Value);
                resultTask.Add(new Task(IdTemplate, stack, area));
            }

            return resultTask;
        }
    }
}
