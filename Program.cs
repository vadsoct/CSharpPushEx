using System;
using System.Globalization;
using Contratos.Entities.Enums;
using Contratos.Entities;

namespace contratos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter departament's name: ");
            string deptName = Console.ReadLine();
            Console.WriteLine("Enter worker data: ");
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            System.Console.WriteLine("Base Salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Departament dept = new Departament(deptName);
            Worker worker = new Worker(name, level, baseSalary, dept);

            System.Console.WriteLine("How many contracts for this worker? ");
            int n = int.Parse(Console.ReadLine());

            for(int i = 0; i <= n; i++)
            {
                System.Console.WriteLine($"Enter #{i} contract data:");
                System.Console.WriteLine("Date(DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                System.Console.WriteLine("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
                System.Console.WriteLine("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, valuePerHour, hours);
                worker.AddContract(contract);
            }
            System.Console.WriteLine();
            System.Console.WriteLine("Enter month and year to calculaate income (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0,2));
            int year = int.Parse(monthAndYear.Substring(3));
            System.Console.WriteLine("Name: " + worker.Name);
            System.Console.WriteLine("Departament: " + worker.Departament.Name);
            System.Console.WriteLine("Income for " + monthAndYear + ": " + worker.Income(year,month).ToString("F2",CultureInfo.InvariantCulture));
        }
    }
}
