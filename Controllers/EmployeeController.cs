using BVK_Advocates_Law_Firm.IRepository;
using BVK_Advocates_Law_Firm.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BVK_Advocates_Law_Firm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository) { 
            _employeeRepository = employeeRepository;
        }

        /// <summary>
        /// Returns paginated employees.
        /// Query params: pageNumber (default 1), pageSize (default 10)
        /// </summary>
        [HttpGet]
        [Route("GetAllEmployees")]
        public IActionResult GetAllEmployees([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            if (pageNumber < 1) return BadRequest("pageNumber must be >= 1.");
            if (pageSize < 1 || pageSize > 100) return BadRequest("pageSize must be between 1 and 100.");

            try
            {
                var allEmployees = _employeeRepository.GetAll() ?? new List<EmployeeModel>();
                var totalCount = allEmployees.Count;
                var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

                var items = allEmployees
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                var response = new PagedResponse<EmployeeModel>(
                    items,
                    pageNumber,
                    pageSize,
                    totalCount,
                    totalPages
                );

                return Ok(response);
            }
            catch (Exception ex)
            {
                // TODO: log exception (ex)
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching employees.");
            }
        }

    }
}
