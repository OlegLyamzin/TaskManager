using System;
using System.Data.Entity;
using TaskManager.Core;
using Microsoft.Extensions.Options;
using TaskManager.Core.Models;

namespace TaskManager.DataAccess
{
    public class TasksContext : DbContext
    {
        static TasksContext()
        {
            Database.SetInitializer(new DbInitializer());
        }
        public TasksContext(IOptions<AppSettings> options) : base(options.Value.CONNECTION_STRING) 
        {
        }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<WorkTask> Tasks { get; set; }
        public DbSet<Departament> Departaments { get; set; }
    }
}
