using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.API.Models.InputModels;
using TaskManager.API.Models.OutputModels;
using TaskManager.Business;
using TaskManager.DataAccess.Models;

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private TaskService _taskService;
        private IMapper _mapper;

        public TaskController(IMapper mapper, TaskService taskService)
        {
            _taskService = taskService;
            _mapper = mapper;
        }

        [ProducesResponseType(typeof(TaskOutputModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [HttpPost]
        public ActionResult<TaskOutputModel> AddTask([FromBody] TaskInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return Conflict();
            }
            var dto = _mapper.Map<WorkTask>(inputModel);
            var addedTaskId = _taskService.AddTask(dto);
            var outputModel = _mapper.Map<TaskOutputModel>(_taskService.GetTaskById(addedTaskId));
            return Ok(outputModel);
        }

        [ProducesResponseType(typeof(TaskOutputModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{taskId}")]
        public ActionResult<TaskOutputModel> UpdateTask(int taskId, [FromBody] TaskInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return Conflict();
            }
            var task = _taskService.GetTaskById(taskId);
            if (task == null)
            {
                return NotFound();
            }
            var updateDto = _mapper.Map<WorkTask>(inputModel);
            updateDto.Id = taskId;
            _taskService.UpdateTask(updateDto);
            var outputModel = _mapper.Map<TaskOutputModel>(_taskService.GetTaskById(taskId));
            return Ok(outputModel);
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{taskId}")]
        public ActionResult DeleteTask(int taskId)
        {
            var task = _taskService.GetTaskById(taskId);
            if (task == null)
            {
                return NotFound();
            }
            _taskService.DeleteTaskById(taskId);
            return NoContent();
        }

        [ProducesResponseType(typeof(TaskOutputModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{taskId}")]
        public ActionResult<TaskOutputModel> GetTaskById(int taskId)
        {
            var task = _taskService.GetTaskById(taskId);
            if (task == null)
            {
                return NotFound();
            }
            var outputModel = _mapper.Map<TaskOutputModel>(task);
            return Ok(outputModel);
        }
    }
}
