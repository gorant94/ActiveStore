﻿using ActiveStore.Domain.Entities;

namespace ActiveStore.WebUI.Models
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}