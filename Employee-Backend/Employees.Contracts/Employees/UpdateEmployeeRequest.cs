namespace Employees.Contracts.Employees;

public record UpdateEmployeeRequest(
    Guid Id,
    String FirstName,
    String LastName,
    String Email,
    Double PhoneNumber,
    String Position,
    String Departement);