using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateProjectOne.Application.Services.Product.Product.Query.GetDetailProductForSite;
using TemplateProjectOne.Application.Services.Product.Product.Query.GetProductForSite;

namespace TemplateProjectOne.Application.Interfaces.FacadPattern
{
    public interface IProductForSiteFacadPattern
    {
        GetProductForSiteServices GetProductForSiteServices { get; }
        GetDetailProductForSiteServices GetDetailProductForSiteServices { get; }
    }
}
