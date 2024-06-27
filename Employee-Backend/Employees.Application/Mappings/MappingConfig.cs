using Employees.Contracts.Responses;
using Employees.Domain.Entities;
using Mapster;

namespace Employees.Application.Mappings;

public class MappingConfig
{
    public static void Configure()
    {
        TypeAdapterConfig<List<Employee>, GetEmployeesResponse>.NewConfig()
            .Map(dest => dest.EmployeeDtos, src => src);

        TypeAdapterConfig<Employee, GetEmployeeByIdResponse>.NewConfig()
            .Map(dest => dest.EmployeeDto, src => src);
    }
}