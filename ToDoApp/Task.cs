using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ToDoApp
{
    public class Task : INotifyPropertyChanged
    {
        private string name;
        private string description;
        private bool isCompleted;
        public string Name { get; set; }
        public string Description { get; set; }

        public bool IsCompleted
        { 
            get => isCompleted;
            set 
            { 
                isCompleted = value;
                OnPropertyChanged();
            
            }
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
