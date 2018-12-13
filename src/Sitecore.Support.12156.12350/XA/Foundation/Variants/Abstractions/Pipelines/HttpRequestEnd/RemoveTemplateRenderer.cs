using Sitecore.Pipelines;
using Sitecore.Support.XA.Foundation.Variants.Abstractions.Services;
using Sitecore.XA.Foundation.IoC;
using Sitecore.XA.Foundation.Variants.Abstractions.Services;

namespace Sitecore.Support.XA.Foundation.Variants.Abstractions.Pipelines.HttpRequestEnd
{
  public class RemoveTemplateRenderer
  {
    public void Process(PipelineArgs args)
    {
      (ServiceLocator.Current.Resolve<ITemplateRenderer>() as ITemplateRendererEx).ClearContext();
    }
  }
}