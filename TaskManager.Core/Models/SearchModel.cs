using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Core.Models
{
    public class SearchModel
    {
        public string Name { get; set; }
        public int? Priority { get; set; }
        public DateTime? LeftBorderStartDate { get; set; }
        public DateTime? RightBorderStartDate { get; set; }
        public DateTime? LeftBorderEndDate { get; set; }
        public DateTime? RightBorderEndDate { get; set; }
        public SortBy Sort { get; set; }
    }
}
