using System;
using System.Collections.Generic;
using System.IO;
using NVelocity;
using NVelocity.App;
using Sitecore.Diagnostics;
using Sitecore.Pipelines;
using Sitecore.XA.Foundation.Variants.Abstractions.Pipelines.GetVelocityTemplateRenderers;
using Sitecore.XA.Foundation.Variants.Abstractions.Services;

namespace Sitecore.Support.XA.Foundation.Variants.Abstractions.Services
{
  public class TemplateRenderer : ITemplateRenderer
  {
    private readonly VelocityContext _context;

    public TemplateRenderer()
    {
      Velocity.Init();
      var args = new GetTemplateRenderersPipelineArgs();
      CorePipeline.Run("getVelocityTemplateRenderers", args);
      _context = args.Context;
    }

    public virtual string ExecuteTemplate(string templateName, string template, Dictionary<string, object> parameters)
    {
      try
      {
        using (new LongRunningOperationWatcher(250, "Executing template {0}", templateName))
        {
          foreach (KeyValuePair<string, object> parameter in parameters)
          {
            _context.Put(parameter.Key, parameter.Value);
          }
          StringWriter output = new StringWriter();
          Velocity.Evaluate(_context, output, templateName, template);
          return output.GetStringBuilder().ToString();
        }
      }
      catch (Exception ex)
      {
        Log.Error($"Error while generatint NVelocity template: {template}", ex, this);
        if (Context.PageMode.IsExperienceEditorEditing)
        {
          return template;
        }
        return string.Empty;
      }
    }

    public virtual void AddParameters(Dictionary<string, object> parameters)
    {
      foreach (KeyValuePair<string, object> parameter in parameters)
      {
        _context.Put(parameter.Key, parameter.Value);
      }
    }

    public virtual void RemoveParameter(string paramKey)
    {
      _context.Remove(paramKey);
    }
  }
}