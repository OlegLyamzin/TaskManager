using System;
using TaskManager.DataAccess;
using TaskManager.DataAccess.Models;

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
    }
}
