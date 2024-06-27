namespace Employees.Contracts.Dtos;

public class EmployeeDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public String FirstName { get; set; }
    public String LastName { get; set; }
    public String Email { get; set; }
    public Double PhoneNumber { get; set; }
    public String Position { get; set; }
    public String Departement { get; set; }
    public DateTime CreateDate { get; set; }
};
