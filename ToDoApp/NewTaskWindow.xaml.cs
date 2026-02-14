using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ToDoApp
{
    /// <summary>
    /// Interaction logic for NewTaskWindow.xaml
    /// </summary>
    public partial class NewTaskWindow : Window
    {
        public Task Result { get; set; }
        public NewTaskWindow()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Task task = new Task();
            

            if (NameTextBox.Text != "")
            {
                task.Name = NameTextBox.Text;
                task.IsCompleted = IsCompletedCheckBox.IsChecked.Value;
                task.Description = DescriptionTextBox.Text;

                Result = task;
                DialogResult = true;
            }
            else {
                NameTextBox.Background = Brushes.Red;
            }

        }

        private void DescriptionTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Window_Closed(object sender, EventArgs e)
        {

        }
    }
}
