using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateProjectOne.Domain.Entities.Common;

namespace TemplateProjectOne.Domain.Entities.Product.HomePages.HomePageImages
{
    public class HomePageImages:BaseEntity
    {
        public string Src { get; set; }
        public string Link { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public LocationImages LocationImages { get; set; }

    }


    public enum LocationImages
    {
        tl = 1,   //تاپ چپ
        tr = 2,   //تاپ راست
        mb = 3,   //محصولات برتر
        pf = 4,   //پرفروش ترین ها
        np = 5,   //جدید ترین ها
        pr = 6    //پیشنهاد روزانه  
    }

}
