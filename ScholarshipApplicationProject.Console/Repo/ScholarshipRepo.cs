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
        public string ListAllScholarships()
        {
            var applicants = _context.Scholarships.ToList();
            /*if (applicants.Count == 0)
            {
                return "Nincs adat az adatbázisban.";
            }*/

            string result = "";
            foreach (var applicant in applicants)
            {
                result += $"{applicant.Name} ({applicant.Email}) {applicant.Amount} Ft\n";
            }
            return result;
        }


        //2. feladat: Meghatározott összeg feletti ösztöndíjasok listázása
        public string ListScholarshipsAboveAmount(int minimumAmount)
        {
            var applicants = _context.Scholarships
                .Where(s => s.Amount > minimumAmount)
                .ToList();

            string result = "";
            foreach (var applicant in applicants)
            {
                result += $"{applicant.Name} ({applicant.Email}) {applicant.Amount} Ft\n";
            }
            return result;
        }



        //3. feladat: Az ösztöndíjasok rendezése összeg szerint csökkenő
        public string ListScholarshipsSortedByAmountDescending()
        {
            var applicants = _context.Scholarships
                .OrderByDescending(s => s.Amount)
                .ToList();

            string result = "";
            foreach (var applicant in applicants)
            {
                result += $"{applicant.Name} ({applicant.Email}) {applicant.Amount} Ft\n";
            }
            return result;
        }


        //4. feladat: Új ösztöndíjas hozzáadása az adatbázishoz
        /*public string AddScholarship(string email, string name, int amount)
        {
            var newApplicant = new ScholarshipApplication
            {
                Email = email,
                Name = name,
                Amount = amount
            };

            _context.Scholarships.Add(newApplicant);
            _context.SaveChanges();

            return "Új ösztöndíjas sikeresen hozzáadva.";
        }


        //5. feladat: Egy adott diák ösztöndíjának módosítása
        public string UpdateScholarshipAmount(string email, int newAmount)
        {
            var applicant = _context.Scholarships
                .FirstOrDefault(s => s.Email == email);

            if (applicant != null)
            {
                applicant.Amount = newAmount;
                _context.SaveChanges();
                return "Az ösztöndíj összegét sikeresen módosítottuk.";
            }
            return "Nincs ilyen diák az adatbázisban.";
        }


        //6. feladat: Egy adott diák törlése az adatbázisból
        public string DeleteScholarshipByEmail(string email)
        {
            var applicant = _context.Scholarships
                .FirstOrDefault(s => s.Email == email);

            if (applicant != null)
            {
                _context.Scholarships.Remove(applicant);
                _context.SaveChanges();
                return "A diák ösztöndíját sikeresen töröltük.";
            }
            return "Nincs ilyen diák az adatbázisban.";
        }*/

        //7. feladat: Az összes ösztöndíj összege és az átlagos ösztöndíj kiszámítása
        public string CalculateTotalAndAverageScholarships()
        {
            var totalAmount = _context.Scholarships.Sum(s => s.Amount);
            var averageAmount = _context.Scholarships.Average(s => s.Amount);

            return $"Összes kiosztott ösztöndíj: {totalAmount} Ft \nÁtlagos ösztöndíj: {averageAmount} Ft";
        }


        //8. feladat: Ösztöndíjasok csoportosítása összeg szerint
        public string GroupScholarshipsByAmount()
        {
            var below1500 = _context.Scholarships.Count(s => s.Amount < 1500);
            var between1500And2000 = _context.Scholarships.Count(s => s.Amount >= 1500 && s.Amount <= 2000);
            var above2000 = _context.Scholarships.Count(s => s.Amount > 2000);

            return $"Ösztöndíjasok csoportosítása összeg szerint: \n 1500 Ft alatti: {below1500} fő \n 1500 - 2000 Ft között: {between1500And2000} fő \n 2000 Ft feletti: {above2000} fő";
        }


        //9. feladat: Ösztöndíjasok listázása bizonyos feltételek alapján
        public string ListScholarshipsWithConditions()
        {
            var applicants = _context.Scholarships
                .Where(s => s.Amount >= 1800 && s.Email.Contains("example.com"))
                .ToList();

            string result = "";
            foreach (var applicant in applicants)
            {
                result += $"{applicant.Name} ({applicant.Email}) {applicant.Amount} Ft\n";
            }
            return result;
        }


        //10. feladat: Ösztöndíjasok listázása más feltételek alapján
        public string ListScholarshipsWithAlternateConditions()
        {
            var applicants = _context.Scholarships
                .Where(s => s.Amount > 2000 || s.Email == "alice@example.com")
                .ToList();

            string result = "";
            foreach (var applicant in applicants)
            {
                result += $"{applicant.Name} ({applicant.Email}) {applicant.Amount} Ft\n";
            }
            return result;
        }

    }
}
