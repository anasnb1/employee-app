using Employees.Contracts.Responses;
using Employees.Infrastructure;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Employees.Application.Queries.Employees.GetEmployees;

public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, GetEmployeesResponse>
{
    private readonly EmployeesDbContext _employeesDbContext;

    public GetEmployeesQueryHandler(EmployeesDbContext employeesDbContext)
    {
        _employeesDbContext = employeesDbContext;
    }
    public async Task<GetEmployeesResponse> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    {
        var employees = await _employeesDbContext.Employees.ToListAsync(cancellationToken);

        return employees.Adapt<GetEmployeesResponse>();
    }
}