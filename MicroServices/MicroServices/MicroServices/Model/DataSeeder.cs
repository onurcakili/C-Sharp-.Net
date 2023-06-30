using System.Collections.Generic;
using System.Linq;

namespace MicroServices.Model
{
    public class DataSeeder
    {
        private readonly EmployeeDbContext employeeDbContext;

        public DataSeeder(EmployeeDbContext employeeDbContext)
        {
            this.employeeDbContext = employeeDbContext;
        }

        public void Seed()
        {
            if(!employeeDbContext.Employee.Any())
            {
                var employees = new List<Employee>()
                {
                        new Employee()
                        {
                            Name = "Onur",
                            Surname = "Cakili",
                            Country = "Turkey",
                            EmployeeId = 1
                        },
                        new Employee()
                        {
                            Name = "Ahmet",
                            Surname = "Cankal",
                            Country = "Turkey",
                            EmployeeId = 2
                        },
                        new Employee()
                        {
                            Name = "Murat",
                            Surname = "Serhat",
                            Country = "Turkey",
                            EmployeeId = 3
                        },
                        new Employee()
                        {
                            Name = "Kazım",
                            Surname = "Cakili",
                            Country = "Turkey",
                            EmployeeId = 4
                        },
                        new Employee()
                        {
                            Name = "Okan",
                            Surname = "Mert",
                            Country = "Turkey",
                            EmployeeId = 5
                        }
                };

                employeeDbContext.Employee.AddRange(employees);
                employeeDbContext.SaveChanges();
            }
        }
    }
}
