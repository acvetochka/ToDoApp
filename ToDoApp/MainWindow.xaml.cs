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
        //string[] tasks = new string[3];
        List<Task> tasksList = new List<Task>();
        
        public MainWindow()
        {
            InitializeComponent();
            //tasks[0] = "Домашня із С#";
            //tasks[1] = "Урок з Linux";
            //tasks[2] = "Німецька в Bussuu";

            Task task1 = new Task();
            task1.Name = "Домашня із С#";
            task1.Description = "Додайте до класу Task, у ToDoApplication проекті, властивість Description яка буде зберігати більш детальний опис задачі. Зробіть щоб при подвійному кліку на задачу в списку виводилося значення властивості Description у MessageBox.";
            task1.isCompleted = false;

            Task task2 = new Task();
            task2.Name = "Урок з Linux";
            task2.Description = "Розділ Операційна система";
            task2.isCompleted = false;

            Task task3 = new Task();
            task3.Name = "Німецька в Bussuu";
            task3.Description = "Пройти декілька уроків";
            task3.isCompleted = false;

            tasksList.Add(task1);
            tasksList.Add(task2);
            tasksList.Add(task3);

            ToDoListBox.ItemsSource = tasksList;
            ToDoListBox.DisplayMemberPath = "Name";

        }

        private void ToDoListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Task selected = ToDoListBox.SelectedItem as Task;
            if (selected != null)
            {
                MessageBox.Show(selected.Description);
            }
        }
    }
}