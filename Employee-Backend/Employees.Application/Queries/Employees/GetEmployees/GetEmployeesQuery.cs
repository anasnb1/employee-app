using Employees.Contracts.Responses;
using MediatR;

namespace Employees.Application.Queries.Employees.GetEmployees;

public record GetEmployeesQuery(): IRequest<GetEmployeesResponse>;