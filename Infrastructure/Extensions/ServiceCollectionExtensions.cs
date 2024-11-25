using Application.Services;
using Core.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			services.AddScoped<IUserRepositories, UserRepository>();
			services.AddScoped<IMoneyTransferRepositories, MoneyTransferRepository>();
			services.AddScoped<UserServices>();
			services.AddScoped<ExchangeRateService>();
			services.AddScoped<MoneyTransferService>();
			return services;
		}
	}
}
