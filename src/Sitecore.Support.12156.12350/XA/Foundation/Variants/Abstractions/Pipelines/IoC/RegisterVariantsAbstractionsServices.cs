using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using Sitecore.Support.XA.Foundation.Variants.Abstractions.Services;
using Sitecore.XA.Foundation.Variants.Abstractions.Services;

namespace Sitecore.Support.XA.Foundation.Variants.Abstractions.Pipelines.IoC
{
  public class RegisterVariantsAbstractionsServices : IServicesConfigurator
  {
    public void Configure(IServiceCollection serviceCollection)
    {
      serviceCollection.Remove(new ServiceDescriptor(typeof(ITemplateRenderer), typeof(TemplateRenderer),
        ServiceLifetime.Singleton));
      serviceCollection.AddScoped<ITemplateRenderer, TemplateRendererEx>();
    }
  }
}