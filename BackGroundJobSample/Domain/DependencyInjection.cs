using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Domain;

public static class DependencyInjection
{
    public static void AddDomain(this IServiceCollection services)
    {
        services.AddDbContext<DatabaseContext>
        (
            options => options.UseSqlServer("yourConnectionString")
        );
    }
}