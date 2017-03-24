using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ActiveStore.Domain.Entities;

namespace ActiveStore.WebUI.Models
{
    public class StartPageViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}