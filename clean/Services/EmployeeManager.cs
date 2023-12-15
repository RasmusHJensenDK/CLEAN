using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using clean.Models;

namespace clean.Services
{
    public class EmployeeManager
    {
        private List<Employee> employees;
        private readonly string jsonFilePath;

        public EmployeeManager()
        {
        employees = new List<Employee>();
        // Set the path to the employees.json file based on the application's working directory
        jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "employee.json");
        Console.WriteLine($"JSON File Path: {jsonFilePath}");
        LoadEmployeesFromJson();
        }

        private void LoadEmployeesFromJson()
        {
            try
            {
                // Read JSON from the file
                string jsonEmployees = File.ReadAllText(jsonFilePath);

                // Deserialize JSON to List<Employee>
                employees = JsonSerializer.Deserialize<List<Employee>>(jsonEmployees);
            }
            catch (FileNotFoundException)
            {
                // Handle the case where the file doesn't exist
                Console.WriteLine("The employees.json file is missing. Please create the file with employee data.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (print to console, log, or show an error message)
                Console.WriteLine($"Error loading employees from JSON: {ex.Message}");
            }
        }

        public List<Employee> GetAllEmployees()
        {
            return employees;
        }

        public void AddEmployee(Employee employee)
        {
            // Add validation logic if needed
            employees.Add(employee);
            SaveEmployeesToJson();
        }

        private void SaveEmployeesToJson()
        {
            try
            {
                // Serialize the employees list to JSON
                string jsonEmployees = JsonSerializer.Serialize(employees, new JsonSerializerOptions
                {
                    WriteIndented = true // Makes the JSON readable with indentation
                });

                // Write the JSON to the employees.json file
                File.WriteAllText(jsonFilePath, jsonEmployees);
            }
            catch (Exception ex)
            {
                // Handle exceptions (print to console, log, or show an error message)
                Console.WriteLine($"Error saving employees to JSON: {ex.Message}");
            }
        }
    }
}
