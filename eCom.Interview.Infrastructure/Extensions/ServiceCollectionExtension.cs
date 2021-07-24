using eCom.Interview.Application.Repository;
using eCom.Interview.Domain.Models;
using eCom.Interview.Infrastructure.Repository;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddEcomInterviewServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddTransient<IRepository<EmailTemplate>>(e => new EmailTemplateXmlFileRepository(Configuration["ConnectionString:XMLDataPath"]));
            return services;
        }
    }
}
