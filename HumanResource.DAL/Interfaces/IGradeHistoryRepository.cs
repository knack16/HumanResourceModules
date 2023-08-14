using HumanResource.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.DAL.Interfaces
{
    public interface IGradeHistoryRepository
    {
        List<GradesHistory> GetGradeHistoryByEmployeeId(int employeeId);
        void AddGradeHistory(GradesHistory gradeHistory);

        public DateTime? GetLastGradeChangeDate(int employeeId);

        public DateTime? GetOldestGradeChangeDate(int employeeId);
    }
}
