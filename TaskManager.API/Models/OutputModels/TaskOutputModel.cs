using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.API.Models.OutputModels
{
    public class TaskOutputModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Priority { get; set; }
        public int ClientDepartamentId { get; set; }
        public int ExecutorDepartamentId { get; set; }
    }
}
