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
    /// Логика взаимодействия для QuestionAnswerWin.xaml
    /// </summary>
    public partial class QuestionAnswerWin : Window
    {
        QuestionAnswer[] questions;
        int currentQuestion;
        Random random;
        List<RadioButton> buttons = new List<RadioButton>();
        RadioButton rightButton;
        int rightAsnwers = 0;
        public QuestionAnswerWin(QuestionAnswer[] questions)
        {
            this.questions = questions;
            currentQuestion = 0;
            random = new Random();
            InitializeComponent();
            FillButtonsList();
            IllustrateQuestion();
        }
        private void FillButtonsList() {
            buttons.Add(answer1);
            buttons.Add(answer2);
            buttons.Add(answer3);
            buttons.Add(answer4);
        }
        private void IllustrateQuestion() {
            rightButton = GetRandomButton();
            rightButton.Content = questions[currentQuestion].CorrectAnswer;
            GetRandomButton().Content = questions[currentQuestion].FakeAnswer;
            GetRandomButton().Content = questions[currentQuestion].FakeAnswer2;
            GetRandomButton().Content = questions[currentQuestion].FakeAnswer3;
            question.Text = questions[currentQuestion].Question;
            FillButtonsList();
        }
        private RadioButton GetRandomButton() {
            int value = random.Next(buttons.Count);
            var button = buttons[value];
            buttons.RemoveAt(value);
            return button;
        }

        private void confirm_Click(object sender, RoutedEventArgs e)
        {
            rightButton.Background = Brushes.Green;
            if (!(bool)rightButton.IsChecked!)
            {
                foreach (var button in buttons)
                    if ((bool)button.IsChecked!)
                        button.Background = Brushes.Red;
            }
            else
                rightAsnwers++;
            confirm.Content = "Далее";
            confirm.Click -= confirm_Click;
            confirm.Click += next_Click;
        }
        private void next_Click(object sender, RoutedEventArgs e)
        {
            currentQuestion++;

            confirm.Content = "Выбрать";
            confirm.Click -= next_Click;
            confirm.Click += confirm_Click;

            foreach (var button in buttons) {
                button.Background = null;
                button.IsChecked = false;
            }

            if (currentQuestion == 10)
            {
                AplicationContext.contex.TestResults.Add(new TestResult() { user = CurrentUser.User, Grade = rightAsnwers, CorrectAnswer = rightAsnwers.ToString() });
                AplicationContext.contex.SaveChanges();
                new MenuWind().Show();
                this.Close();
                return;
            }

            IllustrateQuestion();
        }
    }
}
