using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

//using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
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
        ObservableCollection<Task> tasksList = new ObservableCollection<Task>();

        public MainWindow()
        {
            InitializeComponent();

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

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NewTaskWindow newTaskWindow = new NewTaskWindow();
            newTaskWindow.Owner = this;
            newTaskWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            if(newTaskWindow.ShowDialog() == true)
            {
                Task newTask = newTaskWindow.Result;
                tasksList.Add(newTask);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            int index = ToDoListBox.SelectedIndex;
            if (index != -1)
            {
                tasksList.RemoveAt(index);
            }
        }

        private void CompleteButton_Click(object sender, RoutedEventArgs e)
        {
            if(ToDoListBox.SelectedItem is Task selectedTask)
            {
                selectedTask.IsCompleted = true;
                ApplyFilter();
            }
        }

        private void ApplyFilter()
        {
            var view = CollectionViewSource.GetDefaultView(tasksList);
            if (view == null) return;

            view.Filter = (obj) =>
            {
                if (obj is Task task)
                {
                    if (AllRadioButton.IsChecked == true) return true;
                    if (NotCompletedRadioButton.IsChecked == true) return !task.IsCompleted;
                    if (Completed.IsChecked == true) return task.IsCompleted;
                }
                return true;
            };

            view.Refresh();
        }

        private void AllRadioButton_Checked(object sender, RoutedEventArgs e) => ApplyFilter();
        private void NotCompletedRadioButton_Checked(object sender, RoutedEventArgs e) => ApplyFilter();

        private void Completed_Checked(object sender, RoutedEventArgs e) => ApplyFilter();

        string fileName = "tasks.json";
        private void Window_Closed(object sender, EventArgs e)
        {
            var options = new JsonSerializerOptions
            {
                // 1. Щоб бачити кирилицю як текст, а не коди \u04...
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),

                // 2. Щоб текст був з відступами (красивий), а не в один рядок
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(tasksList, options);
            File.WriteAllText(fileName, jsonString);

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (File.Exists(fileName))
            {
                //read file
                string jsonString = File.ReadAllText(fileName);
                tasksList = JsonSerializer.Deserialize<ObservableCollection<Task>>(jsonString) ?? new ObservableCollection<Task>();

                ToDoListBox.ItemsSource = tasksList;
                AllRadioButton.IsChecked = true;
            }

        }
    }
}