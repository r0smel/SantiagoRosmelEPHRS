
using System;
using System.Collections.Generic;
using System.Linq;

public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Department { get; set; }
    public string JobTitle { get; set; }
    public decimal MonthlySalary { get; set; }
    public double TaxRate { get; set; }
    public DateTime HireDate { get; set; }
    public bool IsActive { get; set; }
    public string Email { get; set; }
}

class Program
{
    static List<Employee> employees = new List<Employee>();
    static int nextId = 1001;

    static void Main()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("=== EMPLOYEE HR SYSTEM - FEATURE BRANCH ===");
            Console.WriteLine("1. Create Employee");
            Console.WriteLine("2. Read Employees");
            Console.WriteLine("3. Search Employee");
            Console.WriteLine("4. Update Employee");
            Console.WriteLine("5. Delete Employee");
            Console.WriteLine("6. Exit");
            Console.Write("Select option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateEmployee(); break;
                case "2": ReadEmployees(); break;
                case "3": SearchEmployee(); break;
                case "4": UpdateEmployee(); break;
                case "5": DeleteEmployee(); break;
                case "6": running = false; break;
                default: Console.WriteLine("Invalid choice."); break;
            }

            if (running)
            {
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }
    }

    // CREATE
    static void CreateEmployee()
    {
        Employee emp = new Employee();

        emp.Id = nextId++;

        Console.Write("First Name: ");
        emp.FirstName = Console.ReadLine();

        Console.Write("Last Name: ");
        emp.LastName = Console.ReadLine();

        Console.Write("Department: ");
        emp.Department = Console.ReadLine();

        Console.Write("Job Title: ");
        emp.JobTitle = Console.ReadLine();

        Console.Write("Monthly Salary: ");
        decimal.TryParse(Console.ReadLine(), out decimal salary);
        emp.MonthlySalary = salary;

        Console.Write("Tax Rate (e.g. 0.12 for 12%): ");
        double.TryParse(Console.ReadLine(), out double tax);
        emp.TaxRate = tax;

        Console.Write("Hire Date (yyyy-MM-dd): ");
        DateTime.TryParse(Console.ReadLine(), out DateTime date);
        emp.HireDate = date;

        Console.Write("Is Active? (true/false): ");
        bool.TryParse(Console.ReadLine(), out bool active);
        emp.IsActive = active;

        Console.Write("Email: ");
        emp.Email = Console.ReadLine();

        employees.Add(emp);

        Console.WriteLine("\nEmployee created successfully! ID: " + emp.Id);
    }

    // READ
    static void ReadEmployees()
    {
        Console.WriteLine("\n--- EMPLOYEE RECORDS ---");

        if (employees.Count == 0)
        {
            Console.WriteLine("No employees found.");
            return;
        }

        foreach (Employee e in employees)
        {
            DisplayEmployee(e);
        }
    }

    // DISPLAY
    static void DisplayEmployee(Employee e)
    {
        Console.WriteLine("--------------------------------");
        Console.WriteLine($"ID: {e.Id}");
        Console.WriteLine($"Name: {e.FirstName} {e.LastName}");
        Console.WriteLine($"Department: {e.Department}");
        Console.WriteLine($"Job Title: {e.JobTitle}");
        Console.WriteLine($"Monthly Salary: {e.MonthlySalary:C}");
        Console.WriteLine($"Tax Rate: {e.TaxRate:P}");
        Console.WriteLine($"Hire Date: {e.HireDate:yyyy-MM-dd}");
        Console.WriteLine($"Active: {e.IsActive}");
        Console.WriteLine($"Email: {e.Email}");
    }

    // SEARCH / FILTER
    static void SearchEmployee()
    {
        Console.Write("Enter employee name or department: ");
        string keyword = Console.ReadLine();

        var results = employees.Where(e =>
            e.FirstName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
            e.LastName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
            e.Department.Contains(keyword, StringComparison.OrdinalIgnoreCase)
        ).ToList();

        if (results.Count == 0)
        {
            Console.WriteLine("No matching employees found.");
            return;
        }

        foreach (Employee e in results)
        {
            DisplayEmployee(e);
        }
    }

    // UPDATE
    static void UpdateEmployee()
    {
        Console.Write("Enter Employee ID: ");

        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        Employee emp = employees.FirstOrDefault(e => e.Id == id);

        if (emp == null)
        {
            Console.WriteLine("Employee not found.");
            return;
        }

        Console.Write("New First Name: ");
        emp.FirstName = Console.ReadLine();

        Console.Write("New Last Name: ");
        emp.LastName = Console.ReadLine();

        Console.Write("New Department: ");
        emp.Department = Console.ReadLine();

        Console.Write("New Job Title: ");
        emp.JobTitle = Console.ReadLine();

        Console.Write("New Monthly Salary: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal salary))
            emp.MonthlySalary = salary;

        Console.Write("New Tax Rate: ");
        if (double.TryParse(Console.ReadLine(), out double tax))
            emp.TaxRate = tax;

        Console.Write("New Hire Date (yyyy-MM-dd): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
            emp.HireDate = date;

        Console.Write("Is Active? (true/false): ");
        if (bool.TryParse(Console.ReadLine(), out bool active))
            emp.IsActive = active;

        Console.Write("New Email: ");
        emp.Email = Console.ReadLine();

        Console.WriteLine("Employee updated successfully!");
    }

    // DELETE
    static void DeleteEmployee()
    {
        Console.Write("Enter Employee ID: ");

        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        int removed = employees.RemoveAll(e => e.Id == id);

        if (removed > 0)
            Console.WriteLine("Employee deleted successfully!");
        else
            Console.WriteLine("Employee not found.");
    }
}
