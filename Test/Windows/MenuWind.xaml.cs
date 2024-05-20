using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Test.BD;

namespace Test.Windows
{
    /// <summary>
    /// Логика взаимодействия для MenuWind.xaml
    /// </summary>
    public partial class MenuWind : Window
    {
        public MenuWind()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TestRusult testRusult = new TestRusult();
            testRusult.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new QuestionAnswerWin(GenerateQuestions()).Show();
            this.Close();
        }
        private QuestionAnswer[] GenerateQuestions()
        {
            QuestionAnswer[] answers = new QuestionAnswer[10];
            Random random = new Random();

            int len = AplicationContext.contex.Questions.Count();
            for (int i = 0; i < 10; i++)
            {
                QuestionAnswer question;
                do
                {
                    question = AplicationContext.contex.Questions.ElementAt(random.Next(len));
                }
                while (IsIncluded(answers, question, i));
                answers[i] = question;
            }
            return answers;
        }
        private bool IsIncluded(QuestionAnswer[] questions, QuestionAnswer question, int i1)
        {
            for (int i = 0; i < i1; i++)
            {
                if (questions[i].ID == question.ID)
                    return true;
            }
            return false;
        }
    }
}
