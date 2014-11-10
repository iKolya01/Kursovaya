using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApplication2.Primitives;

namespace WpfApplication2
{
    /// <summary>
    /// Логика взаимодействия для Test.xaml
    /// </summary>
    public partial class Test : Window
    {/*
      * единичный отрезок для координат = 10px = 10 пунктов.
      * начало координат (10; 260).
      * вершина Оу (10; 10).
      * вершина Ох (250; 550).
      * 
     */
        int i = 0;

        static List<Task> taskList = new List<Task>();

        static string userName = "";

        static string fileAdress = "base.xml";

        from_XML_to_Task Base = new from_XML_to_Task(fileAdress);

        List<Primitive> arr = new List<Primitive>();

        public void drawXOY(Canvas draw)//отрисовка оси координат
        {   //ось Оу
            new line(0, new point(0, 0, 250), new point(0, 5, 245), 1).Draw(draw);
            new line(0, new point(0, 0, 250), new point(0, -5, 245), 1).Draw(draw);
            new line(0, new point(0, 0, 0), new point(0, 0, 250), 1).Draw(draw);

            //ось Ох
            new line(0, new point(0, 550, 0), new point(0, 545, -5), 1).Draw(draw);
            new line(0, new point(0, 550, 0), new point(0, 545, 5), 1).Draw(draw);
            new line(0, new point(0, 0, 0), new point(0, 550, 0), 1).Draw(draw);

            //обозначение начала О
            new label(new Point(-5, 3), "O").Draw(draw);

            //обозначаем Х
            new label(new Point(540, 3), "X").Draw(draw);

            //обозначаем Y
            new label(new Point(3, 255), "Y").Draw(draw);

            /*
             *Далее идет нанесение штрихов для осей - единичных отрезков. 
            */
            for (int i = 10; i < 250; i += 10)//для оси Оу
            {
                new line(0, new point(0, -3, i), new point(0, 3, i), 1).Draw(draw);
            }
            for (int i = 10; i < 550; i += 10)//для оси Ох
            {
                new line(0, new point(0, i, -3), new point(0, i, 3), 1).Draw(draw);
            }
        }

        public Test(string FI)
        {
            InitializeComponent();

            taskList = Base.Decode();

            drawXOY(scene);
            taskList[i].Draw(scene);

            lbl.Text = taskList[i].EtalonAnswer;

            userName = FI;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (i < taskList.Count)
            {
                taskList[i].UserAnswer = answer.Text;

                scene.Children.Clear();
                answer.Text = "";

                drawXOY(scene);
            }else
            {
                Result newRes = new Result(taskList, userName);
                newRes.Show();
                this.Close();
            }

            i++;

            if (i < taskList.Count)
            {
                taskList[i].Draw(scene);

                lbl.Text = taskList[i].EtalonAnswer;
            }else
            {
                Result newRes = new Result(taskList, userName);
                newRes.Show();
                this.Close();
            }
        }
    }
}
