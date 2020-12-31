using Microsoft.AspNetCore.Mvc;
using UiB.Domain.Workshifts;

namespace UiB.Api.Workshifts
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkshiftController : ControllerBase
    {
        private readonly IWorkshiftService _service;

        public WorkshiftController(IWorkshiftService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Create(WorkshiftDto workshiftDto)
        {
            var workshift = _service.Create(workshiftDto);
            return Ok(workshift);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Read(int id)
        {
            var workshifts = _service.Read(id);
            return Ok(workshifts);
        }

        [HttpGet]
        public IActionResult Read(int page = 0, int pageSize = 50)
        {
            var workshifts = _service.Read(page, pageSize);
            return Ok(workshifts);
        }
    }
}