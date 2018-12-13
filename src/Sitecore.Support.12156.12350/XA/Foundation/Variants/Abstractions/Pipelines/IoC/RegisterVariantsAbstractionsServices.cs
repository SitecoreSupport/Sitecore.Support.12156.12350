using Microsoft.Extensions.DependencyInjection;
using Sitecore.Support.XA.Foundation.Variants.Abstractions.Services;
using Sitecore.XA.Foundation.IOC.Pipelines.IOC;
using Sitecore.XA.Foundation.Variants.Abstractions.Services;

namespace Sitecore.Support.XA.Foundation.Variants.Abstractions.Pipelines.IoC
{
  public class RegisterVariantsAbstractionsServices : IocProcessor
  {
    public override void Process(IocArgs args)
    {
      args.ServiceCollection.Remove(new ServiceDescriptor(typeof(ITemplateRenderer), typeof(TemplateRenderer),
        ServiceLifetime.Singleton));
      args.ServiceCollection.AddScoped<ITemplateRenderer, TemplateRendererEx>();
    }
  }
}