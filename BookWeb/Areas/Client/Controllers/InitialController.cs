﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookWeb.Areas.Client.Controllers
{
    [Area("client")]
    public class InitialController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}