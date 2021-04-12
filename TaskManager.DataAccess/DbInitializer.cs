using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using TaskManager.Core.Models;

namespace TaskManager.DataAccess
{
    public class DbInitializer : CreateDatabaseIfNotExists<TasksContext>
    {
        protected override void Seed(TasksContext context)
        {
            var d1 = new Departament()
            {
                Name = "First Departament"
            };
            var d2 = new Departament()
            {
                Name = "Second Departament"
            };
            context.Departaments.Add(d1);
            context.Departaments.Add(d2);
            context.SaveChanges();
        }
    }
}
