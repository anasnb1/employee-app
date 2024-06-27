using Employees.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Employees.Application.Commands.Employees.UpdateEmployee;

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Unit>
{
    private readonly EmployeesDbContext _employeesDbContext;

    public UpdateEmployeeCommandHandler(EmployeesDbContext employeesDbContext)
    {
        _employeesDbContext = employeesDbContext;
    }
    public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employeeToUpdate = await _employeesDbContext.Employees
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (employeeToUpdate is null)
        {
            throw new Exception();
        }

        employeeToUpdate.FirstName = request.FirstName;
        employeeToUpdate.LastName = request.LastName;
        employeeToUpdate.PhoneNumber = request.PhoneNumber;
        employeeToUpdate.Email = request.Email;
        employeeToUpdate.Position = request.Position;
        employeeToUpdate.Departement = request.Departement;

        _employeesDbContext.Employees.Update(employeeToUpdate);
        await _employeesDbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}