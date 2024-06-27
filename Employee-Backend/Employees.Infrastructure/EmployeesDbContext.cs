using Employees.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Employees.Infrastructure;

public class EmployeesDbContext : DbContext
{
    public EmployeesDbContext(DbContextOptions options) : base(options)
    {
        
    }
    public DbSet<Employee> Employees { get; set; }
}