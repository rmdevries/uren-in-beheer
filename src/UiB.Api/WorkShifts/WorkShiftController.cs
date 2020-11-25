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
        public IActionResult Read()
        {
            var workShifts = _service.Read();
            return Ok(workShifts);
        }
    }
}