using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.DataAccess.Models
{
    public class Worker
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }
        public virtual List<WorkTask> Tasks { get; set; }

        public Worker()
        {
            Tasks = new List<WorkTask>();
        }
    }
}
