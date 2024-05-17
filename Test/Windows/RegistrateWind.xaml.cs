using Microsoft.VisualBasic.ApplicationServices;
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
    /// Логика взаимодействия для RegistrateWind.xaml
    /// </summary>
    public partial class RegistrateWind : Window
    {

        
        public RegistrateWind()
        {
            InitializeComponent();
        }

        private void NewUser_Click(object sender, RoutedEventArgs e)
        {
            Users user = new Users();
            user.Name = TbLogin.Text; 
            user.Password = TbPassword.Text;
            var users = AplicationContext.contex.Users.Where(u => u.Name == user.Name);
            if (users.Count() == 0) { 
                AplicationContext.contex.Users.Add(user);
                AplicationContext.contex.SaveChanges();

                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                //выводим сообщение, что данный пользователь зарегестрирован
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {   
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
