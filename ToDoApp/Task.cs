using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp
{
    //[Serializible]
    public class Task
    {
        public string Name { get; set; }

        public bool IsCompleted  { get; set; }

        public string Description { get; set; }
    }
}
