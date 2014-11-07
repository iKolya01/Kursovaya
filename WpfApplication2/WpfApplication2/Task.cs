﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using WpfApplication2.Primitives;

namespace WpfApplication2
{
    class Task
    {
        int id;
        public int ID
        {
            get { return id; }
            set { if (value > 0) id = value; }
        }

        List<Primitive> listPrimitives;
        public List<Primitive> ListPrimitives
        {
            get { return listPrimitives; }
            set { listPrimitives = value; }
        }

        string area;
        public string Area
        {
            get { return area; }
            set { area = value; }
        }

        bool[,] points = new bool[110, 50];

        public Task() { }

        public Task(int id, List<Primitive> listPrimitives, string area)
        {
            this.id = id;
            this.listPrimitives = listPrimitives;
            this.area = area;

            for (int i = 0; i < 110; i++)
                for (int j = 0; j < 50; j++)
                    points[i, j] = true;
        }
        
        public void Draw(Canvas myCanvas)
        {
            string operation = "";

            int i = 0;
            while(i < area.Length)
            {
                string idFun = "";

                if (area[i] == '(')
                {
                    i++;
                    while (i < area.Length && area[i] != ')')
                    {
                        idFun += area[i];
                        i++;
                    }

                    string[] id = idFun.Split('.');

                    switch (id[1])
                    {
                        case "a":
                            listPrimitives[Convert.ToInt32(id[0])].aDraw(ref points);
                            break;
                        case "b":
                            listPrimitives[Convert.ToInt32(id[0])].bDraw(ref points);
                            break;
                        case "i":
                            listPrimitives[Convert.ToInt32(id[0])].iDraw(ref points);
                            break;
                        case "d":
                            listPrimitives[Convert.ToInt32(id[0])].dDraw(ref points);
                            break;
                        case "u":
                            listPrimitives[Convert.ToInt32(id[0])].uDraw(ref points);
                            break;
                    }
                }
                i++;
            }

            for (int x = 0; x < 110; x++)
                for (int y = 0; y < 50; y++)
                {
                    if (points[x, y]) new point(-9, x * 5, y * 5).Draw(myCanvas, System.Windows.Media.Brushes.DarkCyan);
                }

            foreach (var x in listPrimitives)
            {
                x.Draw(myCanvas);
            }
        }
    }
}
