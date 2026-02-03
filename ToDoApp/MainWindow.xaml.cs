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

namespace ToDoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] tasks = new string[3];
        
        public MainWindow()
        {
            InitializeComponent();
            tasks[0] = "Домашня із С#";
            tasks[1] = "Урок з Linux";
            tasks[2] = "Німецька в Bussuu";

            ToDoListBox.ItemsSource = tasks;

        }

    }
}