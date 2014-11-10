using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
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
        List<bool> taskResult = new List<bool>();
        List<string[]> answer = new List<string[]>();

        int result = 0;
        int mark = 0;

        string userName = "";

        public Result(List<Task> taskList, string FI)
        {
            InitializeComponent();

            foreach (Task x in taskList)
            {
                string[] ans = {x.EtalonAnswer, x.UserAnswer};
                answer.Add(ans);

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
                {
                    result++;
                    taskResult.Add(true);
                }else
                    taskResult.Add(false);
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

            userName = FI;

            addStatistic();
        }

        private void addStatistic()
        {
            string OUT = @" <div class='col-md-9'><h1>" + userName + @"</h1></div>
	                        <div class='col-md-3'><h2>Оценка: " + mark.ToString() + @"</h2></div>
	                        <table class='table table-bordered'>
		                        <thead>
			                    <tr>
			                        <th>#</th>
			                        <th>Эталонное решение</th>
			                        <th>Ответ пользователя</th>
			                    </tr>
		                        </thead>
		                        <tbody>";

            for (int i = 0; i < taskResult.Count; i++)
            {
                string tr = "";

                if (taskResult[i])
                    tr = "<tr class='success'>";
                else
                    tr = "<tr class='danger'>";

                tr += "<td>" + (i + 1).ToString() + "</td>";
                tr += "<td>" + answer[i][0] + "</td>";
                tr += "<td>" + answer[i][1] + "</td>";
                tr += "</tr>";

                OUT += tr;
            }

            OUT += "</table>";

            File.AppendAllText("statistic.html", OUT);
        }
    }
}
