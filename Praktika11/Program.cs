using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika11
{
    public enum Vacancies
    {
        Manager,
        Developer,
        Designer,
    }

    public struct Employee
    {
        public string Name;
        public Vacancies Vacancy;
        public int[] HiringDate; 
        public int Salary;
    }

    class Program
    {
        static void Main()
        {
            Employee employee1;
            employee1.Name = "Саттар Бекнур";
            employee1.Vacancy = Vacancies.Manager;
            employee1.HiringDate = new int[] { 2020, 9, 1 };
            employee1.Salary = 36000;

            Console.WriteLine("Информация о сотруднике:");
            Console.WriteLine($"ФИО: {employee1.Name}");
            Console.WriteLine($"Должность: {employee1.Vacancy}");
            Console.WriteLine($"Дата принятие на работу: {employee1.HiringDate[0]}/{employee1.HiringDate[1]}/{employee1.HiringDate[2]}");
            Console.WriteLine($"Зарплата: {employee1.Salary}");

            Console.ReadKey();
        }
    }

}
