using HumanResource.BLL.IServices;
using HumanResource.DAL.Interfaces;
using HumanResource.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IGradeHistoryRepository _gradeHistoryRepository;

        public UserService(IUserRepository userRepository, IGradeHistoryRepository gradeHistoryRepository)
        {
            _userRepository = userRepository;
            _gradeHistoryRepository = gradeHistoryRepository;
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public User GetUserById(int employeeId)
        {
            return _userRepository.GetUserById(employeeId);
        }

        public void AddUser(User user)
        {
            //ValidateEmployeeId(user.EmployeeId);
            ValidateEmailAddress(user.EmailAddress);

            _userRepository.AddUser(user);

            var gradeHistory = new GradesHistory
            {
                AssignedOn = DateTime.Now,
                EmployeeId = user.EmployeeId,
                GradeId = user.CurrentGradeId
            };
            _gradeHistoryRepository.AddGradeHistory(gradeHistory);
        }

        public void DeleteUser(int employeeId)
        {
            var user = _userRepository.GetUserById(employeeId);
            if (user != null)
            {
                _userRepository.DeleteUser(user);
            }
        }


        public void UpdateUserGrade(int employeeId, int newGradeId)
        {
            var user = _userRepository.GetUserById(employeeId);
            if (user == null)
            {
                throw new ArgumentException("User not found.");
            }

            var oldestGradeChangeDate = _gradeHistoryRepository.GetOldestGradeChangeDate(employeeId);

            if (oldestGradeChangeDate.HasValue && oldestGradeChangeDate.Value > DateTime.Now.AddYears(-2))
            {
                throw new InvalidOperationException("Cannot update grade. Minimum 2 years required before grade change.");
            }

            var lastGradeChangeDate = _gradeHistoryRepository.GetLastGradeChangeDate(employeeId);

            if (lastGradeChangeDate.HasValue && lastGradeChangeDate.Value > DateTime.Now.AddYears(-1))
            {
                throw new InvalidOperationException("Cannot update grade. Minimum 1 year required between grade changes.");
            }

            // Additional validation and grade update logic here...

            _userRepository.UpdateUserGrade(employeeId, newGradeId);

            var gradeHistory = new GradesHistory
            {
                AssignedOn = DateTime.Now,
                EmployeeId = employeeId,
                GradeId = newGradeId
            };
            _gradeHistoryRepository.AddGradeHistory(gradeHistory);
        }

        private void ValidateEmployeeId(int employeeId)
        {
            if (employeeId < 100000 || employeeId > 999999)
            {
                throw new ArgumentException("Employee ID must be a valid 6 digit number.");
            }
        }

        private void ValidateEmailAddress(string emailAddress)
        {
            if (!emailAddress.EndsWith("@cognizant.com", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("Email address must be in the format xxxx@cognizant.com.");
            }
        }

        private void ValidateGradeChange(int oldGradeId, int newGradeId)
        {
            if (newGradeId < oldGradeId)
            {
                throw new InvalidOperationException("Grade cannot be downgraded.");
            }
        }

        private void ValidateGradeUpdateFrequency(User user)
        {

            var currentDate = DateTime.Now;

            // Check if the grade was updated within the last year
            var lastGradeChangeDate = _gradeHistoryRepository.GetLastGradeChangeDate(user.EmployeeId);
            if (lastGradeChangeDate != null && (currentDate - lastGradeChangeDate.Value).TotalDays < 365)
            {
                throw new InvalidOperationException("Grade can only be changed once in a year.");
            }

            // Check if the user has completed 2 years before changing grade
            
        }
    }
}
