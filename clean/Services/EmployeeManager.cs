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
        
        jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "employee.json");
        Console.WriteLine($"JSON File Path: {jsonFilePath}");
        LoadEmployeesFromJson();
        }

        private void LoadEmployeesFromJson()
        {
            try
            {
                
                string jsonEmployees = File.ReadAllText(jsonFilePath);

                
                employees = JsonSerializer.Deserialize<List<Employee>>(jsonEmployees);
            }
            catch (FileNotFoundException)
            {
                
                Console.WriteLine("The employees.json file is missing. Please create the file with employee data.");
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Error loading employees from JSON: {ex.Message}");
            }
        }

        public List<Employee> GetAllEmployees()
        {
            return employees;
        }

        public void AddEmployee(Employee employee)
        {
            
            employees.Add(employee);
            SaveEmployeesToJson();
        }

        private void SaveEmployeesToJson()
        {
            try
            {
                
                string jsonEmployees = JsonSerializer.Serialize(employees, new JsonSerializerOptions
                {
                    WriteIndented = true 
                });

                
                File.WriteAllText(jsonFilePath, jsonEmployees);
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Error saving employees to JSON: {ex.Message}");
            }
        }
    }
}
