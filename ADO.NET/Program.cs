﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome");

            EmployeeRepo repo = new EmployeeRepo();
            try
            {
                Console.WriteLine("Choose option or press 0 for exit\n1:Retrieve Data\n2:Add Data\n3:Update Basic_Salary\n4:Delete Data\n5:Retrive employee with date Range");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        repo.GetAllEmployees();
                        break;
                    case 2:
                        EmployeeModel model = new EmployeeModel
                        {
                            Name = "Jai Kumar",
                            Startdate = DateTime.Now,
                            Gender = 'M',
                            Phone = 9876453215,
                            Department = "Testing",
                            Address = "Banglore",
                            Basic_Pay = 30000.00,
                            Deductions = 1000.00,
                            Taxable_Pay = 29000.00,
                            Income_Tax = 1000.00,
                            Net_Pay = 28000,
                        };
                        repo.AddEmployee(model);
                        break;
                    case 3:
                        EmployeeModel model1 = new EmployeeModel();
                        Console.WriteLine("Enter id of employee whose data you want to update");
                        model1.Id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter name");
                        model1.Name = Console.ReadLine();
                        Console.WriteLine("Enter new BasicPay");
                        model1.Basic_Pay = Convert.ToDouble(Console.ReadLine());
                        repo.UpdateEmployee(model1);
                        break;
                    case 4:
                        EmployeeModel model2 = new EmployeeModel();
                        Console.WriteLine("Enter id of employee whose data you want to delete");
                        model2.Id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter name");
                        model2.Name = Console.ReadLine();
                        repo.DeleteEmployee(model2);
                        break;

                    case 5:
                        string query = "select * from employee_payroll where StartDate between cast ('2018-01-01' as date) and GETDATE()";
                        repo.GetEmployeesWithDataAdapter(query);
                        break;

                }
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}