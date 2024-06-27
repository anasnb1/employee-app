namespace Employees.Domain.Entities;

public class Employee : BaseEntity
{
    public String FirstName { get; set; }
    public String LastName { get; set; }
    public String Email { get; set; }
    public Double PhoneNumber { get; set; }
    public String Position { get; set; }
    public String Departement { get; set; }

    
}