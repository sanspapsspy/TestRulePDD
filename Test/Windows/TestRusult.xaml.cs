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
    /// Логика взаимодействия для TestRusult.xaml
    /// </summary>
    public partial class TestRusult : Window
    {

        public TestRusult()
        {
            InitializeComponent();
            if (CurrentUser.User != null)
                AddRange(AplicationContext.contex.TestResults.Where(r => r.user.ID == CurrentUser.User.ID).Select(r=>new { r.Grade, r.CorrectAnswer}).ToList());
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
        private void AddRange<T>(List<T> range)
        {
            Datas.ItemsSource = range;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MenuWind menuWind = new MenuWind();
            menuWind.Show();
            this.Close();
        }
    }
}
