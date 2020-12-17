using Microsoft.AspNetCore.Mvc;
using UiB.Domain.WorkShifts;

namespace UiB.Api.WorkShifts
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkShiftController : ControllerBase
    {
        private readonly IWorkShiftService _service;

        public WorkShiftController(IWorkShiftService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Create(WorkShiftDto workShiftDto)
        {
            var workShift = _service.Create(workShiftDto);
            return Ok(workShift);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Read(int id)
        {
            var workShifts = _service.Read(id);
            return Ok(workShifts);
        }

        [HttpGet]
        public IActionResult Read(int page = 0, int pageSize = 50)
        {
            var workShifts = _service.Read(page, pageSize);
            return Ok(workShifts);
        }
    }
}