using HumanResource.DAL.Interfaces;
using HumanResource.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.DAL.Repositories
{
    public class GradeHistoryRepository : IGradeHistoryRepository
    {
        private readonly EmployeeTravelDeskContext _context;

        public GradeHistoryRepository(EmployeeTravelDeskContext context)
        {
            _context = context;
        }

        public List<GradesHistory> GetGradeHistoryByEmployeeId(int employeeId)
        {
            return _context.GradesHistories
               .Where(gh => gh.EmployeeId == employeeId)
            .ToList();
        }

        public void AddGradeHistory(GradesHistory gradeHistory)
        {
            _context.GradesHistories.Add(gradeHistory);
            _context.SaveChanges();
        }

        public DateTime? GetLastGradeChangeDate(int employeeId)
        {
            var lastGradeChangeDate = _context.GradesHistories
                .Where(gh => gh.EmployeeId == employeeId)
                .OrderByDescending(gh => gh.AssignedOn)
                .Select(gh => gh.AssignedOn)
                .FirstOrDefault();

            return lastGradeChangeDate;
        }
        public DateTime? GetOldestGradeChangeDate(int employeeId)
        {
            return _context.GradesHistories
                .Where(history => history.EmployeeId == employeeId)
                .OrderBy(history => history.AssignedOn)
                .Select(history => history.AssignedOn)
                .FirstOrDefault();
        }
    }
}
