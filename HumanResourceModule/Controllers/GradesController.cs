using HumanResourceModule.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using HumanResource.BLL.IServices;


namespace HumanResourceModule.Controllers
{
    // [Authorize(Roles = "HR")] // Requires HR role
    [ApiController]
    [Route("api/[controller]")]
    public class GradesController : Controller
    {
        private readonly IGradeService _gradeService;

        public GradesController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        [HttpGet]
        public IActionResult GetGrades()
        {
            var grades = _gradeService.GetAllGrades();

            var gradeDTOs = grades.Select(grade => new GradeDTO
            {
                Id = grade.Id,
                Name = grade.Name
            }).ToList();

            return Ok(gradeDTOs); // Returns the list of GradeDTOs
        }
    }

}
