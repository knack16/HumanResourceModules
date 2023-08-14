using HumanResource.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.DAL.Interfaces
{
    public interface IGradeRepository
    {
        List<Grade> GetAllGrades();
        Grade GetGradeById(int gradeId);
    }
}
