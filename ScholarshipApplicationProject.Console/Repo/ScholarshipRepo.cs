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
        public void ListAllScholarships()
        {
            var applicants = _context.Scholarships.ToList();
            foreach (var applicant in applicants)
            {
                Console.WriteLine($"{applicant.Name} ({applicant.Email}) {applicant.Amount} Ft");
            }
        }

        //2. feladat: Meghatározott összeg feletti ösztöndíjasok listázása
        public void ListScholarshipsAboveAmount(int minimumAmount)
        {
            var applicants = _context.Scholarships
                .Where(s => s.Amount > minimumAmount)
                .ToList();

            foreach (var applicant in applicants)
            {
                Console.WriteLine($"{applicant.Name} ({applicant.Email}) {applicant.Amount} Ft");
            }
        }

        //3. feladat: Az ösztöndíjasok rendezése összeg szerint csökkenő
        public void ListScholarshipsSortedByAmountDescending()
        {
            var applicants = _context.Scholarships
                .OrderByDescending(s => s.Amount)
                .ToList();

            foreach (var applicant in applicants)
            {
                Console.WriteLine($"{applicant.Name} ({applicant.Email}) {applicant.Amount} Ft");
            }
        }

        //4. feladat: Új ösztöndíjas hozzáadása az adatbázishoz
        public void AddScholarship(string email, string name, int amount)
        {
            var newApplicant = new ScholarshipApplication
            {
                Email = email,
                Name = name,
                Amount = amount
            };

            _context.Scholarships.Add(newApplicant);
            _context.SaveChanges();
        }

        //5. feladat: Egy adott diák ösztöndíjának módosítása
        public void UpdateScholarshipAmount(string email, int newAmount)
        {
            var applicant = _context.Scholarships
                .FirstOrDefault(s => s.Email == email);

            if (applicant != null)
            {
                applicant.Amount = newAmount;
                _context.SaveChanges();
            }
        }

        //6. feladat: Egy adott diák törlése az adatbázisból
        public void DeleteScholarshipByEmail(string email)
        {
            var applicant = _context.Scholarships
                .FirstOrDefault(s => s.Email == email);

            if (applicant != null)
            {
                _context.Scholarships.Remove(applicant);
                _context.SaveChanges();
            }
        }

        //7. feladat: Az összes ösztöndíj összege és az átlagos ösztöndíj kiszámítása
        public void CalculateTotalAndAverageScholarships()
        {
            var totalAmount = _context.Scholarships.Sum(s => s.Amount);
            var averageAmount = _context.Scholarships.Average(s => s.Amount);

            Console.WriteLine($"Összes kiosztott ösztöndíj: {totalAmount} Ft");
            Console.WriteLine($"Átlagos ösztöndíj: {averageAmount} Ft");
        }

        //8. feladat: Ösztöndíjasok csoportosítása összeg szerint
        public void GroupScholarshipsByAmount()
        {
            var below1500 = _context.Scholarships.Count(s => s.Amount < 1500);
            var between1500And2000 = _context.Scholarships.Count(s => s.Amount >= 1500 && s.Amount <= 2000);
            var above2000 = _context.Scholarships.Count(s => s.Amount > 2000);

            Console.WriteLine("Ösztöndíjasok csoportosítása összeg szerint:");
            Console.WriteLine($"1500 Ft alatti: {below1500} fő");
            Console.WriteLine($"1500 - 2000 Ft között: {between1500And2000} fő");
            Console.WriteLine($"2000 Ft feletti: {above2000} fő");
        }


        //9. feladat: Ösztöndíjasok listázása bizonyos feltételek alapján
        public void ListScholarshipsWithConditions()
        {
            var applicants = _context.Scholarships
                .Where(s => s.Amount >= 1800 && s.Email.Contains("example.com"))
                .ToList();

            foreach (var applicant in applicants)
            {
                Console.WriteLine($"{applicant.Name} ({applicant.Email}) {applicant.Amount} Ft");
            }
        }

        //10. feladat: Ösztöndíjasok listázása más feltételek alapján
        public void ListScholarshipsWithAlternateConditions()
        {
            var applicants = _context.Scholarships
                .Where(s => s.Amount > 2000 || s.Email == "alice@example.com")
                .ToList();

            foreach (var applicant in applicants)
            {
                Console.WriteLine($"{applicant.Name} ({applicant.Email}) {applicant.Amount} Ft");
            }
        }

    }
}
