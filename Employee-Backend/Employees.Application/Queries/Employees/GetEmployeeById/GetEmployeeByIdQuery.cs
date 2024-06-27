using Employees.Contracts.Responses;
using MediatR;

namespace Employees.Application.Queries.Employees.GetEmployeeById;

public record GetEmployeeByIdQuery(Guid Id) : IRequest<GetEmployeeByIdResponse>;