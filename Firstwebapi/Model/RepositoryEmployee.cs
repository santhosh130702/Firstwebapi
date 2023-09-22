namespace Firstwebapi.Model
{
    public class RepositoryEmployee
    {
        private NorthwindContext _context;
        public RepositoryEmployee(NorthwindContext context)
        {
            _context = context;
        }
        public List<Employee> AllEmployees()
        {
            return _context.Employees.ToList();
        }
        public Employee FindEmployeeById(int id)
        {
            Employee employeeId = _context.Employees.Find(id);
            return employeeId;
        }
        public int AddEmployee(Employee newEmployee)
        {
            _context.Employees.Add(newEmployee);
            return _context.SaveChanges();
        }

        public Employee UpdateEmployee(Employee updatedEmployee)
        {
            _context.Employees.Update(updatedEmployee);
            // Console.WriteLine(_context.Entry(updatedEmployee).State); // sir,i will do it , thankyou sir
            _context.SaveChanges();
            return updatedEmployee;
        }
        public int DeleteEmployee(int id)
        {
            Employee emp = _context.Employees.Find(id);
            _context.Employees.Remove(emp);
            return _context.SaveChanges();
        }
    }
}


