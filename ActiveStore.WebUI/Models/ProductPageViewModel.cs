using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using ActiveStore.Domain.Entities;
using ActiveStore.Domain.Abstract;


namespace ActiveStore.WebUI.Models
{
    public class ProductPageViewModel
    {
        public IEnumerable<Product> Prod{ get; set; }
        public string ReturnUrl { get; set; }
    }
}