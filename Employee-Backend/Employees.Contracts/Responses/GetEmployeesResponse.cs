using Employees.Contracts.Dtos;

namespace Employees.Contracts.Responses;

public record GetEmployeesResponse(List<EmployeeDto> EmployeeDtos);