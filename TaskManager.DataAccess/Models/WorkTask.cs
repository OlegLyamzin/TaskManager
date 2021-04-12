using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.DataAccess.Models
{
    public class WorkTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Priority { get; set; }
        public int ClientDepartamentId { get; set; }
        public int ExecutorDepartamentId { get; set; }
        public virtual List<Worker> Workers { get; set; }  
        public WorkTask()
        {
            Workers = new List<Worker>();
        }
    }
}
