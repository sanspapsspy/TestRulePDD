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
using Test.Windows;
using Test.BD;

namespace Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            Users user = new Users();
            user.Name = TbLogin.Text;
            user.Password = TbPassword.Text;
            var users = AplicationContext.contex.Users.Where(u => u.Name == user.Name);
            if (users.Count() == 1)
            {
                CurrentUser.User = users.First();
                MenuWind menuWind = new MenuWind();
                menuWind.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Не правильно попробуй ещё раз");
            }
        }
        private void BtnReGistrate_Click(object sender, RoutedEventArgs e)
        {
            RegistrateWind registrateWind = new RegistrateWind();
            registrateWind.Show();
            this.Close();
        }
    }
}