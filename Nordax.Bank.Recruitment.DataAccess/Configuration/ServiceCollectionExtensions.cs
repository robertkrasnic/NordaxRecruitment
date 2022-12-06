using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nordax.Bank.Recruitment.DataAccess.Factories;
using Nordax.Bank.Recruitment.DataAccess.Repositories;
using Nordax.Bank.Recruitment.DataAccess.WorkUnits;

namespace Nordax.Bank.Recruitment.DataAccess.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static void AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        public static void AddDataAccessServices(this IServiceCollection services)
        {
            services.AddRepositories();
            services.AddUnitsOfWork();
            services.AddFactories();
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ISubscriptionRepository, SubscriptionRepository>();
        }

        private static void AddUnitsOfWork(this IServiceCollection services)
        {
            services.AddTransient<ILoanApplicationWorkUnit, LoanApplicationWorkUnit>();
        }

        private static void AddFactories(this IServiceCollection services)
        {
            services.AddTransient<IDbContextFactory, DbContextFactory>();
        }
    }
}