using HumanResource.DAL.Interfaces;
using HumanResource.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.DAL.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private readonly EmployeeTravelDeskContext _context;

        public GradeRepository(EmployeeTravelDeskContext context)
        {
            _context = context;
        }

        public List<Grade> GetAllGrades()
        {
            return _context.Grades.ToList();
        }

        public Grade GetGradeById(int gradeId)
        {
            return _context.Grades.Find(gradeId);
        }
    }
}
