using Employees.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Employees.Application.Commands.Employees.DeleteEmployee;

public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, Unit>
{
    private readonly EmployeesDbContext _employeesDbContext;

    public DeleteEmployeeCommandHandler(EmployeesDbContext employeesDbContext)
    {
        _employeesDbContext = employeesDbContext;
    }
    public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employeeToDelete = await _employeesDbContext.Employees
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (employeeToDelete is null)
        {
            throw new Exception();
        }

        _employeesDbContext.Employees.Remove(employeeToDelete);
        await _employeesDbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}