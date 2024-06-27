using Employees.Application.Commands.Employees.CreateEmployee;
using Employees.Application.Commands.Employees.DeleteEmployee;
using Employees.Application.Commands.Employees.UpdateEmployee;
using Employees.Application.Queries.Employees.GetEmployeeById;
using Employees.Application.Queries.Employees.GetEmployees;
using Employees.Contracts.Employees;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace Employees.Presentaion.Modules;

public static class EmployeesModule
{
    public static void AddEmployeesEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/Employees", async (IMediator mediator, CancellationToken ct) =>
        {
            var employees = await mediator.Send(new GetEmployeesQuery(), ct);
            return Results.Ok(employees);
        }).WithTags("Employees");

        app.MapGet("/api/Employees/{id}", async (IMediator mediator, Guid id, CancellationToken ct) =>
        {
            var employees = await mediator.Send(new GetEmployeeByIdQuery(id), ct);
            return Results.Ok(employees);
        }).WithTags("Employees");

        app.MapPost("/api/Employees", async (IMediator mediator, CreateEmployeeRequest createEmployeeRequest,
            CancellationToken ct) =>
        {
            var command = new CreateEmployeeCommand(createEmployeeRequest.FirstName, createEmployeeRequest.LastName,
                createEmployeeRequest.Email, createEmployeeRequest.PhoneNumber, createEmployeeRequest.Position,
                createEmployeeRequest.Departement);
            var result = await mediator.Send(command, ct);
            return Results.Ok(result);
        }).WithTags("Employees");

        app.MapPut("/api/Employees/{id}", async (IMediator mediator, Guid id,
            UpdateEmployeeRequest updateEmployeeRequest, CancellationToken ct) =>
        {
            var command = new UpdateEmployeeCommand(id, updateEmployeeRequest.FirstName, updateEmployeeRequest.LastName,
                updateEmployeeRequest.Email, updateEmployeeRequest.PhoneNumber, updateEmployeeRequest.Position,
                updateEmployeeRequest.Departement);
            var result = await mediator.Send(command, ct);
            return Results.Ok(result);
        }).WithTags("Employees");

        app.MapDelete("/api/Employees/{id}", async (IMediator mediator, Guid id, CancellationToken ct) =>
        {
            var command = new DeleteEmployeeCommand(id);
            var result = await mediator.Send(command, ct);
            return Results.Ok(result);
        }).WithTags("Employees");

    }

}