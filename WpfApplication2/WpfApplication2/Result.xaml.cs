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
using System.Windows.Shapes;

namespace WpfApplication2
{
    /// <summary>
    /// Логика взаимодействия для Result.xaml
    /// </summary>
    public partial class Result : Window
    {
        TestChek ChekTest = new TestChek();

        int result = 0;
        int mark = 0;

        public Result(List<Task> taskList)
        {
            InitializeComponent();

            foreach (Task x in taskList)
            {
                string[] EAL = x.EtalonAnswer.Split('&');
                string[] UAL = x.UserAnswer.Split('&');

                foreach (string str in UAL)
                    str.Trim('&');

                int pro = UAL.Length;

                if (EAL.Length == UAL.Length)
                {
                    for (int i = 0; i < UAL.Length; i++)
                    {
                        for (int j = 0; j < EAL.Length; j++)
                        {
                            if (UAL[i] == EAL[j])
                            {
                                EAL[i] = "";
                                pro--;
                            }
                        }
                    }
                }

                if (pro == 0)
                    result++;
            }

            if (result == 10)
                mark = 5;
            if (result <= 9)
                mark = 4;
            if (result < 8)
                mark = 3;
            if (result < 6)
                mark = 2;

            point.Text = mark.ToString();
        }
    }
}
