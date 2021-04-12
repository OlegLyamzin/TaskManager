using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.API.Models.InputModels;
using TaskManager.API.Models.OutputModels;
using TaskManager.Core.Models;

namespace TaskManager.API
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<WorkerInputModel, Worker>();
            CreateMap<Worker, WorkerOutputModel>();

            CreateMap<TaskInputModel, WorkTask>();
            CreateMap<WorkTask, TaskOutputModel>();

            CreateMap<SearchTaskInputModel, SearchModel>();

            CreateMap<Departament, DepartamentOutputModel>();
        }
    }
}
