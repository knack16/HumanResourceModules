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
    public class GradeService : IGradeService
    {
        private readonly IGradeRepository _gradeRepository;

        public GradeService(IGradeRepository gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }

        public List<Grade> GetAllGrades()
        {
            return _gradeRepository.GetAllGrades();
        }
    }
}
