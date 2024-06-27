using Employees.Contracts.Responses;
using Employees.Infrastructure;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Employees.Application.Queries.Employees.GetEmployeeById;

public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, GetEmployeeByIdResponse>
{
    private readonly EmployeesDbContext _employeesDbContext;

    public GetEmployeeByIdQueryHandler(EmployeesDbContext employeesDbContext)
    {
        _employeesDbContext = employeesDbContext;
    }
    public async Task<GetEmployeeByIdResponse> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        var employee = await _employeesDbContext.Employees
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (employee is null)
        {
            throw new Exception();
        }

        return employee.Adapt<GetEmployeeByIdResponse>();
    }
}