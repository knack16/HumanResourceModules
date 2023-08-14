using HumanResource.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.DAL.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User GetUserById(int employeeId);
        void AddUser(User user);
        void UpdateUserGrade(int employeeId, int newGradeId);
        void DeleteUser(User user);
    }
}
