namespace MicroServices.Model
{
    public class Employee
    {
        public string EmployeeId { get; set; }
        public string Name { get; set; }
        public string Surname{ get; set; }
        public string Country { get; set; }


    }

    public class EmployeeCollection
    {
        public List<Employee> Employees { get; set;}

        public List<Employee> GetEmployees()
        {
            return new List<Employee>()
            {
                new Employee()
                {
                    EmployeeId = "2",
                    Name = "Ahmet",
                    Surname = "Cankal",
                    Country = "Turkey"
                },
                new Employee()
                {
                    EmployeeId = "3",
                    Name = "Mehmet",
                    Surname = "Selim",
                    Country = "Turkey"
                }
            };
        }
    }
}
