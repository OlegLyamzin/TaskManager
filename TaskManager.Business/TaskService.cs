using System;
using System.Collections.Generic;
using System.Linq;
using TaskManager.Core;
using TaskManager.Core.Models;
using TaskManager.DataAccess;

namespace TaskManager.Business
{
    public class TaskService
    {
        private Repository _repository;

        public TaskService(Repository repository)
        {
            _repository = repository;
        }
        public int AddTask(WorkTask task) => _repository.AddTask(task);

        public void UpdateTask(WorkTask task) => _repository.UpdateTask(task);

        public WorkTask GetTaskById(int id) => _repository.GetTaskById(id);

        public void DeleteTaskById(int id) => _repository.DeleteTaskById(id);

        public List<WorkTask> SearchTasks(SearchModel searchModel)
        {
            var tasks = _repository.GetTasks();
            
            var filteredTasks = tasks
                .Where(t => (searchModel.Name == null || t.Name.Contains(searchModel.Name))
                && (searchModel.Priority == null || t.Priority == searchModel.Priority)
                && Between(t.StartDate, searchModel.LeftBorderStartDate, searchModel.RightBorderStartDate)
                && Between(t.EndDate, searchModel.LeftBorderEndDate, searchModel.RightBorderEndDate));
            
            filteredTasks = searchModel.Sort switch
            {
                SortBy.NameAsc => filteredTasks.OrderBy(t => t.Name),
                SortBy.NameDesc => filteredTasks.OrderByDescending(t => t.Name),
                SortBy.PriorityAsc => filteredTasks.OrderBy(t => t.Priority),
                SortBy.PriorityDesc => filteredTasks.OrderByDescending(t => t.Priority),
                SortBy.StartDateAsc => filteredTasks.OrderBy(t => t.StartDate),
                SortBy.StartDateDesc => filteredTasks.OrderByDescending(t => t.StartDate),
                SortBy.EndDateAsc => filteredTasks.OrderBy(t => t.EndDate),
                SortBy.EndDateDesc => filteredTasks.OrderByDescending(t => t.EndDate),
                _ => filteredTasks.OrderBy(t => t.Name)
            };

            return filteredTasks.ToList();
        }

        private bool Between(DateTime input, DateTime? leftBorder, DateTime? rightBorder)
        {            
            return leftBorder == null || rightBorder == null || (input > leftBorder && input < rightBorder);
        }

    }
}
