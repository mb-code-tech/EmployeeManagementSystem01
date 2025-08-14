using System;
using System.Collections.Generic;

namespace EmployeeManagementSystem
{
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }

        public void DisplayInfo()
        {
            Console.WriteLine($"ID: {Id} | Name: {Name} | Dept: {Department} | Salary: {Salary}");
        }
    }

    class Program
    {
        static List<Employee> employees = new List<Employee>();

        static void Main(string[] args)
        {
            int choice;

            do
            {
                Console.WriteLine("\n===== Employee Management System =====");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. View All Employees");
                Console.WriteLine("3. Search Employee by ID");
                Console.WriteLine("4. Update Employee");
                Console.WriteLine("5. Delete Employee");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        ViewEmployees();
                        break;
                    case 3:
                        SearchEmployee();
                        break;
                    case 4:
                        UpdateEmployee();
                        break;
                    case 5:
                        DeleteEmployee();
                        break;
                    case 6:
                        Console.WriteLine("Exiting... Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }

            } while (choice != 6);
        }

        static void AddEmployee()
        {
            Employee emp = new Employee();

            Console.Write("Enter Employee ID: ");
            emp.Id = int.Parse(Console.ReadLine());

            Console.Write("Enter Employee Name: ");
            emp.Name = Console.ReadLine();

            Console.Write("Enter Department: ");
            emp.Department = Console.ReadLine();

            Console.Write("Enter Salary: ");
            emp.Salary = double.Parse(Console.ReadLine());

            employees.Add(emp);
            Console.WriteLine("Employee Added Successfully!");
        }

        static void ViewEmployees()
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("No employees found.");
                return;
            }

            Console.WriteLine("\n--- Employee List ---");
            foreach (var emp in employees)
            {
                emp.DisplayInfo();
            }
        }

        static void SearchEmployee()
        {
            Console.Write("Enter Employee ID to search: ");
            int id = int.Parse(Console.ReadLine());

            var emp = employees.Find(e => e.Id == id);
            if (emp != null)
            {
                emp.DisplayInfo();
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        static void UpdateEmployee()
        {
            Console.Write("Enter Employee ID to update: ");
            int id = int.Parse(Console.ReadLine());

            var emp = employees.Find(e => e.Id == id);
            if (emp != null)
            {
                Console.Write("Enter New Name: ");
                emp.Name = Console.ReadLine();

                Console.Write("Enter New Department: ");
                emp.Department = Console.ReadLine();

                Console.Write("Enter New Salary: ");
                emp.Salary = double.Parse(Console.ReadLine());

                Console.WriteLine("Employee Updated Successfully!");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        static void DeleteEmployee()
        {
            Console.Write("Enter Employee ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            var emp = employees.Find(e => e.Id == id);
            if (emp != null)
            {
                employees.Remove(emp);
                Console.WriteLine("Employee Deleted Successfully!");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }
    }
}
