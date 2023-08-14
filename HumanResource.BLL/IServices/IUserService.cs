using HumanResource.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.BLL.IServices
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        User GetUserById(int employeeId);
        void AddUser(User user);
        void DeleteUser(int employeeId);
        void UpdateUserGrade(int employeeId, int newGradeId);
    }
}
