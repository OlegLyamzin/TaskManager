using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Core.Models
{
    public class Departament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<WorkTask> Tasks { get; set; }
        public Departament()
        {
            Tasks = new List<WorkTask>();
        }
    }
}
