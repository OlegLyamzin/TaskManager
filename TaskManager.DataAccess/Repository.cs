using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.Core;
using TaskManager.DataAccess.Models;

namespace TaskManager.DataAccess
{
    public class Repository
    {
        private TasksContext _db;
        public Repository(IOptions<AppSettings> options)
        {
            _db = new TasksContext(options);
        }

        public int AddWorker(Worker worker)
        {
            _db.Workers.Add(worker);
            _db.SaveChanges();
            return worker.Id;
        }

        public void UpdateWorker(Worker worker)
        {
            var workerDb = _db.Workers.SingleOrDefault(w => w.Id == worker.Id);
            workerDb.FirstName = worker.FirstName ?? workerDb.FirstName;
            workerDb.LastName = worker.LastName ?? workerDb.LastName; ;
            workerDb.Patronymic = worker.Patronymic ?? workerDb.Patronymic;
            workerDb.Email = worker.Email ?? workerDb.Email;
            _db.SaveChanges();
        }

        public void DeleteTaskToWorker(int workerId, int taskId)
        {
            var workerDb = _db.Workers.SingleOrDefault(w => w.Id == workerId);
            workerDb.Tasks.Remove(_db.Tasks.SingleOrDefault(t => t.Id == taskId));
            _db.SaveChanges();
        }

        public void AddTaskToWorker(int workerId, int taskId)
        {
            var workerDb = _db.Workers.SingleOrDefault(w => w.Id == workerId);
            workerDb.Tasks.Add(_db.Tasks.SingleOrDefault(t => t.Id == taskId));
            _db.SaveChanges();
        }

        public Worker GetWorkerById(int id)
        {
            return _db.Workers.SingleOrDefault(w => w.Id == id);
        }

        public void DeleteWorkerById(int id)
        {
            var workerDb = _db.Workers.SingleOrDefault(w => w.Id == id);
            _db.Workers.Remove(workerDb);
            _db.SaveChanges();
        }

        public int AddTask(WorkTask task)
        {
            _db.Tasks.Add(task);
            _db.SaveChanges();
            return task.Id;
        }

        public void UpdateTask(WorkTask task)
        {
            var taskDb = _db.Tasks.SingleOrDefault(t => t.Id == task.Id);
            taskDb.Name = task.Name ?? taskDb.Name;
            taskDb.Priority = task.Priority;
            taskDb.StartDate = task.StartDate;
            taskDb.EndDate = task.EndDate;
            taskDb.ClientDepartamentId = task.ClientDepartamentId;
            taskDb.ExecutorDepartamentId = task.ExecutorDepartamentId;
            _db.SaveChanges();
        }

        public WorkTask GetTaskById(int id)
        {
            return _db.Tasks.SingleOrDefault(t => t.Id == id);
        }
        public void DeleteTaskById(int id)
        {
            var taskDb = _db.Tasks.SingleOrDefault(t => t.Id == id);
            _db.Tasks.Remove(taskDb);
            _db.SaveChanges();
        }
    }
}
