using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TaskManager.API.Models.InputModels;
using TaskManager.API.Models.OutputModels;
using TaskManager.Business;
using TaskManager.Core.Models;

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private TaskService _taskService;
        private WorkerService _workerService;
        private IMapper _mapper;

        public WorkerController(IMapper mapper, WorkerService workerService, TaskService taskService)
        {
            _taskService = taskService;
            _workerService = workerService;
            _mapper = mapper;
        }

        [ProducesResponseType(typeof(WorkerOutputModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [HttpPost]
        public ActionResult<WorkerOutputModel> AddWorker([FromBody] WorkerInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return Conflict();
            }
            var dto = _mapper.Map<Worker>(inputModel);
            var addedWorkerId = _workerService.AddWorker(dto);
            var outputModel = _mapper.Map<WorkerOutputModel>(_workerService.GetWorkerById(addedWorkerId));
            return Ok(outputModel);
        }

        [ProducesResponseType(typeof(WorkerOutputModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{workerId}")]
        public ActionResult<WorkerOutputModel> UpdateWorker(int workerId, [FromBody] WorkerInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return Conflict();
            }
            var worker = _workerService.GetWorkerById(workerId);
            if (worker == null)
            {
                return NotFound();
            }
            var updateDto = _mapper.Map<Worker>(inputModel);
            updateDto.Id = workerId;
            _workerService.UpdateWorker(updateDto);
            var outputModel = _mapper.Map<WorkerOutputModel>(_workerService.GetWorkerById(workerId));
            return Ok(outputModel);
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{workerId}")]
        public ActionResult DeleteWorker(int workerId)
        {
            var worker = _workerService.GetWorkerById(workerId);
            if (worker == null)
            {
                return NotFound();
            }
            _workerService.DeleteWorkerById(workerId);
            return NoContent();
        }

        [ProducesResponseType(typeof(WorkerOutputModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{workerId}")]
        public ActionResult<WorkerOutputModel> GetWorkerById(int workerId)
        {
            var worker = _workerService.GetWorkerById(workerId);
            if (worker == null)
            {
                return NotFound();
            }
            var outputModel = _mapper.Map<WorkerOutputModel>(worker);
            return Ok(outputModel);
        }

        [ProducesResponseType(typeof(List<TaskOutputModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{workerId}/tasks")]
        public ActionResult<List<TaskOutputModel>> GetTasksByWorkerId(int workerId)
        {
            var worker = _workerService.GetWorkerById(workerId);
            if (worker == null)
            {
                return NotFound();
            }
            var outputModel = _mapper.Map<List<TaskOutputModel>>(worker.Tasks);
            return Ok(outputModel);
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("{workerId}/task/{taskId}")]
        public ActionResult AddTaskToWorker(int workerId, int taskId)
        {
            var worker = _workerService.GetWorkerById(workerId);
            if (worker == null)
            {
                return NotFound();
            }
            var task = _taskService.GetTaskById(taskId);
            if (task == null)
            {
                return NotFound();
            }
            _workerService.AddTaskToWorker(workerId, taskId);
            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{workerId}/task/{taskId}")]
        public ActionResult DeleteTaskToWorker(int workerId, int taskId)
        {
            var worker = _workerService.GetWorkerById(workerId);
            if (worker == null)
            {
                return NotFound();
            }
            var task = _taskService.GetTaskById(taskId);
            if (task == null)
            {
                return NotFound();
            }
            _workerService.DeleteTaskToWorker(workerId, taskId);
            return NoContent();
        }
    }
}
