using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;

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
            Employee? foundEmp = _context.Employees.Find(newEmployee.EmployeeId);
            if(foundEmp != null) {
                throw new Exception("failed to add employeee");
            }
            EntityState es = _context.Entry(newEmployee).State;
            Console.WriteLine($"EntityState B4Add:{es.GetDisplayName()}");
            _context.Employees.Add(newEmployee);
            es = _context.Entry(newEmployee).State;
            Console.WriteLine($"EntityState After Add:{es.GetDisplayName()} ");
            int result= _context.SaveChanges();
            es = _context.Entry(newEmployee).State;
            Console.WriteLine($"EntityState After savechange:{es.GetDisplayName()} ");
            return result;
        }

        //public Employee UpdateEmployee(Employee updatedEmployee)
        //{
        //    _context.Employees.Update(updatedEmployee);
        //    // Console.WriteLine(_context.Entry(updatedEmployee).State); // sir,i will do it , thankyou sir
        //    _context.SaveChanges();
        //    return updatedEmployee;
        //}
        public int UpdateEmployee(Employee modifiedEmployee)
        {
            EntityState es = _context.Entry(modifiedEmployee).State;
            Console.WriteLine($"EntityState B4update:{es.GetDisplayName()}");
            _context.Employees.Update(modifiedEmployee);
            es = _context.Entry(modifiedEmployee).State;
            Console.WriteLine($"EntityState After update:{es.GetDisplayName()} ");
            int result = _context.SaveChanges();
            es = _context.Entry(modifiedEmployee).State;
            Console.WriteLine($"EntityState After savechange:{es.GetDisplayName()} ");
            return result;
        }
        public int DeleteEmployee(int id)
        {
            Employee empToDelete = _context.Employees.Find(id);
            EntityState es = EntityState.Detached;
            int result = 0;
            if (empToDelete != null)
            {
                es = _context.Entry(empToDelete).State;
                Console.WriteLine($"EntityState b4update:{es.GetDisplayName()}");
                _context.Employees.Remove(empToDelete);
                es = _context.Entry(empToDelete).State;
                Console.WriteLine($"EntityState after update:{es.GetDisplayName()}");
                result = _context.SaveChanges();
                es = _context.Entry(empToDelete).State;
                Console.WriteLine($"EntityState after saved update:{es.GetDisplayName()}");





            }
            return result;




        }
    }
}


