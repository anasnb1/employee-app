using MediatR;

namespace Employees.Application.Commands.Employees.DeleteEmployee;

public record DeleteEmployeeCommand(Guid Id): IRequest<Unit>;