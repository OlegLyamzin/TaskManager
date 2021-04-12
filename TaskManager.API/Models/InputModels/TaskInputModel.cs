using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.API.Models.InputModels
{
    public class TaskInputModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        [Range(0, 5)]
        public int Priority { get; set; }
        [Required]
        public int ClientDepartamentId { get; set; }
        [Required]
        public int ExecutorDepartamentId { get; set; }
    }
}