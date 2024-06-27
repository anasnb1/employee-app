using MediatR;

namespace Employees.Application.Commands.Employees.UpdateEmployee;

public record UpdateEmployeeCommand(
    Guid Id,
    String FirstName,
    String LastName,
    String Email,
    Double PhoneNumber,
    String Position,
    String Departement): IRequest<Unit>;