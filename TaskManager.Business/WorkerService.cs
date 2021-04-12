using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.DataAccess;
using TaskManager.DataAccess.Models;

namespace TaskManager.Business
{
    public class WorkerService
    {
        private Repository _repository;

        public WorkerService(Repository repository)
        {
            _repository = repository;
        }
        public int AddWorker(Worker worker) => _repository.AddWorker(worker);

        public void UpdateWorker(Worker worker) => _repository.UpdateWorker(worker);

        public Worker GetWorkerById(int id) => _repository.GetWorkerById(id);

        public void DeleteWorkerById(int id) => _repository.DeleteWorkerById(id);

        public void AddTaskToWorker(int workerId, int taskId) => _repository.AddTaskToWorker(workerId, taskId);

        public void DeleteTaskToWorker(int workerId, int taskId) => _repository.DeleteTaskToWorker(workerId, taskId);

    }
}
