using HumanResource.DAL.Interfaces;
using HumanResource.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EmployeeTravelDeskContext _context;

        public UserRepository(EmployeeTravelDeskContext context)
        {
            _context = context;
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int employeeId)
        {
            return _context.Users.FirstOrDefault(u => u.EmployeeId == employeeId);
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUserGrade(int employeeId, int newGradeId)
        {
            var user = _context.Users.FirstOrDefault(u => u.EmployeeId == employeeId);
            if (user != null)
            {
                user.CurrentGradeId = newGradeId;
                _context.SaveChanges();
            }
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
