﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace X.FileSaver.DemoApp.Controllers
{
    public class HomeController: AbpController
    {
        public ActionResult Index()
        {
            return Redirect("/swagger");
        }
    }
}
