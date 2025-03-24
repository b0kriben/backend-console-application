using ScholarshipApplicationProject.Console.DbModels;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScholarshipApplicationProject.Console.Repo
{
    public class ScholarshipRepo
    {
        private readonly ScholarshipContext _context = new();

        public int GetNumberOfScholarship()
        {
            return _context.Scholarships.Count();
        }
    }
}
