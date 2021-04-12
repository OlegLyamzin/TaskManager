using System;

namespace TaskManager.API.Models.InputModels
{
    public class TaskInputModel
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Priority { get; set; }
        public int ClientDepartamentId { get; set; }
        public int ExecutorDepartamentId { get; set; }
    }
}