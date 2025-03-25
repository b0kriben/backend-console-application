using ScholarshipApplicationProject.Console.DbModels;
using ScholarshipApplicationProject.Console.Models;
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

        //1. feladat: Az összes ösztöndíjas listázása
        public List<ScholarshipApplicant> ListAllScholarships()
        {
            return ($"{s => s.Name} ({s => s.Email}) {s => s.Amount} Ft");
        }
        /*public string ListAllScholarships()
        {
            var scholarships = _context.Scholarships.ToList();

            foreach (var scholarship in scholarships)
            {
                return ($"{scholarship.Name} ({scholarship.Email}) {scholarship.Amount} Ft");
            }
        }*/
    }
}
