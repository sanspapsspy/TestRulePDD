using System.Configuration;
using System.Data;
using System.Windows;
using Test.BD;

namespace Test
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        [STAThread]
        static void Main()
        {
            new AplicationContext();
            App app = new App();
            MainWindow window = new MainWindow();
            window.Title = "Диплом";
            app.Run(window);
        }
    }

}
