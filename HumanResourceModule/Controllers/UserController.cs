using HumanResource.BLL.IServices;
using HumanResource.DAL.Models;
using HumanResourceModule.Models;
using Microsoft.AspNetCore.Mvc;

namespace HumanResourceModule.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employees = _userService.GetAllUsers();

            var employeeDTOs = employees.Select(employee => new UserDTO
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                PhoneNumber = employee.PhoneNumber,
                EmailAddress = employee.EmailAddress,
                Role = employee.Role,
                CurrentGradeId = employee.CurrentGradeId,
                // Map other properties as needed
            }).ToList();

            return Ok(employeeDTOs);

        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var employee = _userService.GetUserById(id);

            if (employee == null)
            {
                return NotFound();
            }

            var employeeDTO = new UserDTO
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                PhoneNumber = employee.PhoneNumber,
                EmailAddress = employee.EmailAddress,
                Role = employee.Role,
                CurrentGradeId = employee.CurrentGradeId 
            };

            return Ok(employeeDTO);
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] AddUserDTO userDTO)
        {
                if (userDTO == null)
                {
                    return BadRequest("Employee data is required.");
                }

                // Map EmployeeDTO to Employee model
                var employee = new User
                {
                    FirstName = userDTO.FirstName,
                    LastName = userDTO.LastName,
                    PhoneNumber = userDTO.PhoneNumber,
                    EmailAddress = userDTO.EmailAddress,
                    Role = userDTO.Role,
                    CurrentGradeId = userDTO.CurrentGradeId 
                };

                _userService.AddUser(employee);

                return StatusCode(201); // Created
            
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            // Retrieve the user based on the provided employeeId
            var user = _userService.GetUserById(id);

            // Check if the user exists
            if (user != null)
            {
                // Delete the user
                _userService.DeleteUser(id);
            }

            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployeeGrade(int id, [FromBody] UserDTO employeeDTO)
        {
            
                _userService.UpdateUserGrade(id, employeeDTO.CurrentGradeId);
                return Ok("Employee grade updated successfully.");
        }
    }
}
