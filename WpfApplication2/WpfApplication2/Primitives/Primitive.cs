using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WpfApplication2.Primitives
{
    class Primitive//базовый класс для всех примитивов
    {
        protected int id;//идентификатор примитива
        protected int linewidth;//ширина линии

        public int ID
        {
            get { return id; }
            set { if (value >= 0) id = value; }
        }
        public int LineWidth
        {
            get { return linewidth; }
            set { if (value > 0) linewidth = value; }
        }

        public virtual string toString()//преобразование в строку
        {
            return id.ToString();
        }

        public virtual void Draw(Canvas myCanvas) { }//отрисовка на форме

        public virtual void Draw(Canvas myCanvas, bool lbl) { }//отрисовка на форме

        public virtual void aDraw(ref bool[,] points) { }//отрисовка на форме

        public virtual void bDraw(ref bool[,] points) { }//отрисовка на форме

        public virtual void iDraw(ref bool[,] points) { }//отрисовка на форме

        public virtual void uDraw(ref bool[,] points) { }//отрисовка на форме

        public virtual void dDraw(ref bool[,] points) { }

        public virtual bool Included(Point point) { return true; }//проверка точки на принадлежность
        
        public virtual bool Included(int X, int Y) { return true; }//проверка точки на принадлежность

        public virtual bool unIncluded(Point point) { return true; }//проверка точки на не принадлежность

        public virtual bool Above(Point point) { return true; }

        public virtual bool Below(Point point) { return true; }

        public virtual int Width { get; set; }

        public virtual int Hieght { get; set; }

        public virtual int R { get; set; }

        public virtual point Coordinate { get; set; }

        public virtual point One { get; set; }

        public virtual point Two { get; set; }

        public virtual point Three { get; set; }

        public virtual string Above() { return ""; }

        public virtual string Below() { return ""; }

        public virtual string Included() { return ""; }

        public virtual string unIncluded() { return ""; }
    }
}
