namespace Employees.Contracts.Employees;

public record CreateEmployeeRequest(
    String FirstName,
    String LastName,
    String Email,
    Double PhoneNumber,
    String Position,
    String Departement);