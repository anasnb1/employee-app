using MediatR;

namespace Employees.Application.Commands.Employees.CreateEmployee;

public record CreateEmployeeCommand(
    String FirstName,
    String LastName,
    String Email,
    Double PhoneNumber,
    String Position,
    String Departement) :
    IRequest<Guid>;
