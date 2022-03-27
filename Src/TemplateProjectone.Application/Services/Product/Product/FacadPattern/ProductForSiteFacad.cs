using TemplateProjectOne.Application.Interfaces.Contextes;
using TemplateProjectOne.Application.Interfaces.FacadPattern;
using TemplateProjectOne.Application.Services.Product.Product.Query.GetDetailProductForSite;
using TemplateProjectOne.Application.Services.Product.Product.Query.GetProductForSite;

namespace TemplateProjectOne.Application.Services.Product.Product.FacadPattern
{
    public class ProductForSiteFacad : IProductForSiteFacadPattern
    {
        private readonly IDataBaseContext _context;
        public ProductForSiteFacad(IDataBaseContext context)
        {
            _context = context;
        }



        private GetProductForSiteServices _getProductForSiteServices;
        public GetProductForSiteServices GetProductForSiteServices
        {
            get
            {
                return _getProductForSiteServices = _getProductForSiteServices ?? new GetProductForSiteServices(_context);
            }
        }

        private GetDetailProductForSiteServices _getDetailProductForSiteServices;
        public GetDetailProductForSiteServices GetDetailProductForSiteServices
        {
            get
            {
                return _getDetailProductForSiteServices = _getDetailProductForSiteServices ?? new GetDetailProductForSiteServices(_context);
            }
        }
    }
}
