using Employees.Domain.Entities;
using Employees.Infrastructure;
using MediatR;

namespace Employees.Application.Commands.Employees.CreateEmployee;

public class CreateEmployeeCommandHandler: IRequestHandler<CreateEmployeeCommand, Guid>
{
    private readonly EmployeesDbContext _employeesDbContext;

    public CreateEmployeeCommandHandler(EmployeesDbContext employeesDbContext)
    {
        _employeesDbContext = employeesDbContext;
    }
    public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = new Employee
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            Position = request.Position,
            Departement = request.Departement,
            CreateDate = DateTime.Now.ToUniversalTime()

        };
        
        await _employeesDbContext.Employees.AddAsync(employee, cancellationToken);
         await _employeesDbContext.SaveChangesAsync(cancellationToken);
         
         

        return employee.Id;
    }
}