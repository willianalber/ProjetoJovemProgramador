﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace JovemProgramadorMvc.Controllers
{
    public class ProfessorController : Controller
    {
        public ProfessorController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
