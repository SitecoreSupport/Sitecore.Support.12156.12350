using Sitecore.Pipelines;
using Sitecore.Support.XA.Foundation.Variants.Abstractions.Services;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.Diagnostics;
using Sitecore.XA.Foundation.Variants.Abstractions.Services;

namespace Sitecore.Support.XA.Foundation.Variants.Abstractions.Pipelines.HttpRequestEnd
{
  public class RemoveTemplateRenderer
  {
    public void Process(PipelineArgs args)
    {
      var templateRendererEx =
        Sitecore.DependencyInjection.ServiceLocator.ServiceProvider.GetService<ITemplateRenderer>() as
          ITemplateRendererEx;
      Assert.IsNotNull(templateRendererEx, "Sitecore.Support.12145.12350: templateRendererEx is null");
      templateRendererEx.ClearContext();
    }
  }
}