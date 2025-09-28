using Microsoft.AspNetCore.Mvc;

//Repository Example
//Advantage code in the EmployeeRepository can be replced by any other EF or Dapper without touching anywhere
public class Employee{
 public int Id { get; set; }
 public string Name { get; set; }

}
interface IEmployeeRepository
{
    public Employee GetAllEmployee();
}
public class EmployeeRepository: IEmployeeRepository
{
    // private readonly AppDbContext _context;
    // public EmployeeRepository(AppDbContext context)
    // {
    //     _context = context;
    // }
    public Employee GetAllEmployee(){
        //_context.Employee.ToList();
    }
}
//***************Services Folder*******************
interface EmployeeServices
{
    public Employee GetEmployees();
}
public class EmployeeServices :IEmployeeServices
{
    public EmployeeRepository _empRepositoty;
    public Employee GetEmployees(){

        _empRepositoty.GetAllEmployee();
    }
}
//******************* Controller Folder*************
public class EmployeeController:ControllerBase
{

    private readonly IEmployeeService _service;

    public EmployeeController(IEmployeeService service)
    {
        _service = service;
    }

    public void ShowAllEmployees()
    {
        var employees = _service.GetEmployees();
        
    }
}



