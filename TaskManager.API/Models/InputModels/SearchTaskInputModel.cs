using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Core;

namespace TaskManager.API.Models.InputModels
{
    public class SearchTaskInputModel
    {
        public string Name { get; set; }
        public int? Priority { get; set; }
        public DateTime? LeftBorderStartDate { get; set; }
        public DateTime? RightBorderStartDate { get; set; }
        public DateTime? LeftBorderEndDate { get; set; }
        public DateTime? RightBorderEndDate { get; set; }
        public int Sort { get; set; } 
    }
}
