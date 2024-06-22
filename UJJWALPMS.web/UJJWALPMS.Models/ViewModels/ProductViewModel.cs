using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UJJWALPMS.Models.Entity;

namespace UJJWALPMS.Models.ViewModels
{
    public  class ProductViewModel
    {
        public SearchViewModel searchViewModel { get; set; }
        public IEnumerable<Product> products { get; set; }
    }
}
