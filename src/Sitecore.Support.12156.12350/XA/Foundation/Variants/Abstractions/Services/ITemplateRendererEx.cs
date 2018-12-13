using Sitecore.XA.Foundation.Variants.Abstractions.Services;

namespace Sitecore.Support.XA.Foundation.Variants.Abstractions.Services
{
  public interface ITemplateRendererEx : ITemplateRenderer
  {
    void ClearContext();
  }
}