﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ActiveStore.WebUI.Controllers
{
    public class ContactsController : Controller
    {
        // GET: Contacts
        public ViewResult Contacts()
        {
            return View();
        }
    }
}