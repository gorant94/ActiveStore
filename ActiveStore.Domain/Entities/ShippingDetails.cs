﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ActiveStore.Domain.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "Укажите как вас зовут")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Вставьте основной адрес доставки")]
        [Display(Name = "Основной адрес")]
        public string Line1 { get; set; }

        [Display(Name = "Отделение Новой почты")]
        public string Line2 { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Ваш комментарий")]
        public string Line3 { get; set; }

        [Required(ErrorMessage = "Укажите город")]
        [Display(Name = "Город")]
        public string City { get; set; }

        [Required(ErrorMessage = "Укажите страну")]
        [Display(Name = "Страна")]
        public string Country { get; set; }

        public bool GiftWrap { get; set; }
    }
}
